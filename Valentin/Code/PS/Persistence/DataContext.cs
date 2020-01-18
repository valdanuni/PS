using System;
using System.Data.Linq;

namespace PS.Persistence
{
    public static class DataContext
    {

        public static string GetDatabaseConnectionString()
        {
            return @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        }

        public static T Get<T>(Func<PersistenceClassesDataContext, T> dataContextAction)
        {
            using (PersistenceClassesDataContext dataContext = new PersistenceClassesDataContext(GetDatabaseConnectionString()))
            {
                return dataContextAction(dataContext);
            }
        }
        public static void Execute(Action<PersistenceClassesDataContext> dataContextAction)
        {
            using (PersistenceClassesDataContext dataContext = new PersistenceClassesDataContext(GetDatabaseConnectionString()))
            {
                dataContextAction(dataContext);
            }
        }
    }
}