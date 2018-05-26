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
    public class TaskLocalService
    {
        private TaskLocalRepository repository;

        public TaskLocalService()
        {
            repository = new TaskLocalRepository(Values.GetDbPath());
        }

        public void Save(TaskItemModel taskItem)
        {
            repository.Save(taskItem);
        }

        public List<TaskItemModel> GetAll()
        {
            return repository.GetAll();
        }

        public TaskItemModel GetById(int id)
        {
            return repository.GetById(id);
        }


        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void DeleteAll()
        {
            repository.DeleteAll();
        }

    }
}