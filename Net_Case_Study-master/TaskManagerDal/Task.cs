using System;

namespace TaskManagerDal
{
    public class Task
    {
        public int Task_Id { get; set; }
        public int Parent_Id { get; set; }
        public string Task_Name { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public int Priority { get; set; }
    }

    public class TaskMaster: Task
    {
        public string ParentTask_Name { get; set; }
    }
}
