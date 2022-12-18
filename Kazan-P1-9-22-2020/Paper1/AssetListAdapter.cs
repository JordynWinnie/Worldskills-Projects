using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Paper1.Models;

namespace Paper1
{
    public class AssetListAdapter : BaseAdapter<AssetModel>
    {
        private List<AssetModel> mItems;
        private Context mContext;

        public AssetListAdapter(List<AssetModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override AssetModel this[int position] => mItems[position];

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.asset_list_layout, parent, false);
            }

            var imageView = convertView.FindViewById<ImageView>(Resource.Id.imageView1);
            var assetLine1 = convertView.FindViewById<TextView>(Resource.Id.assetLine1);
            var assetLine2 = convertView.FindViewById<TextView>(Resource.Id.assetLine2);
            var assetLine3 = convertView.FindViewById<TextView>(Resource.Id.assetLine3);

            var editBtn = convertView.FindViewById<Button>(Resource.Id.editBtn);
            var moveBtn = convertView.FindViewById<Button>(Resource.Id.moveBtn);
            var historyBtn = convertView.FindViewById<Button>(Resource.Id.historyBtn);

            editBtn.Tag = mItems[position].ID;
            moveBtn.Tag = mItems[position].ID;
            historyBtn.Tag = mItems[position].ID;

            assetLine1.Text = mItems[position].AssetName;
            assetLine2.Text = mItems[position].DepartmentName;
            assetLine3.Text = mItems[position].AssetSN;

            editBtn.Click -= EditBtn_Click;
            editBtn.Click += EditBtn_Click;

            moveBtn.Click -= MoveBtn_Click;
            moveBtn.Click += MoveBtn_Click;

            historyBtn.Click -= HistoryBtn_Click;
            historyBtn.Click += HistoryBtn_Click;
            return convertView;
        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            var tag = (int)((Button)sender).Tag;
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            var tag = (int)((Button)sender).Tag;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var tag = (int)((Button)sender).Tag;
        }
    }
}