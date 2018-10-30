using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;

namespace Android_FollowUP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            ListView view = FindViewById<ListView>(Resource.Id.lstView);
            List<string> lst = new List<string>();
            lst.Add("Kuldeep");
            lst.Add("Bob");
            lst.Add("Tim");

            MyListViewAdapter adapter = new MyListViewAdapter(this, lst);

            view.Adapter = adapter;
        }
    }
}

