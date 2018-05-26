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

namespace taskAppData.Services
{
    public class Values
    {   
        public static readonly string dbName = "taskListDB.db";


    public static string GetDbPath()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(folder, dbName);
        }
    }
}