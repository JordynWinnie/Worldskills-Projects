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
using KazanQR_Paper1_7_24_2020.Models;

namespace KazanQR_Paper1_7_24_2020
{
    public class AssetListViewLayoutAdapter : BaseAdapter<AssetModel>
    {
        private List<AssetModel> mItems;
        private Context mContext;
        private Button editButton;
        private Button moveButton;
        private Button historyButton;

        public override AssetModel this[int position]
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

        public AssetListViewLayoutAdapter(List<AssetModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.assetRowListView, null, false);
            }

            var assetName = convertView.FindViewById<TextView>(Resource.Id.assetNameLV);
            var departmentName = convertView.FindViewById<TextView>(Resource.Id.departmentNameLV);
            var serialNumber = convertView.FindViewById<TextView>(Resource.Id.SNLV);

            assetName.Text = mItems[position].AssetName;
            departmentName.Text = mItems[position].DepartmentName;
            serialNumber.Text = mItems[position].AssetSN;

            editButton = convertView.FindViewById<Button>(Resource.Id.editButton);
            moveButton = convertView.FindViewById<Button>(Resource.Id.moveButton);
            historyButton = convertView.FindViewById<Button>(Resource.Id.historyButton);

            editButton.Tag = position;
            moveButton.Tag = position;
            historyButton.Tag = position;
            editButton.Click += EditButton_Click;
            moveButton.Click += MoveButton_Click;
            historyButton.Click += HistoryButton_Click;

            return convertView;
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(mContext, mItems[(int)editButton.Tag].AssetName + " history", ToastLength.Short).Show();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(mContext, mItems[(int)editButton.Tag].AssetName + " move", ToastLength.Short).Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(mContext, mItems[(int)editButton.Tag].AssetName + " edit", ToastLength.Short).Show();
        }
    }
}