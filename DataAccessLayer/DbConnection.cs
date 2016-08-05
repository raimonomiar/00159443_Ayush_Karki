using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntityLayer;
namespace DataAccessLayer
{
    public class DbConnection
    {


        //database connection
        public SqlConnection connect;

        public SqlConnection db()
        {
            string cd = "data source =ACER\\SQLEXPRESS; uid=sa;pwd=ayushs; database=BookStore";
            connect = new SqlConnection(cd);
            return connect;
        }

        //Store registration detail in database

        public int insertData(UserInfo ui)
        {
            try
            {
                db();
                connect.Open();
                SqlCommand cmd = new SqlCommand("insertUser", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", ui.username);
                cmd.Parameters.AddWithValue("@first_name", ui.first_name);
                cmd.Parameters.AddWithValue("@last_name", ui.last_name);
                cmd.Parameters.AddWithValue("@address", ui.address);
                cmd.Parameters.AddWithValue("@phone_no", ui.phone_no);
                cmd.Parameters.AddWithValue("@gender", ui.gender);
                cmd.Parameters.AddWithValue("@email", ui.email);
                cmd.Parameters.AddWithValue("@password", ui.password);
                cmd.Parameters.AddWithValue("@dob", ui.dob);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong!!" + e.Message);
            }
        }

        //getting user authentication info from database

        public int getUserAuthentication(UserInfo ui)
        {
            try
            {

                db();
                connect.Open();
                var cmd = new SqlCommand("userauthentication", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", ui.username);
                cmd.Parameters.AddWithValue("@password", ui.password);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                return count;

            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong" + e.Message);
            }
        }

    }
}
