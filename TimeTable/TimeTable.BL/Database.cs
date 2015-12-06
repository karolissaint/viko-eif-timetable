using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using TimeTable.BL.DataHelpers;

namespace TimeTable.BL
{
    public static class Database
    {
        public static SqlConnection conn = 
            new SqlConnection(@"Server = .\SQLExpress; Database = timeTableDb; Trusted_Connection = True;");

        public static SqlCommand compileCommand(string cmd)
        {
            return new SqlCommand(cmd, conn);
        }

        public static void delete(string table)
        {
            SqlCommand cmd = new SqlCommand("delete * from @table", conn);
            cmd.Parameters.AddWithValue("@table", table);
            cmd.ExecuteNonQuery();
        }
    }
}
