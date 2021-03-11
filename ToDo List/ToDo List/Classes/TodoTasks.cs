using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ToDo_List.Classes
{
    class TodoTasks
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string TaskGroup { get; set; }
        public string TaskName { get; set; }
        public string TaskDate { get; set; }
        public bool TaskChecked { get; set; }
        public string TextColor { get; set; }
    }
}
