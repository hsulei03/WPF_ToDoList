using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_01.ViewModel
{
    public class ToDoViewModel
    {
        public ToDoViewModel()
        {
            Menus = new ObservableCollection<MenuModel>();
            Menus.Add(new MenuModel { Title = "我的一天", Icon = "SunOutline" });
            Menus.Add(new MenuModel { Title = "重要", Icon = "Star" });
            Menus.Add(new MenuModel { Title = "已計劃", Icon = "Calendar" });
            Menus.Add(new MenuModel { Title = "已指派給您", Icon = "User" });
            Menus.Add(new MenuModel { Title = "工作", Icon = "Home" });
        }
        public ObservableCollection<MenuModel> Menus { get; set; }
    }
}
