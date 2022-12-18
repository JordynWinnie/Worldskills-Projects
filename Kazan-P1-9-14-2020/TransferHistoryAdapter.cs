using Android.Content;
using Android.Views;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using System.Collections.Generic;

namespace Kazan_P1_9_14_2020
{
    internal class TransferHistoryAdapter : BaseAdapter<TransferHistoryModel>
    {
        private List<TransferHistoryModel> mItems;
        private Context mContext;

        public TransferHistoryAdapter(List<TransferHistoryModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override TransferHistoryModel this[int position] => mItems[position];

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.asset_transfer_history_row, parent, false);
            }

            convertView.FindViewById<TextView>(Resource.Id.transferHistoryLine1).Text = $"Relocation Date: {mItems[position].TransferDate.ToShortDateString()}";
            convertView.FindViewById<TextView>(Resource.Id.transferHistoryLine2).Text = $"From: {mItems[position].OldDep} {mItems[position].FromAssetSN}";
            convertView.FindViewById<TextView>(Resource.Id.transferHistoryLine3).Text = $"To: {mItems[position].NewDep} {mItems[position].ToAssetSN}";

            return convertView;
        }
    }
}