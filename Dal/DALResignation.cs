using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Bal;



namespace Dal
{
   public class DALResignation
    {

        Bal.Resignation p = new Bal.Resignation();

        public int ID { get; set; }

        public void Add_Resignation(Resignation resign)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Resignation_Add", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", resign.ID);
            cmd.Parameters.AddWithValue("@DeptName", resign.DeptName);
            cmd.Parameters.AddWithValue("@DeptPosition", resign.DeptPosition);
            cmd.Parameters.AddWithValue("@JoiningDate", resign.JoiningDate);
            cmd.Parameters.AddWithValue("@ResignationDate", resign.ResignationDate);
            cmd.Parameters.AddWithValue("@ContactNumber", resign.ContactNumber);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        private static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public void Update_Resignation(Resignation resign)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Resignation_Updating", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", resign.ID);
            cmd.Parameters.AddWithValue("@DeptName", resign.DeptName);
            cmd.Parameters.AddWithValue("@DeptPosition", resign.DeptPosition);
            cmd.Parameters.AddWithValue("@JoiningDate", resign.JoiningDate);
            cmd.Parameters.AddWithValue("@ResignationDate", resign.ResignationDate);
            cmd.Parameters.AddWithValue("@ContactNumber", resign.ContactNumber);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }


        public List<Resignation> Show_Resignation()
        {
            SqlConnection con2= new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Show_Resignation] ()", con2);
            con2.Open();
            // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader datareader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datareader);
            con2.Close();
            List<Resignation> li = new List<Resignation>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Resignation b = new Resignation();
                b.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                b.DeptName = dt.Rows[i]["DeptName"].ToString();
                b.DeptPosition = dt.Rows[i]["DeptPosition"].ToString();
                b.JoiningDate = Convert.ToDateTime(dt.Rows[i]["JoiningDate"]);
                b.ResignationDate = Convert.ToDateTime(dt.Rows[i]["ResignationDate"]);
                b.ContactNumber = Convert.ToInt32(dt.Rows[i]["ContactNumber"]);
                li.Add(b);


            }
            return li;

        }

        public void Delete_Resignation(int id)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("Resignation_Deleting", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

        }
    }
}

  

    

