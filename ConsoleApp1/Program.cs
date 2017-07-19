using Dapper;
using DapperExtensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Dapper.SqlMapper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string a = Sb().a;
            string b = Sb().b;
            string c = Sb().c;
            IDbConnection connection = new SqlConnection("Data Source=.;Initial Catalog=drapper;Integrated Security=True;MultipleActiveResultSets=True");

            var result = connection.Execute("Insert into Users values (@UserName, @Email, @Address)",
                                   new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });


            using (connection)
            {
                // 事务
                IDbTransaction db = connection.BeginTransaction();

                db.Commit();
                db.Rollback();

                var pred = Predicates.Field<Person>(f => f.LastName, Operator.Like, "2312313", false);
                var count = connection.Count<Person>(pred);


                string sql2 = "";
                GridReader multiReader =connection.QueryMultiple(sql2);
                IEnumerable<Man> man= multiReader.Read<Man>();
                IEnumerable<Person> person = multiReader.Read<Person>();
            }


            string sql = "sdfasd";
            var dd = connection.Query<Man, Person, Man>(sql, (m, p) => { return m; }, null, null, false, null, 20, null);

           // var q1 = connection.Query<Man, Person, Man>(sql,(m,p)=> { return });

        }

        public static (string a, string b, string c) Sb()
        {
            return ("a", "b", "c");
        }
    }
}
