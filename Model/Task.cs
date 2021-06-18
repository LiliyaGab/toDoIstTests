using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoIstTests
{
    public class Task
    {
        public Task(string name)
        {
            TaskName = name;
        }
        public Task()
        {
            TaskName = "";
        }
        public string TaskName { get; set; }
    }
}
