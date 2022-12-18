using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using MobileApp.Models;
using System.Collections.Generic;

namespace MobileApp
{
    internal class WellAdapter : BaseAdapter<WellInformationRowModel>
    {
        private List<WellInformationRowModel> mItems;
        private Context mContext;

        public WellAdapter(List<WellInformationRowModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;

            if (mItems[mItems.Count - 1].EndPoint != mItems[0].GasOilDepth)
            {
                mItems.Add(new WellInformationRowModel
                {
                    RockName = "Gas/Oil",
                    BackgroundColor = Color.Black.ToArgb().ToString(),
                    GasOilDepth = mItems[0].GasOilDepth,
                    EndPoint = mItems[0].GasOilDepth,
                    StartPoint = mItems[mItems.Count - 1].EndPoint,
                    Capacity = mItems[0].Capacity
                }
           );
            }
        }

        public override WellInformationRowModel this[int position] => mItems[position];

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            double totalHeight = 800;
            double capacity = mItems[position].GasOilDepth;

            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.oilRow_layout, parent, false);
            }

            var height = convertView.FindViewById<LinearLayout>(Resource.Id.linearLayoutHeight);
            var rockName = convertView.FindViewById<Button>(Resource.Id.rockNameButton);
            var rockDepth = convertView.FindViewById<TextView>(Resource.Id.rockDepth);

            if (mItems[position].RockName != "Gas/Oil")
            {
                rockName.SetBackgroundColor(Color.ParseColor(mItems[position].BackgroundColor));
            }
            else
            {
                rockName.SetBackgroundColor(Color.Black);
                rockName.SetTextColor(Color.White);
            }
            var para = height.LayoutParameters;
            para.Height = (int)(((mItems[position].EndPoint - mItems[position].StartPoint) / capacity) * totalHeight);

            rockName.Text = mItems[position].RockName;
            rockDepth.Text = mItems[position].StartPoint.ToString();

            height.LayoutParameters = para;

            return convertView;
        }
    }
}