using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;

namespace QR_TP_Session1_5_3_2020
{
    class ResourceListViewAdapter : BaseAdapter<ResourceListViewModel>
    {
        public List<ResourceListViewModel> mItems;
        private Context mContext;

        public ResourceListViewAdapter(List<ResourceListViewModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override ResourceListViewModel this[int position]
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
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.ResourceListViewLayout, null, false);
            }

            var resourceName = convertView.FindViewById<TextView>(Resource.Id.nameResourceListView);
            var typeName = convertView.FindViewById<TextView>(Resource.Id.typeResourceListView);
            var numberOfSkills = convertView.FindViewById<TextView>(Resource.Id.noOfSkillResourceListView);
            var allocatedSkills = convertView.FindViewById<TextView>(Resource.Id.allocatedSkillResourceListView);
            var quantity = convertView.FindViewById<TextView>(Resource.Id.quantityResourceListView);

            resourceName.Text = $"Resource Name: {mItems[position].ResourceName}";
            typeName.Text = $"Type: {mItems[position].ResourceType}";

            if (mItems[position].AllocatedSkills.Count != 0)
            {
                allocatedSkills.Text = $"Allocated Skills: {string.Join(", ", mItems[position].AllocatedSkills.Select(x => x.skillName).ToList())}";
            }
            else
            {
                allocatedSkills.Text = "Allocated Skills: NIL";
            }

            
            numberOfSkills.Text = $"Number Of Skills: {mItems[position].NumberOfSkills}";

            if (mItems[position].Quantity <= 0)
            {
                quantity.Text = "No Stock";
            }
            else if (mItems[position].Quantity >= 1 && mItems[position].Quantity <= 5)
            {
                quantity.Text = "Low Stock";
            }
            else
            {
                quantity.Text = "Sufficient";
            }
            
            return convertView;
        }


    }
}