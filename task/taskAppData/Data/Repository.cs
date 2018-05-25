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

namespace taskAppData.Data
{
    public class Repository
    {
        private List<TaskItemModel> itemList;

        public Repository()
        {
            itemList = new List<TaskItemModel>()
            {
                new TaskItemModel()
                {
                    IdItem = 1,
                    Title = "Tarea de ingles",
                    Descrip = "Hacer la tarea que esta en el wp para el 5/6",
                    IsDone = false
                },

                new TaskItemModel()
                {
                    IdItem = 2,
                    Title = "Tarea de Base de Datos",
                    Descrip = "Hacer la tarea que esta en la carpeta para el 31/5",
                    IsDone = false
                }
            };
        }

        public List<TaskItemModel> GetList()
        {
            return itemList;
        }

        public TaskItemModel GetItemById(int Id)
        {
            return itemList.FirstOrDefault(x => x.IdItem == Id);
        }
    }
}