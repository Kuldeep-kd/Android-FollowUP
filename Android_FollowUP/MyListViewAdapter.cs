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

namespace Android_FollowUP
{
    class MyListViewAdapter : BaseAdapter<Person>
    {
        private List<Person> List;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Person> list)
        {
            List = list;
            mContext = context;
        }

        public override Person this[int position]
        {
            get { return List[position]; }
        }

        public override int Count
        {
            get { return List.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.list_layout, null, false);
            }

            TextView FirstName= row.FindViewById<TextView>(Resource.Id.FirstName);
            FirstName.Text = List[position].FirstName;

            TextView LastName = row.FindViewById<TextView>(Resource.Id.LastName);
            LastName.Text = List[position].LastName;

            TextView Age = row.FindViewById<TextView>(Resource.Id.Age);
            Age.Text = List[position].Age.ToString();

            TextView Gender = row.FindViewById<TextView>(Resource.Id.Gender);
            Gender.Text = List[position].Gender;

            return row;
        }
    }
}