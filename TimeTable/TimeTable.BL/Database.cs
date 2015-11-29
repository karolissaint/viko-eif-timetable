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

        #region Cabinet methods, "code" i mean cabinet number, can be with letters less than 4 symbols ex.: 209A
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
                        code = reader[1].ToString()
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
            if (code.Length > 4) throw new Exception("Cabinet code must be from 1 to 4 numbers or letters");
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
        #region Group methods, "code" - IR14B - less than 5 symbols, "title" - Išmanieji irenginiai - less than 40 symbols
        public static List<Group> getGroups()
        {
            List<Group> groups = new List<Group>();
            SqlCommand cmd = new SqlCommand("select * from [Group]", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    groups.Add(new Group()
                    {
                        id = Convert.ToInt32(reader[0]),
                        title = reader[1].ToString(),
                        code = reader[2].ToString()
                    }
                    );
                }
            }
            return groups;
        }
        public static bool isGroupExist(string code)
        {
            SqlCommand cmd = new SqlCommand("select Code from [Group] where Code = @code", conn);
            cmd.Parameters.AddWithValue("@code", code);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()) return true;
            }
            return false;
        }
        public static bool isGroupParamsGood(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new Exception("Group code can't be empty");
            if (code.Length > 5) throw new Exception("Group code must be from 1 to 4 numbers or letters");
            return true;
        }
        public static bool isGroupParamsGood(string code, string title)
        {
            if (string.IsNullOrEmpty(code)) throw new Exception("Group code can't be empty");
            if (code.Length > 5) throw new Exception("Group code must be from 1 to 4 numbers or letters");
            if (string.IsNullOrWhiteSpace(title)) throw new Exception("Group title can't be empty");
            if (title.Length > 40) throw new Exception("Group title must be from 1 to 40 numbers or letters");
            return true;
        }
        public static void insertGroup(string code, string title)
        {
            if (!isGroupExist(code) && isGroupParamsGood(code, title))
            {
                SqlCommand cmd = new SqlCommand("insert into [Group](Title, Code) values(@title, @code)", conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.ExecuteNonQuery();
            }
        }
        public static void updateGroup(string currentCode, string updateCode, string title)
        {
            if (isGroupExist(currentCode))
            {
                if (title == null || title == "")
                {
                    if (isGroupParamsGood(updateCode))
                    {
                        SqlCommand cmd = new SqlCommand("update [Group] set Code = @updateCode where Code = @currentCode", conn);
                        cmd.Parameters.AddWithValue("@currentCode", currentCode);
                        cmd.Parameters.AddWithValue("@updateCode", updateCode);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (isGroupParamsGood(updateCode, title))
                    {
                        SqlCommand cmd = new SqlCommand("update [Group] set Title = @title, Code = @updateCode where Code = @currentCode", conn);
                        cmd.Parameters.AddWithValue("@currentCode", currentCode);
                        cmd.Parameters.AddWithValue("@updateCode", updateCode);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public static void removeGroup(string code)
        {
            if (isGroupExist(code))
            {
                SqlCommand cmd = new SqlCommand("delete from [Group] where Code = @code", conn);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }

    public class Group
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
    }
    public class Cabinet
    {
        public int id { get; set; }
        public string code { get; set; }
    }
}
