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
using QR_TP_Session2_5_28_2020.Models;

namespace QR_TP_Session2_5_28_2020
{
    internal class BookingAdapter : BaseAdapter<BookingModel>
    {
        Context mContext;
        List<BookingModel> mItems;
        private TextView companyNameTV;
        private TextView packageNameTV;
        private TextView statusTV;

        public BookingAdapter(Context mContext, List<BookingModel> mItems)
        {
            this.mContext = mContext;
            this.mItems = mItems;
        }

        public override BookingModel this[int position]
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
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.approve_sponsorship_booking_grid_layout, null, false);
            }

            companyNameTV = convertView.FindViewById<TextView>(Resource.Id.companyNameABTV);
            packageNameTV = convertView.FindViewById<TextView>(Resource.Id.packagesNameABTV);
            statusTV = convertView.FindViewById<TextView>(Resource.Id.statusABTV);

            companyNameTV.Text = mItems[position].companyName;
            packageNameTV.Text = mItems[position].packageName;
            statusTV.Text = mItems[position].status;

            return convertView;
        }
    }
}