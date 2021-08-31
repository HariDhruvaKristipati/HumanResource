using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bal;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Dal
{
  public  class DALResumeTracking
    {
        Bal.ResumeTracking p = new Bal.ResumeTracking();

        public int ID { get; set; }

        public void Add_ResumeTracking(ResumeTracking resume)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ResumeTracking_Add", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", resume.ID);
            cmd.Parameters.AddWithValue("@Curriculam", resume.Curriculam);
            cmd.Parameters.AddWithValue("@WorkExperience", resume.WorkExperience);
            cmd.Parameters.AddWithValue("@AreaOfSpecialization", resume.AreaOfSpecialization);
            cmd.Parameters.AddWithValue("@AreaOfInterest", resume.AreaOfInterest);
            cmd.Parameters.AddWithValue("@Contact", resume.Contact);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        private static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public void Update_ResumeTracking(ResumeTracking resume)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ResumeTracking_updating", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", resume.ID);
            cmd.Parameters.AddWithValue("@Curriculam", resume.Curriculam);
            cmd.Parameters.AddWithValue("@WorkExperience", resume.WorkExperience);
            cmd.Parameters.AddWithValue("@AreaOfSpecialization", resume.AreaOfSpecialization);
            cmd.Parameters.AddWithValue("@AreaOfInterest", resume.AreaOfInterest);
            cmd.Parameters.AddWithValue("@Contact", resume.Contact);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }


        public List<ResumeTracking> Show_ResumeTracking()
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Show_ResumeTracking] ()", con2);
            con2.Open();
            // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader datareader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datareader);
            con2.Close();
            List<ResumeTracking> li = new List<ResumeTracking>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ResumeTracking b = new ResumeTracking();
                b.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                b.Curriculam = dt.Rows[i]["Curriculam"].ToString();
                b.WorkExperience = dt.Rows[i]["WorkExperience"].ToString();
                b.AreaOfSpecialization= dt.Rows[i]["AreaOfSpecialization"].ToString();
                b.AreaOfInterest = dt.Rows[i]["AreaOfInterest"].ToString();
                b.Contact = Convert.ToInt32(dt.Rows[i]["Contact"]);
                li.Add(b);


            }
            return li;

        }

        public void Delete_ResumeTracking(int id)
        {
            SqlConnection con2= new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("ResumeTracking_Deleting", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }
    }
}

  

