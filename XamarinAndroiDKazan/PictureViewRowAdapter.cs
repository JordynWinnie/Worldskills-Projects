using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using XamarinSampleAndroid.Resources.layout;

namespace XamarinSampleAndroid
{
    public class PictureViewRowAdapter : BaseAdapter<PictureClass>
    {
        List<PictureClass> mPictureList;
        Context mContext;

        public PictureViewRowAdapter(List<PictureClass> mPictureList, Context mContext)
        {
            this.mPictureList = mPictureList;
            this.mContext = mContext;
        }

        public override PictureClass this[int position]
        {
            get { return mPictureList[position]; }
        }

        public override int Count
        {
            get { return mPictureList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.pictureRow, null, false);
            }

            TextView txtPictureName = convertView.FindViewById<TextView>(Resource.Id.txtPictureName);
            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.pictureView);

            txtPictureName.Text = mPictureList[position].PhotoName;

            if (mPictureList[position].ImageByteArray != null)
            {
                imageView.SetImageBitmap(BitmapFactory.DecodeByteArray(mPictureList[position].ImageByteArray, 0, mPictureList[position].ImageByteArray.Length));
            }

            imageView.SetImageBitmap(mPictureList[position].PhotoDrawable);

            return convertView;
        }
    }
}