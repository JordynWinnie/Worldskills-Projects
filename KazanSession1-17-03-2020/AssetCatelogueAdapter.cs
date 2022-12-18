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
using KazanSession1_17_02_2020.Models;

namespace KazanSession1_17_02_2020
{
    public class AssetCatelogueAdapter : BaseAdapter<AssetModel>
    {
        private Context mContext;
        private List<AssetModel> mItems;

        public AssetCatelogueAdapter(Context mContext, List<AssetModel> mItems)
        {
            this.mContext = mContext;
            this.mItems = mItems;
        }

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

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.assetCatelogueRow, null, false);
            }

            var assetName = convertView.FindViewById<TextView>(Resource.Id.assetCatRowAssetName);
            var departmentName = convertView.FindViewById<TextView>(Resource.Id.assetCatRowAssetDepartmentName);
            var assetSN = convertView.FindViewById<TextView>(Resource.Id.assetCatRowAssetSN);

            var editBtn = convertView.FindViewById<ImageButton>(Resource.Id.assetCatRowEditBtn);
            var moveBtn = convertView.FindViewById<ImageButton>(Resource.Id.assetCatRowMoveBtn);
            var historyBtn = convertView.FindViewById<ImageButton>(Resource.Id.assetCatRowHistoryBtn);

            editBtn.Tag = position;
            moveBtn.Tag = position;
            historyBtn.Tag = position;


            assetName.Text = mItems[position].AssetName;
            departmentName.Text = mItems[position].DepartmentName;
            assetSN.Text = mItems[position].AssetSN;


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
            throw new NotImplementedException();
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}