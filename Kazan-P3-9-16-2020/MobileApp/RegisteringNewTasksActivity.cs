using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileApp
{
    [Activity(Label = "RegisteringNewTasksActivity")]
    public class RegisteringNewTasksActivity : Activity
    {
        private Spinner taskNameSpinner;
        private Spinner assetNameSpinner;
        private Button addToListButton;
        private ListView assetListTasks;
        private Spinner scheduleModelSpinner;
        private EditText startEditText;
        private EditText endEditText;
        private EditText changePerKM;
        private Button submitBtn;
        private Button cancelBtn;

        private List<string> assetList = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_task_layout);

            InitViews();
        }

        private async void InitViews()
        {
            taskNameSpinner = FindViewById<Spinner>(Resource.Id.taskNameSpinner);
            assetNameSpinner = FindViewById<Spinner>(Resource.Id.assetNameSpinner);
            addToListButton = FindViewById<Button>(Resource.Id.addToListButton);
            assetListTasks = FindViewById<ListView>(Resource.Id.assetListTasks);
            scheduleModelSpinner = FindViewById<Spinner>(Resource.Id.scheduleModelSpinner);
            startEditText = FindViewById<EditText>(Resource.Id.startEditText);
            endEditText = FindViewById<EditText>(Resource.Id.endEditText);
            changePerKM = FindViewById<EditText>(Resource.Id.changePerKM);
            submitBtn = FindViewById<Button>(Resource.Id.submitBtn);
            cancelBtn = FindViewById<Button>(Resource.Id.cancelBtn);

            using (var httpClient = new HttpClient())
            {
                var assetRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetAssetNames");
                if (assetRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await assetRequest.Content.ReadAsStringAsync());

                    assetNameSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }

                var taskListRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetTaskList");
                if (taskListRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await taskListRequest.Content.ReadAsStringAsync());

                    taskNameSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }

                var scheduleModel = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetScheduleModels");
                if (scheduleModel.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await scheduleModel.Content.ReadAsStringAsync());
                    scheduleModelSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }
            }

            addToListButton.Click += AddToListButton_Click;
            assetListTasks.ItemClick += AssetListTasks_ItemClick;
            submitBtn.Click += SubmitBtn_Click;

            startEditText.Click += StartEditText_Click;
            endEditText.Click += EndEditText_Click;
            scheduleModelSpinner.ItemSelected += ScheduleModelSpinner_ItemSelected;
            cancelBtn.Click += CancelBtn_Click;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void ScheduleModelSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (scheduleModelSpinner.SelectedItem.ToString().Equals("Every X Kilometer"))
            {
                startEditText.Hint = "Start Range";
                endEditText.Hint = "End Range";
            }
            else
            {
                startEditText.Hint = "Start Date";
                endEditText.Hint = "End Date";
            }

            startEditText.Text = string.Empty;
            endEditText.Text = string.Empty;

            switch (scheduleModelSpinner.SelectedItem.ToString())
            {
                case "Daily":
                    changePerKM.Hint = "Repeat every/days";
                    break;

                case "Weekly":
                    changePerKM.Hint = "Repeat every/weeks";

                    break;

                case "Monthly":
                    changePerKM.Hint = "Repeat every/months";

                    break;

                case "Every X Kilometer":
                    changePerKM.Hint = "Reminder Per/KM";
                    break;

                default:
                    break;
            }
        }

        private void EndEditText_Click(object sender, EventArgs e)
        {
            if (!scheduleModelSpinner.SelectedItem.ToString().Equals("Every X Kilometer"))
            {
                var dpd = new DatePickerDialog(this, EndDateSelected, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                dpd.CancelEvent += endDpdCancel;
                dpd.Show();
            }
        }

        private void endDpdCancel(object sender, EventArgs e)
        {
            endEditText.Text = string.Empty;
        }

        private void EndDateSelected(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endEditText.Text = e.Date.ToShortDateString();
        }

        private void StartEditText_Click(object sender, EventArgs e)
        {
            if (!scheduleModelSpinner.SelectedItem.ToString().Equals("Every X Kilometer"))
            {
                var dpd = new DatePickerDialog(this, StartDateSelected, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                dpd.CancelEvent += startDpdCancel;
                dpd.Show();
            }
        }

        private void startDpdCancel(object sender, EventArgs e)
        {
            startEditText.Text = string.Empty;
        }

        private void StartDateSelected(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startEditText.Text = e.Date.ToShortDateString();
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            DateTime startTime;
            DateTime endTime;
            int genericNumber;
            if (startEditText.Text.Length == 0 || endEditText.Text.Length == 0 || changePerKM.Text.Length == 0)
            {
                Toast.MakeText(this, "Fill up all the fields", ToastLength.Short).Show();
                return;
            }

            if (assetList.Count == 0)
            {
                Toast.MakeText(this, "Add an asset", ToastLength.Short).Show();
                return;
            }

            if (!int.TryParse(changePerKM.Text, out genericNumber))
            {
                Toast.MakeText(this, "Number not recognised", ToastLength.Short).Show();
                return;
            }
            DateTime.TryParse(startEditText.Text, out startTime);
            DateTime.TryParse(endEditText.Text, out endTime);

            if (!scheduleModelSpinner.SelectedItem.ToString().Equals("Every X Kilometer"))
            {
                if (startTime > endTime)
                {
                    Toast.MakeText(this, "End date should not be earlier than start date", ToastLength.Short).Show();
                    return;
                }
            }

            foreach (var asset in assetList)
            {
                var periodInDays = (endTime - startTime).Days;
                using (var httpClient = new HttpClient())
                {
                    var getTaskID = int.Parse(await (await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/GetTaskId?taskName={taskNameSpinner.SelectedItem.ToString()}")).Content.ReadAsStringAsync());
                    var getAssetID = int.Parse(await (await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/GetAssetId?assetName={asset}")).Content.ReadAsStringAsync());
                    switch (scheduleModelSpinner.SelectedItem.ToString())
                    {
                        case "Daily":

                            var numberOfReminders = periodInDays / genericNumber;
                            var dateToUpload = startTime;
                            for (int i = 0; i < numberOfReminders + 1; i++)
                            {
                                await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/MakeTask?taskID={getTaskID}&assetID={getAssetID}&scheduleType=2&startDate={dateToUpload.ToShortDateString()}");
                                dateToUpload = dateToUpload.AddDays(genericNumber);
                            }
                            Toast.MakeText(this, $"Uploaded {numberOfReminders + 1} tasks", ToastLength.Short).Show();
                            break;

                        case "Weekly":

                            var numberOfRemindersWeekly = periodInDays / (7 * genericNumber);
                            var dateToUploadWeekly = startTime;
                            for (int i = 0; i < numberOfRemindersWeekly + 1; i++)
                            {
                                await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/MakeTask?taskID={getTaskID}&assetID={getAssetID}&scheduleType=2&startDate={dateToUploadWeekly.ToShortDateString()}");
                                dateToUploadWeekly = dateToUploadWeekly.AddDays(genericNumber * 7);
                            }

                            Toast.MakeText(this, $"Uploaded {numberOfRemindersWeekly + 1} tasks", ToastLength.Short).Show();

                            break;

                        case "Monthly":

                            var dateToUploadMonthly = startTime;
                            var count = 0;
                            while (dateToUploadMonthly < endTime)
                            {
                                await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/MakeTask?taskID={getTaskID}&assetID={getAssetID}&scheduleType=2&startDate={dateToUploadMonthly.ToShortDateString()}");
                                dateToUploadMonthly = dateToUploadMonthly.AddMonths(genericNumber);
                                count++;
                            }
                            Toast.MakeText(this, $"Uploaded {count} tasks", ToastLength.Short).Show();
                            break;

                        case "Every X Kilometer":
                            int startRange = 0;
                            int endRange = 0;
                            if (!int.TryParse(startEditText.Text, out startRange) || !int.TryParse(endEditText.Text, out endRange))
                            {
                                Toast.MakeText(this, "Number not recognised", ToastLength.Short).Show();
                                return;
                            }
                            var response = await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/MakeRunTask?taskID={getTaskID}&assetID={getAssetID}&scheduleType=1&startRange={startRange}&endRange={endRange}&perKMIncrement={genericNumber}");

                            if (response.IsSuccessStatusCode)
                            {
                                Toast.MakeText(this, $"Uploaded {await response.Content.ReadAsStringAsync()} tasks", ToastLength.Short).Show();
                            }
                            else
                            {
                                Toast.MakeText(this, "Range is already within another set in the database. Please choose another", ToastLength.Short).Show();
                                return;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            MainActivity.isRefresh = true;
            Finish();
        }

        private void AssetListTasks_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            assetList.RemoveAt(e.Position);
            assetListTasks.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, assetList);
        }

        private void AddToListButton_Click(object sender, EventArgs e)
        {
            if (assetList.Contains(assetNameSpinner.SelectedItem.ToString()))
            {
                Toast.MakeText(this, "Cannot add duplicate items", ToastLength.Short).Show();
                return;
            }
            assetList.Add(assetNameSpinner.SelectedItem.ToString());
            assetListTasks.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, assetList);
        }
    }
}