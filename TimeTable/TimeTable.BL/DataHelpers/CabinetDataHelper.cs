using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TimeTable.BL.DataHelpers
{
    public class Cabinet
    {
        public int id { get; set; }
        public string code { get; set; }
    }
    public class CabinetDataHelper
    {
        private static readonly string CABINET_TABLE = "[Cabinet]";

        private static readonly string KEY_ID = "Id"; // in database set auto increment 1
        private static readonly string KEY_CODE = "Code"; //nvarchar(4)

        private SqlCommand insertCmd;
        //insert into WEEK_TABLE(KEY_TITLE) + values(@KEY_TITLE);
        private static readonly string INSERT = "insert into " + CABINET_TABLE + "(" + KEY_CODE + ")" +
            " values(@" + KEY_CODE + ")";

        private SqlCommand updateCmd;
        //update WEEK_TABLE set KEY_TITLE = @KEY_TITLE where KEY_ID = @KEY_ID
        private static readonly string UPDATE = "update " + CABINET_TABLE + "set " + KEY_CODE + " = @" +
            KEY_CODE + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand deleteCmd;
        //delete from WEEK_TABLE where KEY_TITLE = @KEY_TITLE
        private static readonly string DELETE = "delete from " + CABINET_TABLE + " where " + KEY_CODE + " = @" + KEY_CODE;

        private SqlCommand selectCmd;
        //select * from WEEK_TABLE where KEY_CODE = @KEY_CODE
        private static readonly string SELECT = "select * from " + CABINET_TABLE + " where " + KEY_CODE + " = @" + KEY_CODE;

        private SqlCommand selectAllCmd;
        //select * from WEEK_TABLE
        private static readonly string SELECT_ALL = "select * from " + CABINET_TABLE;

        public CabinetDataHelper()
        {
            this.insertCmd = Database.compileCommand(INSERT);
            this.updateCmd = Database.compileCommand(UPDATE);
            this.deleteCmd = Database.compileCommand(DELETE);
            this.selectCmd = Database.compileCommand(SELECT);
            this.selectAllCmd = Database.compileCommand(SELECT_ALL);
        }

        public string insert(Cabinet cab)
        {
            if (cab.code == "" || string.IsNullOrWhiteSpace(cab.code)) return "Cabinet code can't be empty!";
            if (cab.code.Length > 4) return "Cabinet code length must be less or equal 4!";
            if (isExists(cab.code)) return "Cabinet already exist!";
            insert(cab.code);
            return null;
        }

        private void insert(string code)
        {
            this.insertCmd.Parameters.Clear();
            this.insertCmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            insertCmd.ExecuteNonQuery();
        }

        public string update(Cabinet cab)
        {
            if (cab.code == "" || string.IsNullOrWhiteSpace(cab.code)) return "Cabinet code can't be empty!";
            if (cab.code.Length > 4) return "Cabinet code length must be less or equal 4!";
            update(cab.id, cab.code);
            return null;
        }
        private void update(int id, string code)
        {
            this.updateCmd.Parameters.Clear();
            this.updateCmd.Parameters.AddWithValue("@" + KEY_ID, id);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            updateCmd.ExecuteNonQuery();
        }

        public void delete(string code)
        {
            this.deleteCmd.Parameters.Clear();
            this.deleteCmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            deleteCmd.ExecuteNonQuery();
        }

        public void deleteAll()
        {
            Database.delete(CABINET_TABLE);
        }

        public Cabinet getByCode(Cabinet cab)
        {
            return getByCode(cab.code);
        }
        private Cabinet getByCode(string code)
        {
            this.selectCmd.Parameters.Clear();
            Cabinet cab = new Cabinet();
            this.selectCmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            using (SqlDataReader reader = this.selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    cab.id = Convert.ToInt32(reader[0]);
                    cab.code = reader[1].ToString();
                }
            }
            return cab;
        }

        public List<Cabinet> getAll()
        {
            List<Cabinet> cabs = new List<Cabinet>();
            using (SqlDataReader reader = this.selectAllCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cabs.Add(new Cabinet()
                    {
                        id = Convert.ToInt32(reader[0]),
                        code = reader[1].ToString(),
                    });
                }
            }
            return cabs;
        }

        public bool isExists(string code)
        {
            SqlCommand cmd = Database.compileCommand("select count(*) from " + CABINET_TABLE + " where " + KEY_CODE + " =@" + KEY_CODE);
            cmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            int counter = (int)cmd.ExecuteScalar();
            if (counter > 0) return true;
            return false;
        }
    }
}
