using System.ComponentModel;

namespace MyTasks.Enums
{
   enum TaskStatus : int
    {
        [Description("Work to do")]
        ToDo = 1,
        [Description("Working in progress")]
        Working = 2,
        [Description("The task is done")]
        Done = 3
    }
}
