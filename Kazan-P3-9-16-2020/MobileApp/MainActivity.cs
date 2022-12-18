using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileApp
{
    [Activity(Label = "PM List", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText activeDateEditText;
        private ListView taskListView;
        private Button addButton;
        private Spinner assetNameSpinner;
        private Spinner taskSpinner;
        private Button clearButton;
        public static bool isRefresh = false;

        protected override void OnResume()
        {
            base.OnResume();
            if (isRefresh)
            {
                RefreshTasks();
                Toast.MakeText(this, "Database Refreshed", ToastLength.Short).Show();
                isRefresh = false;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitView();
        }

        private async void InitView()
        {
            activeDateEditText = FindViewById<EditText>(Resource.Id.activeDateMainEditText);
            taskListView = FindViewById<ListView>(Resource.Id.taskListView);
            addButton = FindViewById<Button>(Resource.Id.addButton);
            assetNameSpinner = FindViewById<Spinner>(Resource.Id.assetNameSpinner);
            taskSpinner = FindViewById<Spinner>(Resource.Id.taskSpinner);
            clearButton = FindViewById<Button>(Resource.Id.clearButton);

            activeDateEditText.Text = DateTime.Today.ToShortDateString();

            using (var httpClient = new HttpClient())
            {
                var assetList = new List<string> { "All" };
                var taskList = new List<string> { "All" };

                var assetRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetAssetNames");
                if (assetRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await assetRequest.Content.ReadAsStringAsync());

                    assetList.AddRange(result);
                }

                var taskListRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetTaskList");
                if (taskListRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await taskListRequest.Content.ReadAsStringAsync());

                    taskList.AddRange(result);
                }

                assetNameSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, assetList);
                taskSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, taskList);

                var taskRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetTasks");
                if (taskRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<TaskModel>>(await taskRequest.Content.ReadAsStringAsync());

                    taskListView.Adapter = new TaskViewAdapter(result, this, DateTime.Today, taskSpinner.SelectedItem.ToString(), assetNameSpinner.SelectedItem.ToString());
                }
            }

            activeDateEditText.Focusable = false;
            activeDateEditText.Click += ActiveDateEditText_Click;
            clearButton.Click += ClearButton_Click;
            taskSpinner.ItemSelected += TaskSpinner_ItemSelected;
            assetNameSpinner.ItemSelected += AssetNameSpinner_ItemSelected;
            activeDateEditText.TextChanged += ActiveDateEditText_TextChanged;
            addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringNewTasksActivity));
            StartActivity(intent);
        }

        private void ActiveDateEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            RefreshTasks();
        }

        private void AssetNameSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshTasks();
        }

        private void TaskSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshTasks();
        }

        private async void RefreshTasks()
        {
            var date = DateTime.Parse(activeDateEditText.Text);
            using (var httpClient = new HttpClient())
            {
                var taskRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetTasks");
                if (taskRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<TaskModel>>(await taskRequest.Content.ReadAsStringAsync());

                    taskListView.Adapter = new TaskViewAdapter(result, this, date, taskSpinner.SelectedItem.ToString(), assetNameSpinner.SelectedItem.ToString());
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            assetNameSpinner.SetSelection(0);
            taskSpinner.SetSelection(0);
        }

        private void ActiveDateEditText_Click(object sender, EventArgs e)
        {
            var dpd = new DatePickerDialog(this, ActiveDateSelected, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            dpd.CancelEvent += Dpd_CancelEvent;
            dpd.Show();
        }

        private void Dpd_CancelEvent(object sender, EventArgs e)
        {
            activeDateEditText.Text = DateTime.Today.ToShortDateString();
        }

        private void ActiveDateSelected(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            activeDateEditText.Text = e.Date.ToShortDateString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}