using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using System;
using System.Collections.Generic;

namespace Kazan_P1_9_14_2020
{
    internal class AssetListViewAdapter : BaseAdapter<AssetModel.AssetListViewModel>
    {
        private List<AssetModel.AssetListViewModel> mItems;
        private Context mContext;

        public AssetListViewAdapter(List<AssetModel.AssetListViewModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override AssetModel.AssetListViewModel this[int position] => mItems[position];

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.assetlist_row, parent, false);
            }

            convertView.FindViewById<TextView>(Resource.Id.assetNameTextView).Text = mItems[position].AssetName;
            convertView.FindViewById<TextView>(Resource.Id.departmentTextView).Text = mItems[position].DepartmentName;
            convertView.FindViewById<TextView>(Resource.Id.SNTextView).Text = mItems[position].AssetSN;

            if (mItems[position].AssetPhotos.Count != 0)
            {
                var byteArr = mItems[position].AssetPhotos[0].AssetPhoto1;
                var bitmap = BitmapFactory.DecodeByteArray(byteArr, 0, byteArr.Length);
                convertView.FindViewById<ImageView>(Resource.Id.rowImage).SetImageBitmap(bitmap);
            }

            var editButton = convertView.FindViewById<Button>(Resource.Id.editBtn);
            var moveButton = convertView.FindViewById<Button>(Resource.Id.moveBtn);
            var historyButton = convertView.FindViewById<Button>(Resource.Id.historyBtn);

            editButton.Tag = position;
            moveButton.Tag = position;
            historyButton.Tag = position;

            editButton.Click -= EditButton_Click;
            editButton.Click += EditButton_Click;

            moveButton.Click -= MoveButton_Click;
            moveButton.Click += MoveButton_Click;

            historyButton.Click -= HistoryButton_Click;
            historyButton.Click += HistoryButton_Click;
            return convertView;
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            var tag = (int)((Button)sender).Tag;
            Toast.MakeText(mContext, "History click " + mItems[tag].AssetName, ToastLength.Short).Show();
            var intent = new Intent(mContext, typeof(TransferHistoryActivity));
            intent.PutExtra("id", mItems[tag].ID);
            mContext.StartActivity(intent);
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            var tag = (int)((Button)sender).Tag;
            Toast.MakeText(mContext, "Move click " + mItems[tag].AssetName, ToastLength.Short).Show();
            var intent = new Intent(mContext, typeof(AssetTransferActivity));
            intent.PutExtra("id", mItems[tag].ID);
            mContext.StartActivity(intent);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var tag = (int)((Button)sender).Tag;
            Toast.MakeText(mContext, "Edit click " + mItems[tag].AssetName, ToastLength.Short).Show();

            var intent = new Intent(mContext, typeof(RegisteringAndEditingAssetsActivity));
            intent.PutExtra("id", mItems[tag].ID);
            mContext.StartActivity(intent);
        }
    }
}