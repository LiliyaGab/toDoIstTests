using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ToDoIstTests
{
    class TaskCreationTests : AuthBase
    {
        public static IEnumerable<Task> TaskDataFromXmlFile()
        {
            return (List<Task>)new XmlSerializer(typeof(List<Task>)).Deserialize(new StreamReader(@"tasks.xml"));
        }

        [Test, TestCaseSource("TaskDataFromXmlFile")]
        public void CreateTaskTest(Task task)
        {
            app.Task.CreateTask(task);
            Task newtask = app.Task.GetCreatedTaskData();
            Assert.AreEqual(task.TaskName, newtask.TaskName);
        }

    }
}
