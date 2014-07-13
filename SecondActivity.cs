using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace HelloMultiScreen
{
    [Activity(Label = "TemperatureConverter      @ssb")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Second);
            ////
            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button SwapButton = FindViewById<Button>(Resource.Id.SwapButton);
            EditText editText1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText editText2 = FindViewById<EditText>(Resource.Id.editText2);
            ////
            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner1_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.subCat_array2, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;

            spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner2_ItemSelected);
            var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.subCat_array2, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;
            //////////////
            /***************/

            Button accessMainSource = FindViewById<Button>(Resource.Id.accessMainSource);

            accessMainSource.Click += (sender, e) =>
            {
                var uri = Android.Net.Uri.Parse("http://en.wikipedia.org/wiki/Conversion_of_units_of_temperature");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            /****************/
            button.Click += delegate
            {
                if (spinner1.SelectedItem == spinner2.SelectedItem)
                {
                    editText2.Text = editText1.Text;
                }
                else
                {
                    int spinner1Index = spinner1.SelectedItemPosition;
                    int spinner2Index = spinner2.SelectedItemPosition;
                    double oprnd1 = 0;
                    double answer = 0;
                    try
                    {
                        oprnd1 = Convert.ToDouble(editText1.Text);
                    }
                    catch (FormatException e1)
                    {
                        editText2.Text = e1.ToString();
                    }

                    if (spinner1Index == 0 && spinner2Index == 1)
                    {
                        answer = oprnd1 * 1.8 + 32;//cel-fah
                    }
                    else if (spinner1Index == 0 && spinner2Index == 2)
                    {
                        answer = oprnd1 + 273.15;//cel-kel
                    }
                    else if (spinner1Index == 1 && spinner2Index == 0)
                    {
                        answer = (oprnd1 - 32) / 1.8;//fah-cel
                    }
                    else if (spinner1Index == 1 && spinner2Index == 2)
                    {
                        answer = ((oprnd1 - 32) / 1.8) + 273.15;//fah-kel
                    }
                    else if (spinner1Index == 2 && spinner2Index == 0)
                    {
                        answer = oprnd1 - 273.15;//kel-cel
                    }
                    else if (spinner1Index == 2 && spinner2Index == 1)
                    {
                        answer = (oprnd1 - 273.15) * 1.8 + 32;
                    }
                    editText2.Text = answer.ToString();
                }
            };

            button.LongClick += delegate
            {
                System.Environment.Exit(0);
            };

            SwapButton.Click += delegate
            {
                int temp1, temp2 = 0;
                temp1 = spinner1.SelectedItemPosition;
                temp2 = spinner2.SelectedItemPosition;
                //spinner1.SetSelection(getIndex(spinner, myString));
                spinner1.SetSelection(temp2);
                spinner2.SetSelection(temp1);
                button.PerformClick();
            };
            //////////////
        }

        ///this method is for making a tost

        private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner1 = (Spinner)sender;
            //string toast = string.Format("The Selected length unit is {0}", spinner1.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner2 = (Spinner)sender;
            //string toast = string.Format("The Selected length unit is {0}", spinner1.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}