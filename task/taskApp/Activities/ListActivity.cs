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
using taskAppData.Models;
using taskAppData.Services;
using taskApp.Adapters;

namespace taskApp.Activities
{
    [Activity(Label = "List", MainLauncher = true)]
    public class ListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ListLayout);

            var listView = FindViewById<ListView>(Resource.Id.listView);
            var butAdd = FindViewById<Button>(Resource.Id.butAdd);

            var listService = new ListService();
            var list = listService.GetList();

            listView.Adapter = new ListAdapter(this, list);

            listView.ItemClick += ListView_ItemClick;

            butAdd.Click += (sender, e) =>
            {
                StartActivity(typeof(NewItemActivity));
            };


        }

        protected override void OnResume()
        {
            base.OnResume();
            this.OnStart();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ItemActivity));
            var id = (int)e.Id;
            intent.PutExtra(ItemActivity.KEY_ID, id);
            StartActivity(intent);
        }

        private void NewItemAdd_ButtonClick()
        {
        }

    }
}