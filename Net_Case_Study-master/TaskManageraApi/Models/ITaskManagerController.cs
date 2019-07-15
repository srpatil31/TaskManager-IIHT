using System.Collections.Generic;
using System.Web.Http;
using TaskManagerDal;

namespace TaskManageraApi.Models
{
    public interface ITaskManagerController
    {
        IList<TaskMaster> GetAllTask();
        IList<TaskMaster> FilterTask(string task, string parentTask, string priorityFrom, string priorityTo, string dateFrom, string dateTo);
        IHttpActionResult AddParentTask(ParentTask item);
        IHttpActionResult EditParentTask(ParentTask item);
        IHttpActionResult AddTask(Task item);
        IHttpActionResult EditTask(Task item);
    }
}