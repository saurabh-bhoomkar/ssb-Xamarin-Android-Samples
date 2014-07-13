using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace HelloMultiScreen
{
    [Activity(Label = "HelloMultiScreen", MainLauncher = true)]
    public class FirstActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Load the UI created in Main.axml
            SetContentView(Resource.Layout.Main);

            // Get a reference to the button
            var showSecond = FindViewById<Button>(Resource.Id.showSecond);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            EditText editText1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText editText2 = FindViewById<EditText>(Resource.Id.editText2);

            showSecond.Click += (sender, e) =>
            {
                var second = new Intent(this, typeof(SecondActivity));
                second.PutExtra("FirstData", "Data from FirstActivity");
                StartActivity(second);
            };

            ///
            button.Click += delegate
            {
                //button.Text = string.Format("{0} clicks!", count++);
                double oprnd1 = 0;
                double answer = 0;
                try
                {
                    oprnd1 = Convert.ToDouble(editText1.Text);
                }
                catch (Exception e1)
                {
                    editText2.Text = e1.ToString();
                }
                answer = oprnd1 / 1000;
                editText2.Text = answer.ToString() + "   meters";
            };
            ///////////Exit Code//////////////
            button.LongClick += delegate
            {
                System.Environment.Exit(0);
            };
            ///
        }
    }
}