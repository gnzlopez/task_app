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

namespace taskApp.Activities
{
    [Activity(Label = "ItemActivity")]
    public class ItemActivity : Activity
    {
        internal static string KEY_ID = "KEY_ID";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ItemLayout);

            var id = Intent.Extras.GetInt(KEY_ID);

            var listService = new TaskLocalService();
            var item = listService.GetById(id);

            var title = FindViewById<TextView>(Resource.Id.textTitleMain);
            var desc = FindViewById<TextView>(Resource.Id.textDescMain);
            var check = FindViewById<CheckBox>(Resource.Id.checkMain);

            title.Text = item.Title;
            desc.Text = item.Descrip;
            check.Checked = item.IsDone;
        }
    }
}