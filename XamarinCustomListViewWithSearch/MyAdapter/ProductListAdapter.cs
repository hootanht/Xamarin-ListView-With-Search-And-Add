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

namespace XamarinCustomListViewWithSearch.MyAdapter
{
    public class ProductListAdapter : BaseAdapter<Product>
    {
        private Context _context;
        private List<Product> _productlist;
        public ProductListAdapter(Context context, List<Product> productlist)
        {
            _context = context;
            _productlist = productlist;
        }
        public override Product this[int position] => _productlist[position];

        public override int Count => _productlist.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(_context).Inflate(Resource.Layout.goods_view, null, false);
                var tvName = view.FindViewById<TextView>(Resource.Id.tvName);
                tvName.Text = _productlist[position].Name;
                var rtProduct = view.FindViewById<RatingBar>(Resource.Id.rtProduct);
                rtProduct.Rating = _productlist[position].Score;
                var btnSend = view.FindViewById<Button>(Resource.Id.btnSend);
                btnSend.Click += delegate
                {
                    var rtdialog = new AlertDialog.Builder(_context);
                    rtdialog.SetMessage("Do You Want To Send Your Ratting?");
                    rtdialog.SetPositiveButton("Send", delegate
                    {
                        Toast.MakeText(_context, $"Your Feed Back Is Send, With Score {rtProduct.Rating.ToString()}", ToastLength.Short).Show();
                    });
                    rtdialog.SetNegativeButton("Don't Send", delegate { });
                    rtdialog.Show();
                };
                rtProduct.RatingBarChange += delegate
                {
                    Toast.MakeText(_context, rtProduct.Rating.ToString(), ToastLength.Short).Show();
                };
            }
            return view;
        }
    }
}