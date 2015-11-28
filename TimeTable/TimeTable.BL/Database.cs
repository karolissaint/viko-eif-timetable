using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TimeTable.BL
{
    public static class Database
    {
        public static SqlConnection conn = new SqlConnection(@"Server = .\SQLExpress; Database = timeTableDb; Trusted_Connection = True;");

        #region Cabinet methords
        public static List<Cabinet> getCabinets()
        {
            List<Cabinet> cabinets = new List<Cabinet>();
            SqlCommand cmd = new SqlCommand("select * from Cabinet", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cabinets.Add(new Cabinet()
                    {
                        id = Convert.ToInt32(reader[0]),
                        title = reader[1].ToString()
                    }
                    );
                }
            }
            return cabinets;
        }
        public static bool isCabinetExist(string code)
        {
            SqlCommand cmd = new SqlCommand("select Code from Cabinet where Code = @code", conn);
            cmd.Parameters.AddWithValue("@code", code);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()) return true;
            }
            return false;
        }
        public static bool isCabinetParamsGood(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new Exception("Cabinet code can't be empty");
            if (code.Length >= 4) throw new Exception("Cabinet code must be from 1 to 4 numbers or letters");
            return true;
        }
        public static void insertCabinet(string code)
        {
            if (!isCabinetExist(code) && isCabinetParamsGood(code))
            {
                SqlCommand cmd = new SqlCommand("insert into Cabinet(Code) values(@code)", conn);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.ExecuteNonQuery();
            }
        }
        public static void updateCabinet(string currentCode, string updateCode)
        {
            if(isCabinetExist(currentCode) && isCabinetParamsGood(updateCode))
            {
                SqlCommand cmd = new SqlCommand("update Cabinet set Code = @updateCode where Code = @currentCode", conn);
                cmd.Parameters.AddWithValue("@currentCode", currentCode);
                cmd.Parameters.AddWithValue("@updateCode", updateCode);
                cmd.ExecuteNonQuery();
            }
        }
        public static void removeCabinet(string code)
        {
            if(isCabinetExist(code))
            {
                SqlCommand cmd = new SqlCommand("delete from Cabinet where Code = @code", conn);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }

    public class Cabinet
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
