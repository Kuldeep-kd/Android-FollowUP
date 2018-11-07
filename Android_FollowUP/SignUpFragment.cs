using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Android_FollowUP
{

    public class SignUpEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SignUpEventArgs(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }

    

    public class SignUpFragment : DialogFragment
    {
        private EditText name;
        private EditText email;
        private EditText password;
        private Button BtnSignUp;
        public event EventHandler<SignUpEventArgs> OnSignUpEventArgs;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.sign_in_box, container, false);
            name = view.FindViewById<EditText>(Resource.Id.Name);
            email = view.FindViewById<EditText>(Resource.Id.EMail);
            password = view.FindViewById<EditText>(Resource.Id.Password);
            BtnSignUp = view.FindViewById<Button>(Resource.Id.btnFrgSignUp);

            BtnSignUp.Click += BtnSignUp_Click;

            // Use this to return your custom view for this Fragment
            return view;
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            OnSignUpEventArgs.Invoke(this, new SignUpEventArgs(name.Text, email.Text, password.Text));
            this.Dismiss();
        }
    }
}