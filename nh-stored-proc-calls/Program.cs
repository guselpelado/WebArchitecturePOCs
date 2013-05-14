using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace nh_stored_proc_calls
{


    public static class Extensions
    {


        public static IList<T> ExecStoredProc<T>(this ISession session, string storedProcName)
        {


            var sql = string.Format("EXEC {0}", storedProcName);
            return session
               .CreateSQLQuery(sql)
               .AddEntity(typeof(T))
               .List<T>();

        }

        public static ISQLQuery StoredProc<T>(this ISession session, string storedProcName, IList<string> parameternames)
        {
            // const string sql = "EXEC [dbo].[Stored_Procedure_Name] @PortalId=:PortalId, @LocaleId=:LocaleId";
            var sb = new StringBuilder();
            var count = parameternames.Count;
            for (int i = 0; i < count; i++)
            {
                if (i != count - 1)
                {
                    sb.AppendFormat("@{0}=:{0}, ", parameternames.ElementAt(i));

                }
                else
                {
                    sb.AppendFormat("@{0}=:{0}", parameternames.ElementAt(i));
                }
            }


            var sql = string.Format("EXEC {0} {1}", storedProcName, sb);



            //var sql = string.Format("EXEC {0}", storedProcName);
            //return session
            //   .CreateSQLQuery(sql)
            //   .AddEntity(typeof(T))
            //   .List<T>();





            return session.CreateSQLQuery(sql)
                .AddEntity(typeof(T));
            //  .SetInt32("PortalId", portalId)
            // .SetInt32("LocaleId", localeId)
            // .List<T>();


        }

        public static IList<T> Exec<T>(this IQuery query)
        {
            return query.List<T>();
        }



    }


    class Program
    {
        static void Main(string[] args)
        {


            var cnn = "Server=(local);initial catalog=mandero;Integrated Security=True;";


            var sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(cnn).ShowSql())
                .CurrentSessionContext<CallSessionContext>()
                .Mappings(ConfigureMappings).BuildConfiguration().BuildSessionFactory();

            var session = sessionFactory.OpenSession();


            //var result = session.ExecStoredProc<UserProfile>("getallusers");


            //foreach (var userProfile in result)
            //{
            //    Console.WriteLine(userProfile.Name);
            //}

            //Console.Read();



            var singleUser = session.StoredProc<UserProfile>("getuser", new List<string>() { "id" }).SetInt32("id", 1).Exec<UserProfile>().FirstOrDefault();



            if (singleUser != null)
            {
                Console.WriteLine(singleUser.Id);
                Console.WriteLine(singleUser.Name);
                Console.WriteLine(singleUser.Apellido);
                Console.WriteLine(singleUser.UserName);

            }

            Console.Read();

        }


        private static void ConfigureMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<Program>();


        }


    }



}
