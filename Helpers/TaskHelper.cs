using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ToDoIstTests
{
    public class TaskHelper : HelperBase
    {
        public TaskHelper(AppManager manager) : base(manager)
        {

        }
        public void CreateTask(Task task)
        {
            Click(StartPage.NewTaskButton);
            FillTheField(StartPage.TaskField, task.TaskName);
            Click(StartPage.SubmitButton);
            Thread.Sleep(10000);

        }
        public Task GetCreatedTaskData()
        {
            var tasks = driver.FindElements(StartPage.TaskListItem);
            return new Task(tasks[tasks.Count - 1].Text);
        }
    }
}
