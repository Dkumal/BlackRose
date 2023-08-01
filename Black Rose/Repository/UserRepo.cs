using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPoco;
using Black_Rose;
using Black_Rose.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using System.Data.Common;
using Npgsql;

namespace Black_Rose.Repository
{
    public class UserRepo
    {
        private IConfiguration configuration;
        private string constring;
        public UserRepo(IConfiguration iconfig)
        {
            configuration = iconfig;
            constring = configuration.GetSection("Settings").GetSection("constring").Value;
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

        public List<UserModels> GetAllUser()
        {
           List<UserModels> data = new List<UserModels>();

           using (IDatabase db = Connection)
            {
                string query = "select * from ms_user where isdelete = 0 order by id asc";
                data = db.Fetch<UserModels>(query);
            }

            return data;
        }

        public int Upsert(UserModels data)
        {
            int result = 0;
            string query = "";
            using (IDatabase db = Connection)
            {
                db.Save<UserModels>(data);
                result = 1;
            }
            return result;
        }

        public int delete(int id)
        {
            int result = 0;
            string query = "";
            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();
                    
                query = "Update ms_user set isdelete ='1' where id = " + id;
                
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                connection.Close();

                result = 1;
            }

            return result;
        }


        public UserModels GetUser(int id)
        {
            List<UserModels> data = new List<UserModels>();

            using (IDatabase db = Connection)
            {
                string query = "SELECT id, username, password, fullname, roleid, isdelete " +
                                "FROM public.ms_user " +
                                " where isdelete = 0 and id='" + id + "'";
                data = db.Fetch<UserModels>(query);
            }


            #region old
            //using (NpgsqlConnection connection = new NpgsqlConnection())
            //{
            //    connection.ConnectionString = constring;
            //    connection.Open();

            //    string query = "SELECT id, username, password, fullname, roleid, isdelete " +
            //                    "FROM public.ms_user " +
            //                    " where isdelete = 0 and id='" + id +"'";

            //    NpgsqlCommand cmd = new NpgsqlCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;

            //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    cmd.Dispose();
            //    connection.Close();

            //    data = ConvertDataTable<UserModels>(dt);
            //}

            #endregion
            return data.FirstOrDefault();
        }

    }
}
