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

namespace XamarinSampleAndroid
{
    public class TransferHistoryRowAdapter : BaseAdapter<AssetTransferLogModelClass>
    {
        private List<AssetTransferLogModelClass> LogList;
        private Context mContext;
        private TextView relocationDateTxt;
        private TextView oldDepartmentTxt;
        private TextView newDepartmentTxt;

        public TransferHistoryRowAdapter(List<AssetTransferLogModelClass> logList, Context mContext)
        {
            LogList = logList;
            this.mContext = mContext;
        }

        public override AssetTransferLogModelClass this[int position]
        {
            get { return LogList[position]; }
        }

        public override int Count
        {
            get { return LogList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.transferHistoryRow, null, false);
            }

            relocationDateTxt = convertView.FindViewById<TextView>(Resource.Id.relocationDateTxt);
            oldDepartmentTxt = convertView.FindViewById<TextView>(Resource.Id.oldDepartmentAssetSNTxt);
            newDepartmentTxt = convertView.FindViewById<TextView>(Resource.Id.newDepartmentAssetSNTxt);

           var OldDepartmentName = MainActivity.mDepartmentLocationList.Where(x => x.DepartmentLocationID == LogList[position].FromDepartmentLocationID).FirstOrDefault();
           var NewDepartmentName = MainActivity.mDepartmentLocationList.Where(x => x.DepartmentLocationID == LogList[position].ToDepartmentLocationID).FirstOrDefault();

            relocationDateTxt.Text = $"Relocation Date: {LogList[position].TransferDate.ToString("dd/MM/yyyy")}";
            oldDepartmentTxt.Text = $"{OldDepartmentName.DepartmentName} {LogList[position].FromAssetSN}";
            newDepartmentTxt.Text = $"{NewDepartmentName.DepartmentName} {LogList[position].ToAssetSN}";


            return convertView;
        }
    }
}