using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_01.ViewModel
{
    public class ItemsViewModel
    {
        public int Id { get; set; }
        public string WorkContent { get; set; }
        public bool Completed { get; set; }
        public bool IsImportant { get; set; }
        
    }
}
