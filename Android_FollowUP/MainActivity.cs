using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using System;

namespace Android_FollowUP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        private List<Person> People;
        private ListView view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            view = FindViewById<ListView>(Resource.Id.lstView);
            People = new List<Person>();

            for(int x =1; x<10;x++)
                People.Add(new Person() { FirstName = "Kuldeep"+x.ToString(), LastName = "Thakre" + x.ToString(), Age = 20+x, Gender = "Male" + x.ToString() });

            MyListViewAdapter adapter = new MyListViewAdapter(this, People);

            view.Adapter = adapter;
            view.ItemClick += View_ItemClick;
        }

        private void View_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(People[e.Position].FirstName);
        }
    }
}

