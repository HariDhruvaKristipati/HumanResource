using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bal;

namespace Dal
{
    public class DALTraining
    {
        Bal.Training p = new Bal.Training();

        public int ID { get; set; }

        public void Add_Training(Training train)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Add_TrainingTable", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", train.ID);
            cmd.Parameters.AddWithValue("@TrainingName", train.TrainingName);
            cmd.Parameters.AddWithValue("@TrainingStatus", train.TrainingStatus);
            cmd.Parameters.AddWithValue("@TrainingPeriod", train.TrainingPeriod);
            cmd.Parameters.AddWithValue("@TrainingExp", train.TrainingExp);
            cmd.Parameters.AddWithValue("@PrevEmpExp", train.PrevEmpExp);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        private static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public void Update_Training(Training train)      
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("TrainingTable_updating", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", train.ID);
            cmd.Parameters.AddWithValue("@TrainingName", train.TrainingName);
            cmd.Parameters.AddWithValue("@TrainingStatus", train.TrainingStatus);
            cmd.Parameters.AddWithValue("@TrainingPeriod", train.TrainingPeriod);
            cmd.Parameters.AddWithValue("@TrainingExp", train.TrainingExp);
            cmd.Parameters.AddWithValue("@PrevEmpExp", train.PrevEmpExp);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }


        public List <Training> Show_Training()
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Show_Training] ()", con2);
            con2.Open();
           // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader datareader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datareader);
            con2.Close();
            List<Training> li = new List<Training>();
            for(int i=0; i<dt.Rows.Count;i++)
            {
                Training b = new Training();
                b.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                b.TrainingName = dt.Rows[i]["TrainingName"].ToString();
                b.TrainingStatus = dt.Rows[i]["TrainingStatus"].ToString();
                b.TrainingPeriod = Convert.ToInt32(dt.Rows[i]["TrainingPeriod"]);
                b.TrainingExp= Convert.ToInt32(dt.Rows[i]["TrainingExp"]);
                b.PrevEmpExp= Convert.ToInt32(dt.Rows[i]["PrevEmpExp"]);
                li.Add(b);


            }
            return li ;

        }

        public void Delete_Training(int id)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            
            SqlCommand cmd = new SqlCommand("TrainingTable_Deleting", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }
    }
}

  
