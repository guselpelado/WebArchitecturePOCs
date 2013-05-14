using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace nh_stored_proc_calls
{
    public class StoredProcCommandBuilder<T>
    {

        public StoredProcCommandBuilder(string spName)
        {
            _sql = string.Format("EXEC {0}", spName);

            const string cnn = "Server=(local);initial catalog=mandero;Integrated Security=True;";


            var sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(cnn).ShowSql())
                .CurrentSessionContext<CallSessionContext>()
                .Mappings(ConfigureMappings).BuildConfiguration().BuildSessionFactory();

            session = sessionFactory.OpenSession();
        }



        private IList<string> _parameterlist = new List<string>();
        private string _storedProcName;
        private string _sql;
        private ISession session;



  



     

        private static void ConfigureMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<Program>();


        }


    }
}