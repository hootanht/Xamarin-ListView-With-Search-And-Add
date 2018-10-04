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
            #region Controls Events
            rtProduct.RatingBarChange += RtProduct_RatingBarChange;
            btnSend.Click += BtnSend_Click;
            #endregion
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var rtdialog = new AlertDialog.Builder(this);
            rtdialog.SetPositiveButton("Send", delegate
            {
                Toast.MakeText(this, $"Your Feed Back Is Send, With Score {rtProduct.Progress}", ToastLength.Short).Show();
            });
            rtdialog.SetNegativeButton("Don't Send", delegate { });
            rtdialog.Show();
        }

        private void RtProduct_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
        {
            Toast.MakeText(this, rtProduct.Progress.ToString(), ToastLength.Short).Show();
        }
    }
}