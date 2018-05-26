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
using taskAppData.Services;
using taskAppData.Models;

namespace taskApp.Activities
{
    [Activity(Label = "NewItemActivity")]
    public class NewItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.NewItemLayout);

            var butCancel = FindViewById<Button>(Resource.Id.butAddCancel);
            var butAddOk = FindViewById<Button>(Resource.Id.butAddOk);
            
            butCancel.Click += (sender, e) => base.OnBackPressed();
            butAddOk.Click += NewItem_AddClick;
        }

        private void NewItem_AddClick(object sender, EventArgs e)
        {
            var textTitle = FindViewById<EditText>(Resource.Id.newTitleId);
            var textDesc = FindViewById<EditText>(Resource.Id.newDescId);
            var itemToAdd = new TaskItemModel()
            {
                Title = textTitle.Text,
                Descrip = textDesc.Text,
                IsDone = false
            };
            try
            {
                var taskService = new TaskLocalService();
                taskService.Save(itemToAdd);
                Toast.MakeText(this, "Saved", ToastLength.Long).Show();

            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }

            base.OnBackPressed();
        }
    }
}