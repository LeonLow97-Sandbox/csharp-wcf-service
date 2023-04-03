using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfDatabaseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCNAME;Initial Catalog=wcftestdb;User ID=lowjiewei;Password=password;");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RegistrationTable(UserName, Password, Country, Email) VALUES (@UserName, @Password, @Country, @Email)", con);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@Country", userInfo.Country);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = userInfo.UserName + " Details inserted successfully!";
            } else
            {
                Message = userInfo.UserName + " Details not inserted...";
            }
            con.Close();
            return Message;
        }
    }
}
