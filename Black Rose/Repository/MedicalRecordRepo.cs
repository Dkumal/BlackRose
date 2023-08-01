using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Black_Rose.Models;

namespace Black_Rose.Repository
{
    public class MedicalRecordRepo
    {
        private IConfiguration configuration;
        private string constring;
        public MedicalRecordRepo(IConfiguration iconfig)
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
                                where mp.isdelete = 0 and mp2.isdelete=0";
                if(!string.IsNullOrEmpty(namahewan))
                {
                    query += " and mp.nama = '" + namahewan + "'";
                }
                if (!string.IsNullOrEmpty(pemilik))
                {
                    query += " and mp.idpemilik = '" + pemilik + "'";
                }
                if (!string.IsNullOrEmpty(klasifikasi))
                {
                    query += " and mp.idklasifikasi = '" + klasifikasi+ "'";
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

        public int Save(ExaminationFormModel data)
        {
            int result = 0;

            string query = "";
            query = @"insert into t_examination (idhewan,
                        iddokter,
                        examdate,
                        age, 
                        weight,
                        temperature,
                        bodyscore,
                        eating,
                        drinking,
                        coughing, 
                        sneezing, 
                        diarhea, 
                        healthconcern, 
                        physicalexam, 
                        need, 
                        service,
                        lastmedication,
                        therapy,
                        diagnose) values('" 
                + data.idhewan + "','" +
                data.iddokter + "',now(),'" 
                + data.age + "','" 
                + data.weight + "','" 
                + data.temperature + "','" +
                data.bodyscore + "','" 
                + data.eating + "','" 
                + data.drinking + "','" 
                + data.coughing + "','" +
                data.sneezing + "','" 
                + data.diarhea+ "','"
                + data.healthconcern + "','" 
                + data.physicalexam + "','" 
                + data.need
                + "','" + data.service + "','" 
                + data.lastmedication +"','" 
                + data.therapy + "','"
                + data.diagnose +
                "')";

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                try{
                    cmd.ExecuteNonQuery();

                }
                catch(Exception ex)
                {
                    result = 0;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();

                    result = 1;
                }
               
            }


                return result;
        }

        public ExamDataModel GetPetData(int id)
        {
            List<ExamDataModel> data = new List<ExamDataModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = @"SELECT
                                concat(pasien.first_name,' ', pasien.last_name) as owner,
                                mp.id as idhewan,mp.nama as namahewan,mc.description as species,mp.jenis as breed,
                                case when  mp.sex  = 1 then 'Male' else 'Female' end as sex
                                FROM public.ms_patient pasien 
                                join ms_pet mp on mp.idpemilik = pasien.id 
                                join ms_class mc on mp.idklasifikasi = mc.id 
                                where mp.isdelete = 0 and mp.id='" + id + "'";

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<ExamDataModel>(dt);
            }


            return data.FirstOrDefault();
        }

        public List<ExaminationFormModel> getHistorybyPets(int IDHewan)
        {
            List<ExaminationFormModel> data = new List<ExaminationFormModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = @"select date(examdate) as examdate ,iddokter ,weight ,age ,diagnose ,therapy,id 
                                from t_examination te 
                                where isdelete = 0 and idhewan = '" + IDHewan + "'";
                                
                
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<ExaminationFormModel>(dt);
            }

            return data;
        }

        public ExaminationFormLoadModel getExamRecordHistoryByID(int IDMedRec)
        {
            List<ExaminationFormLoadModel> data = new List<ExaminationFormLoadModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();

                string query = @"select date(examdate) as examdate ,id, idhewan,iddokter,
                                age, weight,temperature, bodyscore,
                                eating, drinking, coughing, sneezing, diarhea, 
                                healthconcern, physicalexam, need, service,
                                lastmedication, therapy, diagnose, mu.fullname as namadokter
                                from t_examination te join ms_user mu 
                                    on te.iddokter =mu.id  
                                where isdelete = 0 and idhewan = '" + IDMedRec + "'";


                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                connection.Close();

                data = ConvertDataTable<ExaminationFormLoadModel>(dt);
            }

            return data.FirstOrDefault();
        }
    }
}
