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

namespace XamarinCustomListViewWithSearch.Model
{
    public class Product
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    public class ProductList
    {
        public static List<Product> ProductsList = new List<Product>();
    }
}