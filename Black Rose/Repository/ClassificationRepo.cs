using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPoco;
using Npgsql;
using Black_Rose.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

namespace Black_Rose.Repository
{
    public class ClassificationRepo
    {
        private IConfiguration configuration;
        private string constring;
        public ClassificationRepo(IConfiguration iconfig)
        {
            configuration = iconfig;
            constring = configuration.GetSection("Settings").GetSection("constring").Value;
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

        public List<ClassificationModel> GetAllClassification()
        {
           List<ClassificationModel> data = new List<ClassificationModel>();
            
           using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = "select * from ms_class where isdelete = 0";

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<ClassificationModel>(dt);
            }
            
           


            return data;
        }

        public int Upsert(ClassificationModel data)
        {
            int result = 0;
            string query = "";
            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                if (data.id == 0)
                {
                    query = "insert into ms_class (name, description,isDelete) values ('" +
                    data.name+ "','"
                    + data.description
                    + "',0)";
                }
                else
                {
                    query = "Update ms_patient set name ='" + data.name +
                        "', description = '" + data.description +
                        "' where id = " + data.id;
                }
                
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

        public int delete(int id)
        {
            int result = 0;
            string query = "";
            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();
                    
                query = "Update ms_class set isdelete ='1' where id = " + id;
                
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


        public ClassificationModel GetClassification(int id)
        {
            List<ClassificationModel> data = new List<ClassificationModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = @"SELECT id, 
                                name, 
                                description, 
                                isdelete " +
                                "FROM ms_class" +
                                " where isdelete = 0 and id='" + id +"'";

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<ClassificationModel>(dt);
            }


            return data.FirstOrDefault();
        }

    }
}
