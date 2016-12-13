using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Dal
{
    public class TestDal
    {
        public static string ConnectionStr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVER=orcl)(SERVICE_NAME=orcl)));User Id=g_jcw;Password=g_jcw;";
        public static PetaPoco.Database GetDatabase()
        {
            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(ConnectionStr);
            connection.Open();
            return new PetaPoco.Database(connection);
        }

        public static bool InsertData(TestModel test)
        {
            var database = GetDatabase();

            database.Insert(test);

            database.Connection.Close();

            return true;
        }
        public static bool UpdateData(TestModel test)
        {
            var database = GetDatabase();

            database.Update(test);

            database.Connection.Close();

            return true;
        }

        public static TestModel GetTestModelById(string id)
        {
            var database = GetDatabase();

            var result = database.FirstOrDefault<TestModel>("select * from test where id=@0", id);

            database.Connection.Close();

            return result;
        }

        public static List<TestModel> GetTestList()
        {
            var database = GetDatabase();

            var result = database.Query<TestModel>("select * from test").ToList();

            database.Connection.Close();

            return result;
        }
    }
}