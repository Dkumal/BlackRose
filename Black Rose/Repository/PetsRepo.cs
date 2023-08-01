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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Black_Rose.Repository
{
    public class PetsRepo
    {
        private IConfiguration configuration;
        private string constring;
        public PetsRepo(IConfiguration iconfig)
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

        public List<PetModel> GetAllPets()
        {
           List<PetModel> data = new List<PetModel>();

            using (IDatabase db = Connection)
            {
                string query = @"select mp.id,
                        concat(mp2.first_name ,' ', mp2.last_name ) as idpemilik, 
                        case when sex  =1 then 'Male' else 'Female' end as sex,
                        mp.jenis ,
                        mp.warna ,
                        mp.umur, 
                        mp.pola , 
                        mc.name  as idklasifikasi,
                        mp.nama
                        from ms_pet mp join ms_patient mp2 on mp.idpemilik = mp2.id 
                        join ms_class mc on mp.idklasifikasi =mc.id ";
                data = db.Fetch<PetModel>(query);
            }

            #region old
            //using (NpgsqlConnection connection = new NpgsqlConnection())
            //{
            //    connection.ConnectionString = constring;
            //    connection.Open();

            //    string query = @"select mp.id,
            //            concat(mp2.first_name ,' ', mp2.last_name ) as idpemilik, 
            //            case when sex  =1 then 'Male' else 'Female' end as sex,
            //            mp.jenis ,
            //            mp.warna ,
            //            mp.umur, 
            //            mp.pola , 
            //            mc.name  as idklasifikasi,
            //            mp.nama
            //            from ms_pet mp join ms_patient mp2 on mp.idpemilik = mp2.id 
            //            join ms_class mc on mp.idklasifikasi =mc.id ";

            //    NpgsqlCommand cmd = new NpgsqlCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;

            //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    cmd.Dispose();
            //    connection.Close();

            //    data = ConvertDataTable<PetModel>(dt);
            //}

            #endregion


            return data;
        }

        public List<PetModel> getPetsWithFilter(string? namahewan, string? klasifikasi, string? pemilik)
        {
            List<PetModel> data = new List<PetModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = @"select mp.id ,
                                mp.nama ,
                                mp.jenis , 
                                concat (mp2.first_name , ' ', mp2.last_name ) as idpemilik 
                                from ms_pet mp 
                                join ms_patient mp2 on mp.idpemilik = mp2.id 
                                where mp.isdelete = 0 ";
                if (!string.IsNullOrEmpty(namahewan))
                {
                    query += " and mp.nama = '" + namahewan + "'";
                }
                if (!string.IsNullOrEmpty(pemilik))
                {
                    query += " and mp.idpemilik = '" + pemilik + "'";
                }
                if (!string.IsNullOrEmpty(klasifikasi))
                {
                    query += " and mp.idklasifikasi = '" + klasifikasi + "'";
                }
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<PetModel>(dt);
            }

            return data;
        }
        public int Upsert(PetModel data)
        {
            int result = 0;
            string query = "";
            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                if (data.id == 0)
                {
                    query = "insert into ms_pet (idpemilik, nama,sex,jenis, warna, pola, idklasifikasi,isdelete) values ('" +
                    data.idpemilik+ "','"+
                    data.nama+ "','" +
                    data.sex+ "','"+
                    data.jenis+ "','"+
                    data.warna+ "','"+
                    data.pola+ "','" +
                    data.idklasifikasi
                    + "',0)";
                }
                else
                {
                    query = "Update ms_pet set idpemilik='" + data.idpemilik+
                        "', sex= '" + data.sex+
                        "', nama= '" + data.nama+
                        "', jenis = '" + data.jenis+
                        "', warna = '" + data.warna+
                        "', pola = '" + data.pola+
                        "', idklasifikasi = '" + data.idklasifikasi+
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
                    
                query = "Update ms_pet set isdelete ='1' where id = " + id;
                
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


        public PetModel GetPet(int id)
        {
            List<PetModel> data = new List<PetModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = @"select mp.id,
                                cast(mp.idpemilik as varchar),
                                cast(mp.sex as varchar),
                                mp.jenis ,
                                mp.warna ,
                                mp.pola , 
                                cast (mp.idklasifikasi as varchar),
                                mp.nama
                                from ms_pet mp  
                                where isdelete = 0 and id='" + id +"'";

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<PetModel>(dt);
            }


            return data.FirstOrDefault();
        }

        
    }
}
