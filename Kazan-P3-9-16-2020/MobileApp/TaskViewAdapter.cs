using Android.Content;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MobileApp
{
    internal class TaskViewAdapter : BaseAdapter<TaskModel>
    {
        private List<TaskModel> mItems;
        private Context mContext;
        private DateTime dateToCompare;
        private string taskName;
        private string assetName;

        public TaskViewAdapter(List<TaskModel> mItems, Context mContext, DateTime dateToCompare, string taskName, string assetName)
        {
            this.mItems = mItems;
            this.mContext = mContext;
            this.dateToCompare = dateToCompare;
            this.taskName = taskName;
            this.assetName = assetName;

            SortItems();
        }

        private void SortItems()
        {
            mItems = (from x in mItems
                      orderby x.ScheduleDate < dateToCompare, !x.TaskDone
                      orderby x.ScheduleDate == dateToCompare, !x.TaskDone
                      orderby x.ScheduleDate
                      orderby x.TaskDone
                      select x).ToList();

            if (!taskName.Equals("All"))
            {
                mItems = mItems.Where(x => x.TaskName == taskName).ToList();
            }

            if (!assetName.Equals("All"))
            {
                mItems = mItems.Where(x => x.AssetName == assetName).ToList();
            }
        }

        public override TaskModel this[int position] => mItems[position];

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.task_row, parent, false);
            }

            var line1 = convertView.FindViewById<TextView>(Resource.Id.taskRowLine1);
            var line2 = convertView.FindViewById<TextView>(Resource.Id.taskRowLine2);
            var line3 = convertView.FindViewById<TextView>(Resource.Id.taskRowLine3);

            var checkBox = convertView.FindViewById<CheckBox>(Resource.Id.taskRowCheckBox);

            line1.Text = $"{mItems[position].AssetName} ** SN: {mItems[position].AssetSN}";
            line2.Text = $"{mItems[position].TaskName}";

            if (mItems[position].ScheduleDate != null)
            {
                line3.Text = $"Monthly - at {mItems[position].ScheduleDate.Value.ToShortDateString()}";
                //Past Due
                if (mItems[position].ScheduleDate < dateToCompare.AddDays(4) && mItems[position].ScheduleDate > dateToCompare)
                {
                    if (mItems[position].TaskDone)
                    {
                        line3.SetTextColor(Android.Graphics.Color.Black);
                    }
                    else
                    {
                        line3.SetTextColor(Android.Graphics.Color.Purple);
                    }
                }
                else if (mItems[position].ScheduleDate == dateToCompare)
                {
                    if (mItems[position].TaskDone)
                    {
                        line3.SetTextColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        line3.SetTextColor(Android.Graphics.Color.Black);
                    }
                }
                else if (mItems[position].ScheduleDate < dateToCompare)
                {
                    if (mItems[position].TaskDone)
                    {
                        line3.SetTextColor(Android.Graphics.Color.Orange);
                    }
                    else
                    {
                        line3.SetTextColor(Android.Graphics.Color.Red);
                    }
                }
            }
            else
            {
                line3.Text = $"Milage - at {mItems[position].ScheduleKilometer} KM";
                if (!mItems[position].TaskDone)
                {
                    line3.SetTextColor(Android.Graphics.Color.Black);
                }
                else
                {
                    line3.SetTextColor(Android.Graphics.Color.Gray);
                }
            }

            checkBox.Checked = mItems[position].TaskDone;
            checkBox.Tag = mItems[position].ID;

            checkBox.Click -= CheckBox_Click;
            checkBox.Click += CheckBox_Click;
            return convertView;
        }

        private async void CheckBox_Click(object sender, EventArgs e)
        {
            var id = (int)((CheckBox)sender).Tag;
            var status = ((CheckBox)sender).Checked;

            using (var httpClient = new HttpClient())
            {
                var markDone = await httpClient.GetAsync($"http://10.0.2.2:54990/Assets/MarkTask?taskId={id}&isDone={status}");
                if (markDone.IsSuccessStatusCode)
                {
                    Toast.MakeText(mContext, "Task updated", ToastLength.Short).Show();
                }

                var taskRequest = await httpClient.GetAsync("http://10.0.2.2:54990/Assets/GetTasks");
                if (taskRequest.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<TaskModel>>(await taskRequest.Content.ReadAsStringAsync());

                    mItems = result;
                    SortItems();
                }
            }
        }
    }
}