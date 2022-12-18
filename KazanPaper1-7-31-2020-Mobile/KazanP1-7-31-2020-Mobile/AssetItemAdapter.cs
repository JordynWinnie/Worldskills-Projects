using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KazanP1_7_31_2020_Mobile.Models;

namespace KazanP1_7_31_2020_Mobile
{
    internal class AssetItemAdapter : BaseAdapter<AssetItem>
    {
        private List<AssetItem> mItems;
        private Context mContext;

        public AssetItemAdapter(List<AssetItem> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override AssetItem this[int position]
        {
            get { return mItems[position]; }
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.assetList_ItemGrid, null, false);
            }

            var assetName = convertView.FindViewById<TextView>(Resource.Id.assetNameGrid);
            var departmentName = convertView.FindViewById<TextView>(Resource.Id.departmentNameGrid);
            var assetSN = convertView.FindViewById<TextView>(Resource.Id.assetSNGrid);
            var editButton = convertView.FindViewById<Button>(Resource.Id.editButtonGrid);
            var moveButton = convertView.FindViewById<Button>(Resource.Id.moveButtonGrid);
            var historyButton = convertView.FindViewById<Button>(Resource.Id.historyButtonGrid);

            assetName.Text = mItems[position].asset.AssetName;
            departmentName.Text = mItems[position].DepartmentName;
            assetSN.Text = mItems[position].asset.AssetSN;

            editButton.Tag = position;
            moveButton.Tag = position;
            editButton.Tag = position;
            editButton.Click -= EditButton_Click;
            moveButton.Click -= MoveButton_Click;
            historyButton.Click -= HistoryButton_Click;
            editButton.Click += EditButton_Click;
            moveButton.Click += MoveButton_Click;
            historyButton.Click += HistoryButton_Click;

            return convertView;
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(mContext, $"{mItems[((int)((Button)sender).Tag)].asset.AssetSN} History", ToastLength.Short).Show();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(mContext, $"{mItems[((int)((Button)sender).Tag)].asset.AssetSN} Move", ToastLength.Short).Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var id = mItems[((int)((Button)sender).Tag)].asset.ID;
            Toast.MakeText(mContext, $"{mItems[((int)((Button)sender).Tag)].asset.AssetSN} Edit", ToastLength.Short).Show();

            var intent = new Intent(mContext, typeof(RegisteringEditingAssetsActivity));
            intent.PutExtra("assetid", id);
            mContext.StartActivity(intent);
        }
    }
}