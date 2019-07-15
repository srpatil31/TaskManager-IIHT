using System.Configuration;

namespace TaskManagerDal
{
    public static class TaskManagerDb
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TaskManagerDb"].ConnectionString;
            }
        }
    }
}
