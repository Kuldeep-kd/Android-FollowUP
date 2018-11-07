using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using System;
using System.Threading;
using Android.Views;

namespace Android_FollowUP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        private List<Person> People;
        private ListView view;
        private ProgressBar progress;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            progress = FindViewById<ProgressBar>(Resource.Id.prgBar);
            view = FindViewById<ListView>(Resource.Id.lstView);
            People = new List<Person>();

            //Lazy enough to populate the list...
            for(int x =1; x<10;x++)
                People.Add(new Person() { FirstName = "Kuldeep"+x.ToString(), LastName = "Thakre" + x.ToString(), Age = 15+x, Gender = "Male" + x.ToString() });


            MyListViewAdapter adapter = new MyListViewAdapter(this, People);

            view.Adapter = adapter;
            view.ItemClick += View_ItemClick;
            var btn = FindViewById<Button>(Resource.Id.btnSignUp);
            btn.Click += Btn_Click;
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SignUpFragment fragment = new SignUpFragment();
            fragment.Show(transaction,"transaction");
            fragment.OnSignUpEventArgs += Fragment_OnSignUpEventArgs;
        }

        private void Fragment_OnSignUpEventArgs(object sender, SignUpEventArgs e)
        {
            Console.WriteLine(e.Name + " " + e.Email + " " + e.Password);
            progress.Visibility = ViewStates.Visible;
            Thread t = new Thread(Timerr);
            t.Start();
        }

        private void Timerr()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { progress.Visibility = ViewStates.Invisible; });
        }

        private void View_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(People[e.Position].FirstName);
        }

    }
}

