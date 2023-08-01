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
using Black_Rose.helper;

namespace Black_Rose.Repository
{
    public class PatientRepo
    {
        private IConfiguration configuration;
        private string constring;
        private EncDec EncDec;
        public PatientRepo(IConfiguration iconfig)
        {
            configuration = iconfig;
            constring = configuration.GetSection("Settings").GetSection("constring").Value;
            EncDec = new EncDec(configuration);
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

        public List<PatientModel> GetAllPatients()
        {
           List<PatientModel> data = new List<PatientModel>();

            using (IDatabase db = EncDec.Connection)
            {
                string query = "select * from ms_patient where isdelete = 0 order by id asc";
                data = db.Fetch<PatientModel>(query);
            }

            #region old
            //using (NpgsqlConnection connection = new NpgsqlConnection())
            //{
            //    connection.ConnectionString = constring;
            //    connection.Open();

            //    string query = "select * from ms_patient where isdelete = 0";

            //    NpgsqlCommand cmd = new NpgsqlCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;

            //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    cmd.Dispose();
            //    connection.Close();

            //    data = ConvertDataTable<PatientModel>(dt);
            //}

            #endregion


            return data;
        }

        public int Upsert(PatientModel data)
        {
            int result = 0;
            string query = "";

            using (IDatabase db = EncDec.Connection)
            {
                db.Save<PatientModel>(data);
                result = 1;
            }

            #region old
            //using (NpgsqlConnection connection = new NpgsqlConnection())
            //{
            //    connection.ConnectionString = constring;
            //    connection.Open();

            //    if (data.id == 0)
            //    {
            //        query = "insert into ms_patient (first_name, last_name, address, email, phone, ktp, isDelete) values ('" +
            //        data.first_name + "','" 
            //        + data.last_name + "','" 
            //        + data.address + "','" 
            //        + data.email + "','" 
            //        + data.phone + "','" 
            //        + data.ktp
            //        + "',0)";
            //    }
            //    else
            //    {
            //        query = "Update ms_patient set first_name ='" + data.first_name +
            //            "', last_name = '" + data.last_name +
            //            "', address = '" + data.address +
            //            "', email = '" + data.email +
            //            "', phone = '" + data.phone +
            //            "',ktp ='" + data.ktp +
            //            "' where id = " + data.id;
            //    }

            //    NpgsqlCommand cmd = new NpgsqlCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery();

            //    cmd.Dispose();
            //    connection.Close();

            //    result = 1;
            //}
            #endregion

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
                    
                query = "Update ms_patient set isdelete ='1' where id = " + id;
                
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


        public PatientModel GetPatient(int id)
        {
            List<PatientModel> data = new List<PatientModel>();

            using(IDatabase db = EncDec.Connection)
            {
                string query = @"SELECT id, 
                                first_name, 
                                last_name, 
                                address, 
                                email, 
                                phone, 
                                ktp, 
                                isdelete " +
                                "FROM public.ms_patient " +
                                " where isdelete = 0 and id='" + id + "'";
                data = db.Fetch<PatientModel>(query);
            }

            #region old
            //using (NpgsqlConnection connection = new NpgsqlConnection())
            //{
            //    connection.ConnectionString = constring;
            //    connection.Open();

            //    string query = @"SELECT id, 
            //                    first_name, 
            //                    last_name, 
            //                    address, 
            //                    email, 
            //                    phone, 
            //                    ktp, 
            //                    isdelete " +
            //                    "FROM public.ms_patient " +
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

            //    data = ConvertDataTable<PatientModel>(dt);
            //}
            #endregion

            return data.FirstOrDefault();
        }

    }
}
