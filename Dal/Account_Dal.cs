using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Bal;

namespace Dal
{
    public class Account_Dal
    {
        public Boolean Login(int id, string password)
        {
            string cnstring = "Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnstring);
            SqlCommand cmd = new SqlCommand("SELECT [dbo].[Verifyuser] (@userid,@password)", cn);
            cmd.Parameters.AddWithValue("@userid", id);
            cmd.Parameters.AddWithValue("@password", password);
            cn.Open();
            bool status = false;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (Convert.ToInt32(dr[0]) == 1)
                {
                    status = true;
                }
            }

            return status;
        }

    }
}
        
    

