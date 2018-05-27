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

namespace taskApp.Activities
{
    /// <summary>
    /// This class does nothing but was created and left created
    /// </summary>
    [Activity(Label = "ItemListActivity")]
    public class ItemListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ItemListLayout);           
        }

        
    }
}