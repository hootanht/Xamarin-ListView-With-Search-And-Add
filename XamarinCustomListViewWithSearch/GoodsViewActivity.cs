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

namespace XamarinCustomListViewWithSearch
{
    [Activity(Label = "GoodsViewActivity")]
    public class GoodsViewActivity : Activity
    {
        #region Controls
        TextView tvName;
        RatingBar rtProduct;
        Button btnSend;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.goods_view);
            #region Find Controls
            tvName = FindViewById<TextView>(Resource.Id.tvName);
            rtProduct = FindViewById<RatingBar>(Resource.Id.rtProduct);
            btnSend = FindViewById<Button>(Resource.Id.btnSend);
            #endregion
        }
    }
}