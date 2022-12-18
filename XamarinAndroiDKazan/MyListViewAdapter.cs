using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using XamarinSampleAndroid.Models;

namespace XamarinSampleAndroid.Resources.layout
{
    public class MyListViewAdapter : BaseAdapter<AssetClass>
    {
        private List<AssetClass> mItems;
        private Context mContext;
        private bool orientation;

        public MyListViewAdapter(Context context, List<AssetClass> items, bool isPortrait)
        {
            mItems = items;
            mContext = context;
            orientation = isPortrait;
        }


        public override AssetClass this[int position]
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
                if (orientation)
                {
                    convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.MyListVIew, null, false);

                    TextView txtAssetName = convertView.FindViewById<TextView>(Resource.Id.firstName);
                    TextView txtDepartment = convertView.FindViewById<TextView>(Resource.Id.middleName);
                    TextView txtAssetSN = convertView.FindViewById<TextView>(Resource.Id.lastName);

                    ImageView imgView = convertView.FindViewById<ImageView>(Resource.Id.imgView);
                    ImageButton editBtn = convertView.FindViewById<ImageButton>(Resource.Id.editImageBtn);
                    ImageButton moveBtn = convertView.FindViewById<ImageButton>(Resource.Id.moveImageBtn);
                    ImageButton listBtn = convertView.FindViewById<ImageButton>(Resource.Id.listBtn);

                    editBtn.Tag = position;
                    moveBtn.Tag = position;
                    listBtn.Tag = position;
                    imgView.Tag = position;

                    txtAssetName.Text = mItems[position].AssetName;
                    txtDepartment.Text = mItems[position].DepartmentName;
                    txtAssetSN.Text = mItems[position].AssetSN;

                    editBtn.Click -= EditBtn_Click;
                    editBtn.Click += EditBtn_Click;

                    moveBtn.Click -= MoveBtn_Click;
                    moveBtn.Click += MoveBtn_Click;

                    listBtn.Click -= ListBtn_Click;
                    listBtn.Click += ListBtn_Click;
                }
                else
                {
                    convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.landscape_layout, null, false);

                    TextView txtAssetName = convertView.FindViewById<TextView>(Resource.Id.landscapeAssetName);
                    TextView txtDepartment = convertView.FindViewById<TextView>(Resource.Id.landscapeAssetSN);
                    
                    ImageButton editBtn = convertView.FindViewById<ImageButton>(Resource.Id.landscapeEditBtn);

                    txtAssetName.Text = mItems[position].AssetName;
                    txtDepartment.Text = mItems[position].AssetSN;

                    editBtn.Click -= EditBtn_Click;
                    editBtn.Click += EditBtn_Click;
                }
               
            }

            

            

            
            //Fix bug where images populate at positions they are not meant to populate 
            

            
            return convertView;
        }
       

        private void ListBtn_Click(object sender, EventArgs e)
        {
            int position = (int)((ImageButton)sender).Tag;


            Intent intent = new Intent(mContext, typeof(TransferHistoryActivity));
            intent.PutExtra("id", mItems[position].UUID);
            ((MainActivity)mContext).StartActivity(intent);

        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            int position = (int)((ImageButton)sender).Tag;
            

            Intent intent = new Intent(mContext, typeof(AssetTransferActivity));
            intent.PutExtra("id", mItems[position].UUID);
            ((MainActivity)mContext).StartActivity(intent);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int position = (int)((ImageButton)sender).Tag;
            Console.WriteLine(mItems[position].UUID);

            Intent intent = new Intent(mContext, typeof(RegisteringAndEditingAssets));
            intent.PutExtra("id", mItems[position].UUID);
            ((MainActivity)mContext).StartActivity(intent);
        }

    }
}