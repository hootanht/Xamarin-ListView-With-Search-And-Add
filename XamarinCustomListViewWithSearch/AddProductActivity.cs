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
using XamarinCustomListViewWithSearch.Model;

namespace XamarinCustomListViewWithSearch
{
    [Activity(Label = "Add", Theme = "@style/AppTheme")]
    public class AddProductActivity : Activity
    {
        #region Controls
        EditText etName, etRating;
        Button btnAdd;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add_product);
            #region Find Controls
            etName = FindViewById<EditText>(Resource.Id.etAddName);
            etRating = FindViewById<EditText>(Resource.Id.etAddRating);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            #endregion
            #region Controls Events
            btnAdd.Click += BtnAdd_Click;
            #endregion
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool validation = true;
            if (etName.Text == string.Empty)
            {
                etName.Error = "Enter Your Product Name";
                validation = false;
            }
            if (etRating.Text == string.Empty)
            {
                etRating.Error = "Enter Your Product Rating";
                validation = false;
            }
            if (etRating.Text != string.Empty)
            {
                if (int.Parse(etRating.Text) < 0 || int.Parse(etRating.Text) > 5)
                {
                    etRating.Error = "The Rating Number Must Between 0 to 5";
                    validation = false;
                }
            }
            foreach (var item in ProductList.ProductsList)
            {
                if (etName.Text==item.Name)
                {
                    etName.Error = "This Name Is Already Exist";
                    validation = false;
                    break;
                }
            }

            if (validation == true)
            {
                Product product = new Product()
                {
                    Name = etName.Text,
                    Score = int.Parse(etRating.Text)
                };
                ProductList.ProductsList.Add(product);
                Toast.MakeText(this, "Your Product Add Complete", ToastLength.Long).Show();
                Finish();
            }
        }
    }
}