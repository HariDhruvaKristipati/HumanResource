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
  public  class DALPerformance
    {

        Bal.Performance p = new Bal.Performance();

        public int ID { get; set; }

        public void Add_Performance(Performance pr)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Performance_Add", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pr.ID);
            cmd.Parameters.AddWithValue("@EmpName",pr.EmpName);
            cmd.Parameters.AddWithValue("@Division",pr.Division);
            cmd.Parameters.AddWithValue("@EvaluationDate", pr.EvaluationDate);
            cmd.Parameters.AddWithValue("@Evaluator", pr.Evaluator);
            cmd.Parameters.AddWithValue("@EvaluationPeriod",pr.EvaluationPeriod);
            cmd.Parameters.AddWithValue("@SickLeave", pr.SickLeave);
            cmd.Parameters.AddWithValue("@Vacation", pr.Vacation);
            cmd.Parameters.AddWithValue("@Holiday",pr.Holiday);
            cmd.Parameters.AddWithValue("@WorkGroup", pr.WorkGroup);


            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        private static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public void Update_Performance(Performance pr)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Performance_updating", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pr.ID);
            cmd.Parameters.AddWithValue("@EmpName", pr.EmpName);
            cmd.Parameters.AddWithValue("@Division", pr.Division);
            cmd.Parameters.AddWithValue("@EvaluationDate", pr.EvaluationDate);
            cmd.Parameters.AddWithValue("@Evaluator", pr.Evaluator);
            cmd.Parameters.AddWithValue("@EvaluationPeriod", pr.EvaluationPeriod);
            cmd.Parameters.AddWithValue("@SickLeave", pr.SickLeave);
            cmd.Parameters.AddWithValue("@Vacation", pr.Vacation);
            cmd.Parameters.AddWithValue("@Holiday", pr.Holiday);
            cmd.Parameters.AddWithValue("@WorkGroup", pr.WorkGroup);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }


        public List<Performance> Show_Performance()
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Show_Performance] ()", con2);
            con2.Open();
            // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader datareader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datareader);
            con2.Close();
            List<Performance> li = new List<Performance>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Performance b = new Performance();
                b.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                b.EmpName = dt.Rows[i]["EmpName"].ToString();
                b.Division= dt.Rows[i]["Division"].ToString();
                b.WorkGroup = dt.Rows[i]["WorkGroup"].ToString();
                b.EvaluationDate = Convert.ToDateTime(dt.Rows[i]["EvaluationDate"]);
                b.Evaluator = dt.Rows[i]["Evaluator"].ToString();
                b.EvaluationPeriod = Convert.ToInt32(dt.Rows[i]["EvaluationPeriod"]);
                b.SickLeave = Convert.ToDateTime(dt.Rows[i]["SickLeave"]);
                b.Vacation = Convert.ToDateTime(dt.Rows[i]["Vacation"]);
                b.Holiday = Convert.ToDateTime(dt.Rows[i]["Holiday"]);



                li.Add(b);


            }
            return li;

        }

        public void Delete_Performance(int id)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("Performance_Deleting", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }
    }
}


