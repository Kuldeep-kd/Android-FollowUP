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
    class MyListViewAdapter : BaseAdapter<string>
    {
        private List<string> List;
        private Context mContext;

        public MyListViewAdapter(Context context, List<string> list)
        {
            List = list;
            mContext = context;
        }

        public override string this[int position]
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

            TextView textView = row.FindViewById<TextView>(Resource.Id.name);
            textView.Text = List[position];

            return row;
        }
    }
}