using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManageraApi.Models;
using TaskManagerDal;

namespace TaskManageraApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskManagerController : ApiController, ITaskManagerController
    {
        private readonly TaskManagerDataAccessLayer dal = new TaskManagerDataAccessLayer();

        public IList<TaskMaster> GetAllTask()
        {
            IList<TaskMaster> taskList = dal.GetAllTask();
            return taskList;
        }

        public Task GetTaskById(string id)
        {
            var task = dal.GetTaskById(id);
            if(task!=null && task.Count>0)
                return task[0];
            return null;
        }


        public IList<TaskMaster> FilterTask(string task, string parentTask, string priorityFrom, string priorityTo, string dateFrom, string dateTo)
        {
            IList<TaskMaster> taskList = dal.GetAllFilterTask(task, parentTask, priorityFrom, priorityTo, dateFrom, dateTo);
            return taskList;
        }

        [HttpPost]
        public IHttpActionResult AddParentTask(ParentTask item)
        {
            if (item == null)
            {
                return NotFound();
            }
            dal.AddParentTask(item);
            return Ok("Success");
        }

        [HttpPost]
        public IHttpActionResult EditParentTask(ParentTask item)
        {
            var data = (from q in dal.GetParentTaskById(item.Parent_Id.ToString())
                        where q.Parent_Id.Equals(item.Parent_Id)
                        select q).SingleOrDefault();
            if (data == null)
            {
                return NotFound();
            }

            data.Parent_Task = item.Parent_Task;

            dal.EditParentTask(item);

            return Ok("Success");
        }

        [HttpPost]
        public IHttpActionResult AddTask(Task item)
        {
            if (item == null)
            {
                return NotFound();
            }
            dal.AddTask(item);
            return Ok("Success");
        }

        [HttpPost]
        public IHttpActionResult EditTask(Task item)
        {
            var data = (from q in dal.GetTaskById(item.Task_Id.ToString())
                        where q.Task_Id.Equals(item.Task_Id)
                        select q).SingleOrDefault();
            if (data == null)
            {
                return NotFound();
            }

            data.Task_Name = item.Task_Name;

            dal.EditTask(item);

            return Ok("Success");
        }
    }
}
