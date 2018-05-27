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
using taskAppData.Services;
using taskApp.Activities;

namespace taskApp.Adapters
{
    public class ListAdapter : BaseAdapter<TaskItemModel>
    {
        private Activity context;
        private List<TaskItemModel> items;

        public ListAdapter(Activity context, List<TaskItemModel> items)
        {
            this.context = context;
            this.items = items;
        }

        public ListAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override TaskItemModel this[int position] => this.items[position];

        public override int Count => this.items.Count;

        public override long GetItemId(int position)
        {
            if (this[position].IdItem.HasValue)
                return this[position].IdItem.Value;
            else
                return 0;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = this.context.LayoutInflater.Inflate(Resource.Layout.ItemListLayout, null);
            }


            convertView.FindViewById<TextView>(Resource.Id.textTitleItem).Text = item.Title;
            convertView.FindViewById<CheckBox>(Resource.Id.checkItem).Checked = item.IsDone;
            convertView.FindViewById<CheckBox>(Resource.Id.checkItem)
                .CheckedChange += (sender, e) =>
                {
                    try
                    {
                        var listService = new TaskLocalService();

                        item.IsDone = e.IsChecked;

                        listService.Save(item);

                        if (e.IsChecked)
                            Toast.MakeText(convertView.Context, "Task accomplished", ToastLength.Long).Show();

                    }
                    catch (Exception ex)
                    {

                        Toast.MakeText(convertView.Context, ex.Message, ToastLength.Long).Show();
                    }
                };

            return convertView;
        }



    }
}