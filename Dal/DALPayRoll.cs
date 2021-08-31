using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bal;



namespace Dal
{
  public  class DALPayRoll
    {
        //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        Bal.PayRoll p=new Bal.PayRoll();

        public IEnumerable<object> PayRoll { get; set; }

        public List<PayRoll> Show_PayRoll()
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Show_PayRoll] ()", con2);
            con2.Open();
            // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader datareader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datareader);
            con2.Close();
            List<PayRoll> li = new List<PayRoll>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PayRoll b = new PayRoll();
                b.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                b.BasicPay = Convert.ToDecimal(dt.Rows[i]["Basicpay"]);
                b.Allowances = Convert.ToDecimal(dt.Rows[i]["Allowances"]);
                b.Deductions = Convert.ToDecimal(dt.Rows[i]["Deductions"]);
                b.GrossPay = Convert.ToDecimal(dt.Rows[i]["GrossPay"]);
                b.NetPay = Convert.ToDecimal(dt.Rows[i]["NetPay"]);
                li.Add(b);


            }
            return li;

        }



        public void Add_PayRoll(PayRoll pay)
        {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("payRoll_Add", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pay.ID);
            cmd.Parameters.AddWithValue("@BasicPay", pay.BasicPay);
            cmd.Parameters.AddWithValue("@Allowances", pay.Allowances);
            cmd.Parameters.AddWithValue("@Deductions", pay.Deductions);
            cmd.Parameters.AddWithValue("@GrossPay", pay.GrossPay);
            cmd.Parameters.AddWithValue("@NetPay", pay.NetPay);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        private static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public void Update_PayRoll(PayRoll pay)
          {

            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("payRoll_updating", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pay.ID);
            cmd.Parameters.AddWithValue("@BasicPay", pay.BasicPay);
            cmd.Parameters.AddWithValue("@Allowances", pay.Allowances);
            cmd.Parameters.AddWithValue("@Deductions", pay.Deductions);
            cmd.Parameters.AddWithValue("@GrossPay", pay.GrossPay);
            cmd.Parameters.AddWithValue("@NetPay", pay.NetPay);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

         }


    

       public void Delete_PayRoll(int id)
         {
            SqlConnection con2 = new SqlConnection("Data Source=WIN-K9JM7C2EKKD;Initial Catalog=HRMS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("PayRoll_Deleting", con2);
            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ID",id);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

         }
    }
}
