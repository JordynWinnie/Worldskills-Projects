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
    public class PackageGridAdapter : BaseAdapter<PackagesModel>
    {
        private Context mContext;
        private List<PackagesModel> mItemsPackageModel;
        private List<BookingModel> mItemsBookingModel;
        private TextView tierText;
        private TextView nameText;
        private TextView quantityText;
        private TextView valueText;

        public PackageGridAdapter(Context mContext, List<PackagesModel> mItems)
        {
            this.mContext = mContext;
            this.mItemsPackageModel = mItems;
        }

        public PackageGridAdapter(Context mContext, List<BookingModel> mItemsBookingModel)
        {
            this.mContext = mContext;
            this.mItemsBookingModel = mItemsBookingModel;
        }

        public override PackagesModel this[int position]
        {
            get { return mItemsPackageModel[position]; }
        }

        public override int Count
        {
            get
            {
                if (mItemsPackageModel != null)
                {
                    return mItemsPackageModel.Count;
                }
                else
                {
                    return mItemsBookingModel.Count;
                }
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.packages_grid_layout, null, false);
            }

            tierText = convertView.FindViewById<TextView>(Resource.Id.tierTVGrid);
            nameText = convertView.FindViewById<TextView>(Resource.Id.nameTVGrid);
            quantityText = convertView.FindViewById<TextView>(Resource.Id.quantityTVGrid);
            valueText = convertView.FindViewById<TextView>(Resource.Id.valueTVGrid);

            if (mItemsPackageModel != null)
            {
                tierText.Text = mItemsPackageModel[position].Tier;
                nameText.Text = mItemsPackageModel[position].Name;
                quantityText.Text = mItemsPackageModel[position].Quantity.ToString();
                valueText.Text = mItemsPackageModel[position].Value.ToString();
            }
            else
            {
                tierText.Text = mItemsBookingModel[position].packageTier;
                nameText.Text = mItemsBookingModel[position].packageName;
                quantityText.Text = mItemsBookingModel[position].packageValue.ToString();
                valueText.Text = mItemsBookingModel[position].quantityBooked.ToString();
            }

            return convertView;
        }
    }
}