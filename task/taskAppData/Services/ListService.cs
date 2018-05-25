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
using taskAppData.Data;
using taskAppData.Models;

namespace taskAppData.Services
{
    public class ListService
    {
        private Repository listRepo;

        public ListService()
        {
            listRepo = new Repository();
        }



        public List<TaskItemModel> GetList()
        {
            return listRepo.GetList();
        }

        public TaskItemModel GetItemById(int Id)
        {
            return listRepo.GetItemById(Id);
        }
    }
}
