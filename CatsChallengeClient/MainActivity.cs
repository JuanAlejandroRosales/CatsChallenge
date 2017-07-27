using Android.App;
using Android.Widget;
using Android.OS;
using CatsChallenge.CustomAdapters;
using CatsChallenge.SAL;
using Android.Content;

namespace CatsChallengeClient
{
    [Activity(Label = "Cats", MainLauncher = true)]

    public class MainActivity : Activity
        
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var listViewCats = FindViewById<ListView>(Resource.Id.listViewCats);

            var ServiceGetCats = new ServiceClient();

            var GetListCats = await ServiceGetCats.GetCatsAsync();

            listViewCats.Adapter = new CatsAdapter(
                this, GetListCats, Resource.Layout.ListItem, Resource.Id.textViewNameCat, Resource.Id.textViewPriceCat,
                Resource.Id.imageViewCat);


            listViewCats.ItemClick += (sender, e) =>
            {
                var Intent = new Intent(this,
                   typeof(CatsDetailActivity));
               
                var Cat = GetListCats[e.Position];
                
                Intent.PutExtra("IDCat", Cat.ID);
                Intent.PutExtra("NameCat", Cat.Name);
                Intent.PutExtra("ImageCat", Cat.Image);
                Intent.PutExtra("DescriptionCat", Cat.Description);
                Intent.PutExtra("WebSiteCat", Cat.WebSite);
                StartActivity(Intent);
            };
        }


    }
}

