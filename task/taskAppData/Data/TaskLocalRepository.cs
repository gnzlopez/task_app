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
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace taskAppData.Data
{
    internal class TaskLocalRepository
    {
        private string dbPath;
        private SQLitePlatformAndroid platform;

        public TaskLocalRepository(string dbPath)
        {
            this.dbPath = dbPath;
            platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            using (var db = new SQLiteConnection(platform, dbPath))
            {
                db.CreateTable<TaskItemModel>();
            }
        }

        public void Save(TaskItemModel taskItem)
        {
            using (var db = new SQLiteConnection(platform, dbPath))
            {
                db.InsertOrReplace(taskItem);
            }
        }

        public List<TaskItemModel> GetAll ()
        {
            using (var db = new SQLiteConnection(platform, dbPath))
            {
                return db.Table<TaskItemModel>().ToList();
            }
        }

        public TaskItemModel GetById(int id)
        {
            using (var db = new SQLiteConnection(platform, dbPath))
            {
                return db.Get<TaskItemModel>(id);
            }
        }


        public void Delete(int id)
        {
            using (var db = new SQLiteConnection(platform, dbPath))
            {
                db.Delete<TaskItemModel>(id);
            }
        }

        public void DeleteAll()
        {
            using (var db = new SQLiteConnection(platform, dbPath))
            {
                db.DeleteAll<TaskItemModel>();
            }
        }
    }
}