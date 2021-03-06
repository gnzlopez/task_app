﻿using System;
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
            // var checkButton = FindViewById<CheckBox>(Resource.Id.checkItem);

            UpdateList();


            listView.ItemClick += ListView_ItemClick; //Add functionality to item when doing click in it
            listView.ItemLongClick += ListView_ItemLongClick; //Add functionality to item when doing LONG click in it

            butAdd.Click += (sender, e) =>
            {
                StartActivity(typeof(NewItemActivity));
            };


        }

        protected override void OnResume()
        {
            base.OnResume();
            UpdateList();
        }

        private void ListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var id = (int)e.Id;
            var listService = new TaskLocalService();

            #region AlertDialog
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Delete");
            builder.SetMessage("You want delete this task?");


            builder.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                listService.Delete(id);
                UpdateList();
            });
            builder.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                builder.Dispose();
            });

            builder.Show(); 
            #endregion

        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ItemActivity));
            var id = (int)e.Id;
            intent.PutExtra(ItemActivity.KEY_ID, id);
            StartActivity(intent);
        }

        private void UpdateList()
        {
            var listView = FindViewById<ListView>(Resource.Id.listView);
            var listService = new TaskLocalService();
            var list = listService.GetAll();

            listView.Adapter = new ListAdapter(this, list);
        }


    }
}