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
using SQLite.Net.Attributes;

namespace taskAppData.Models
{
    
    public class TaskItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdItem { get; set; }
        public string Title { get; set; }
        public string Descrip { get; set; }
        public bool IsDone { get; set; }
    }
}