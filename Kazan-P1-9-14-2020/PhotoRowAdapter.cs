using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using System.Collections.Generic;

namespace Kazan_P1_9_14_2020
{
    internal class PhotoRowAdapter : BaseAdapter<AssetPhotoModel>
    {
        private List<AssetPhotoModel> mItems;
        private Context mContext;

        public PhotoRowAdapter(List<AssetPhotoModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override AssetPhotoModel this[int position] => mItems[position];

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.photo_row, parent, false);
            }

            convertView.FindViewById<ImageView>(Resource.Id.rowImageADD).SetImageBitmap(byteArrayToImage(mItems[position].AssetPhoto1));
            convertView.FindViewById<TextView>(Resource.Id.imageNameADD).Text = $"Image {position + 1}";

            return convertView;
        }

        public Bitmap byteArrayToImage(byte[] byteArrayIn)
        {
            return BitmapFactory.DecodeByteArray(byteArrayIn, 0, byteArrayIn.Length);
        }
    }
}