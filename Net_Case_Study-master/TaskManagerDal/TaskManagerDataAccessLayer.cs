using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManagerDal
{
    public class TaskManagerDataAccessLayer 
    {
        public IList<TaskMaster> GetAllFilterTask(string task, string parentTask,string priorityFrom, string priorityTo,string dateFrom, string dateTo)
        {
            IList<TaskMaster> lstItem = new List<TaskMaster>();

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FILTER_ALL_TASK_MASTER", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TASK", task);
                    cmd.Parameters.AddWithValue("@PARENTTASK", parentTask);
                    cmd.Parameters.AddWithValue("@PRIORITYFROM", priorityFrom);
                    cmd.Parameters.AddWithValue("@PRIORITYTO", priorityTo);
                    cmd.Parameters.AddWithValue("@DATEFROM", Convert.ToDateTime(dateFrom));
                    cmd.Parameters.AddWithValue("@DATELTO", Convert.ToDateTime(dateTo));

                    con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskMaster taskMaster = new TaskMaster();
                        taskMaster.Task_Id = reader.GetInt32(0);
                        taskMaster.Task_Name = Convert.ToString(reader.GetValue(1));
                        taskMaster.ParentTask_Name = Convert.ToString(reader.GetValue(2));
                        taskMaster.Priority = reader.GetInt32(3);
                        taskMaster.Start_Date = Convert.ToString(reader.GetValue(4));
                        taskMaster.End_Date = Convert.ToString(reader.GetValue(5));
                        lstItem.Add(taskMaster);
                    }
                }
            }
            return lstItem;
        }

        public IList<TaskMaster> GetAllTask()
        {
            IList<TaskMaster> lstItem = new List<TaskMaster>();

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_ALL_TASK_MASTER", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskMaster taskMaster = new TaskMaster();
                        taskMaster.Task_Id = reader.GetInt32(0);
                        taskMaster.Task_Name = Convert.ToString(reader.GetValue(1));
                        taskMaster.ParentTask_Name = Convert.ToString(reader.GetValue(2));
                        taskMaster.Priority = reader.GetInt32(3);
                        taskMaster.Start_Date = Convert.ToString(reader.GetValue(4));
                        taskMaster.End_Date = Convert.ToString(reader.GetValue(5));
                        lstItem.Add(taskMaster);
                    }
                }
            }
            return lstItem;
        }

        public IList<ParentTask> GetParentTaskById(string id)
        {
            IList<ParentTask> lstItem = new List<ParentTask>();

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ParentTask WHERE Parent_ID = @Parent_ID", con))
                {
                    cmd.Parameters.AddWithValue("@Parent_ID", id);

                    con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParentTask task = new ParentTask();
                        task.Parent_Id = reader.GetInt32(0);
                        task.Parent_Task = Convert.ToString(reader.GetValue(1));
                        lstItem.Add(task);
                    }
                }
            }
            return lstItem;
        }

        public IList<Task> GetTaskById(string id)
        {
            IList<Task> lstItem = new List<Task>();

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Task WHERE Task_ID = @Task_ID", con))
                {
                    cmd.Parameters.AddWithValue("@Task_ID", id);

                    con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Task task = new Task();
                        task.Task_Id = reader.GetInt32(0);
                        task.Parent_Id = reader.GetInt32(1);
                        task.Task_Name = Convert.ToString(reader.GetValue(2));
                        task.Start_Date = Convert.ToString(reader.GetValue(3));
                        task.End_Date = Convert.ToString(reader.GetValue(4));
                        task.Priority = reader.GetInt32(5);
                        lstItem.Add(task);
                    }
                }
            }
            return lstItem;
        }

        public int AddParentTask(ParentTask task)
        {
            int affectedRow = 0;

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ParentTask (Parent_Task) VALUES(@Parent_Task)", con))
                {
                    cmd.Parameters.AddWithValue("@Parent_Task", task.Parent_Task);

                    con.Open();
                    affectedRow = cmd.ExecuteNonQuery();
                }
            }
            return affectedRow;
        }

        public int EditParentTask(ParentTask task)
        {
            int affectedRow = 0;

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE ParentTask SET Parent_Task = @Parent_Task WHERE Parent_ID = @Parent_ID", con))
                {
                    cmd.Parameters.AddWithValue("@Parent_ID", task.Parent_Id);
                    cmd.Parameters.AddWithValue("@Parent_Task", task.Parent_Task);

                    con.Open();
                    affectedRow = cmd.ExecuteNonQuery();
                }
            }
            return affectedRow;
        }

        public int AddTask(Task task)
        {
            int affectedRow = 0;

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Task (Parent_ID,Task,Start_Date,END_Date,Priority) VALUES(@Parent_ID,@Task,@Start_Date,@END_Date,@Priority)", con))
                {
                    cmd.Parameters.AddWithValue("@Parent_ID", task.Parent_Id);
                    cmd.Parameters.AddWithValue("@Task", task.Task_Name);
                    cmd.Parameters.AddWithValue("@Start_Date", Convert.ToDateTime(task.Start_Date));
                    cmd.Parameters.AddWithValue("@END_Date", Convert.ToDateTime(task.End_Date));
                    cmd.Parameters.AddWithValue("@Priority", task.Priority);

                    con.Open();
                    affectedRow = cmd.ExecuteNonQuery();
                }
            }
            return affectedRow;
        }

        public int EditTask(Task task)
        {
            int affectedRow = 0;

            using (SqlConnection con = new SqlConnection(TaskManagerDb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Task SET Parent_ID = @Parent_ID,Task = @Task,Start_Date = @Start_Date,END_Date = @END_Date,Priority = @Priority WHERE Task_ID = @Task_ID", con))
                {
                    cmd.Parameters.AddWithValue("@Task_ID", task.Task_Id);
                    cmd.Parameters.AddWithValue("@Parent_ID", task.Parent_Id);
                    cmd.Parameters.AddWithValue("@Task", task.Task_Name);
                    cmd.Parameters.AddWithValue("@Start_Date", Convert.ToDateTime(task.Start_Date));
                    cmd.Parameters.AddWithValue("@END_Date", Convert.ToDateTime(task.End_Date));
                    cmd.Parameters.AddWithValue("@Priority", task.Priority);

                    con.Open();
                    affectedRow = cmd.ExecuteNonQuery();
                }
            }
            return affectedRow;
        }
    }
}
