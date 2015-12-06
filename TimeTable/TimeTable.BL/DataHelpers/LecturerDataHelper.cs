using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TimeTable.BL.DataHelpers
{
    public class Lecturer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
    }

    public class LecturerDataHelper
    {
        private static readonly string LECTURER_TABLE = "[Lecturer]";

        private static readonly string KEY_ID = "Id"; // in database set auto increment 1
        private static readonly string KEY_NAME = "Name";
        private static readonly string KEY_LASTNAME = "Lastname";

        private SqlCommand insertCmd;
        private static readonly string INSERT = "insert into " + LECTURER_TABLE + "(" + KEY_NAME +
            ", " + KEY_LASTNAME + ") " + "values(@" + KEY_NAME + ", @" + KEY_LASTNAME + ")";

        private SqlCommand updateCmd;
        private static readonly string UPDATE = "update " + LECTURER_TABLE + "set " + KEY_NAME + " = @" +
            KEY_NAME + ", " + KEY_LASTNAME + " = @" + KEY_LASTNAME + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand deleteCmd;
        private static readonly string DELETE = "delete from " + LECTURER_TABLE + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand selectCmd;
        private static readonly string SELECT = "select * from " + LECTURER_TABLE + " where " + KEY_NAME + " = @" + KEY_NAME 
            + " AND " + KEY_LASTNAME + " =@" + KEY_LASTNAME;

        private SqlCommand selectAllCmd;
        //select * from GROUP_TABLE
        private static readonly string SELECT_ALL = "select * from " + LECTURER_TABLE;

        public LecturerDataHelper()
        {
            this.insertCmd = Database.compileCommand(INSERT);
            this.updateCmd = Database.compileCommand(UPDATE);
            this.deleteCmd = Database.compileCommand(DELETE);
            this.selectCmd = Database.compileCommand(SELECT);
            this.selectAllCmd = Database.compileCommand(SELECT_ALL);
        }

        public string insert(Lecturer lec)
        {
            if (lec.name == "" || string.IsNullOrWhiteSpace(lec.name)) return "Lecturer name can't be empty!";
            if (lec.lastname == "" || string.IsNullOrWhiteSpace(lec.lastname)) return "Lecturer lastname can't be empty!";
            if (isExists(lec.name, lec.lastname)) return "Lecturer already exists!";
            insert(lec.name, lec.lastname);
            return null;
        }
        private void insert(string name, string lastname)
        {
            this.insertCmd.Parameters.Clear();
            this.insertCmd.Parameters.AddWithValue("@" + KEY_NAME, name);
            this.insertCmd.Parameters.AddWithValue("@" + KEY_LASTNAME, lastname);
            insertCmd.ExecuteNonQuery();
        }

        public string update(Lecturer lec)
        {
            if (lec.name == "" || string.IsNullOrWhiteSpace(lec.name)) return "Lecturer name can't be empty!";
            if (lec.lastname == "" || string.IsNullOrWhiteSpace(lec.lastname)) return "Lecturer lastname can't be empty!";
            update(lec.id, lec.name, lec.lastname);
            return null;
        }
        private void update(int id, string name, string lastname)
        {
            this.updateCmd.Parameters.Clear();
            this.updateCmd.Parameters.AddWithValue("@" + KEY_ID, id);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_NAME, name);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_LASTNAME, lastname);
            updateCmd.ExecuteNonQuery();
        }

        public void delete(int id)
        {
            this.deleteCmd.Parameters.Clear();
            this.deleteCmd.Parameters.AddWithValue("@" + KEY_ID, id);
            deleteCmd.ExecuteNonQuery();
        }

        public void deleteAll()
        {
            Database.delete(LECTURER_TABLE);
        }

        public Lecturer getByNameAndLastName(string name, string lastname)
        {
            this.selectCmd.Parameters.Clear();
            Lecturer lec = new Lecturer();
            this.selectCmd.Parameters.AddWithValue("@" + KEY_NAME, name);
            this.selectCmd.Parameters.AddWithValue("@" + KEY_LASTNAME, lastname);
            using (SqlDataReader reader = this.selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lec.id = Convert.ToInt32(reader[0]);
                    lec.name = reader[1].ToString();
                    lec.lastname = reader[2].ToString();
                }
            }
            return lec;
        }

        public List<Lecturer> getAll()
        {
            List<Lecturer> lecs = new List<Lecturer>();
            using (SqlDataReader reader = this.selectAllCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lecs.Add(new Lecturer()
                    {
                        id = Convert.ToInt32(reader[0]),
                        name = reader[1].ToString(),
                        lastname = reader[2].ToString()
                    });
                }
            }
            return lecs;
        }

        public bool isExists(string name, string lastname)
        {
            SqlCommand cmd = Database.compileCommand("select count(*) from " + LECTURER_TABLE + " where " + KEY_NAME + " =@" + KEY_NAME + " and " + KEY_LASTNAME + "= @" + KEY_LASTNAME);
            cmd.Parameters.AddWithValue("@" + KEY_NAME, name);
            cmd.Parameters.AddWithValue("@" + KEY_LASTNAME, lastname);
            int groupCount = (int)cmd.ExecuteScalar();
            if (groupCount > 0) return true;
            return false;
        }
    }
}
