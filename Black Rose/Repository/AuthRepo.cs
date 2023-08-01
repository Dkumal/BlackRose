using Black_Rose.helper;
using Black_Rose.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Black_Rose.Repository
{
    public class AuthRepo
    {
        private IConfiguration configuration;
        private string constring;
        private EncDec encDec;
        public AuthRepo(IConfiguration iconfig)
        {
            configuration = iconfig;
            constring = configuration.GetSection("Settings").GetSection("constring").Value;
            encDec = new EncDec(configuration);
        }

        public IDatabase Connection
        {
            get
            {
                return new Database(constring, DatabaseType.PostgreSQL, NpgsqlFactory.Instance);
            }
        }

        private List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public int ValidateUser (string user, string password)
        {
            int resultValidate = 0;

            List<UserModels> data = new List<UserModels>();
            password = encDec.enc(password);
            using (IDatabase db = Connection)
            {
                string query = "SELECT id, username, password, fullname, roleid, isdelete " +
                                "FROM public.ms_user " +
                                " where isdelete = 0 and username='" + user + "' and password ='" + password +"'";
                data = db.Fetch<UserModels>(query);
            }

            if (data.Count > 0)
            {
                resultValidate = data.FirstOrDefault().roleid;
            }
            return resultValidate;
        }
    }
}
