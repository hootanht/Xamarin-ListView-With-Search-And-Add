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
        public ProductListAdapter(Context context,List<Product> productlist)
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
            if (view==null)
            {
                view = LayoutInflater.From(_context).Inflate(Resource.Layout.goods_view,null,false);
                view.FindViewById<TextView>(Resource.Id.tvName).Text = _productlist[position].Name;
                view.FindViewById<RatingBar>(Resource.Id.rtProduct).Progress = _productlist[position].Score;
            }
            return view;
        }
    }
}