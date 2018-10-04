using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using XamarinCustomListViewWithSearch.MyAdapter;
using XamarinCustomListViewWithSearch.Model;
using System.Collections.Generic;
using Android.Views;

namespace XamarinCustomListViewWithSearch
{
    [Activity(Label = "Main", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        #region Controls
        private AutoCompleteTextView atcSearch;
        private ListView lvAllItem;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            #region FindControls
            atcSearch = FindViewById<AutoCompleteTextView>(Resource.Id.actSearch);
            lvAllItem = FindViewById<ListView>(Resource.Id.lvAllItem);
            #endregion
            #region Controls Events
            UpdateList();
            atcSearch.TextChanged += AtcSearch_TextChanged;
            #endregion
        }

        private void AtcSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (atcSearch.Text != string.Empty)
            {
                List<string> lstNames = new List<string>();
                List<Product> lstView = new List<Product>();
                foreach (var item in ProductList.ProductsList)
                {
                    if (item.Name.StartsWith(atcSearch.Text))
                    {
                        lstNames.Add(item.Name);
                        lstView.Add(item);
                    }
                }
                atcSearch.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, lstNames);
                lvAllItem.Adapter = new ProductListAdapter(this, lstView);
            }
            else
            {
                UpdateList();
            }
        }
        private void UpdateList()
        {
            lvAllItem.Adapter = new ProductListAdapter(this, ProductList.ProductsList);
        }
        protected override void OnResume()
        {
            UpdateList();
            base.OnResume();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(AddProductActivity));
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}