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

namespace CatsChallengeClient
{
    [Activity(Label = "CatsDetailActivity")]
    public class CatsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.CatsDetail);

            var NameCat = Intent.GetStringExtra("NameCat");
            var textViewNameCat = FindViewById<TextView>(Resource.Id.textViewNameCat);
            textViewNameCat.Text = NameCat;

            var ImageCat = Intent.GetStringExtra("ImageCat");
            var imageViewImageCat = FindViewById<ImageView>(Resource.Id.imageViewImageCat);
            Koush.UrlImageViewHelper.SetUrlDrawable(imageViewImageCat, ImageCat);

            var DescriptionCat = Intent.GetStringExtra("DescriptionCat");
            var textViewDescriptionCat = FindViewById<TextView>(Resource.Id.textViewDescriptionCat);
            textViewDescriptionCat.Text = DescriptionCat;

            this.Title = NameCat;

            var WebSiteCat = Intent.GetStringExtra("WebSiteCat");

            var buttonSitioWeb = FindViewById<Button>(Resource.Id.buttonSitioWeb);

            buttonSitioWeb.Click += (sender, e) =>
            {
                var uri = Android.Net.Uri.Parse(WebSiteCat);
                var intent = new Intent(Intent.ActionView,uri);
                StartActivity(intent);

            };

        }
    }
}