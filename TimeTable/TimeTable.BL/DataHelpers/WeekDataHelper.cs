using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TimeTable.BL.DataHelpers
{
    public class Week
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class WeekDataHelper
    {
        private static readonly string WEEK_TABLE = "[Week]";

        private static readonly string KEY_ID = "Id"; // in database set auto increment 1
        private static readonly string KEY_TITLE = "Title";

        private SqlCommand insertCmd;
        //insert into WEEK_TABLE(KEY_TITLE) + values(@KEY_TITLE);
        private static readonly string INSERT = "insert into " + WEEK_TABLE + "(" + KEY_TITLE + ")" +
            " values(@" + KEY_TITLE + ")";

        private SqlCommand updateCmd;
        //update WEEK_TABLE set KEY_TITLE = @KEY_TITLE where KEY_ID = @KEY_ID
        private static readonly string UPDATE = "update " + WEEK_TABLE + "set " + KEY_TITLE + " = @" +
            KEY_TITLE + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand deleteCmd;
        //delete from WEEK_TABLE where KEY_TITLE = @KEY_TITLE
        private static readonly string DELETE = "delete from " + WEEK_TABLE + " where " + KEY_TITLE + " = @" + KEY_TITLE;

        private SqlCommand selectCmd;
        //select * from WEEK_TABLE where KEY_CODE = @KEY_CODE
        private static readonly string SELECT = "select * from " + WEEK_TABLE + " where " + KEY_TITLE + " = @" + KEY_TITLE;

        private SqlCommand selectAllCmd;
        //select * from WEEK_TABLE
        private static readonly string SELECT_ALL = "select * from " + WEEK_TABLE;

        public WeekDataHelper()
        {
            this.insertCmd = Database.compileCommand(INSERT);
            this.updateCmd = Database.compileCommand(UPDATE);
            this.deleteCmd = Database.compileCommand(DELETE);
            this.selectCmd = Database.compileCommand(SELECT);
            this.selectAllCmd = Database.compileCommand(SELECT_ALL);
        }

        public void insert(Week week)
        {
            insert(week.title);
        }
        private void insert(string title)
        {
            this.insertCmd.Parameters.Clear();
            this.insertCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            insertCmd.ExecuteNonQuery();
        }

        public void update(Week week)
        {
            update(week.id, week.title);
        }
        private void update(int id, string title)
        {
            this.updateCmd.Parameters.Clear();
            this.updateCmd.Parameters.AddWithValue("@" + KEY_ID, id);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            updateCmd.ExecuteNonQuery();
        }

        public void delete(string title)
        {
            this.deleteCmd.Parameters.Clear();
            this.deleteCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            deleteCmd.ExecuteNonQuery();
        }

        public void deleteAll()
        {
            Database.delete(WEEK_TABLE);
        }

        public Week getByTitle(Week week)
        {
            return getByTitle(week.title);
        }
        private Week getByTitle(string title)
        {
            this.selectCmd.Parameters.Clear();
            Week week = new Week();
            this.selectCmd.Parameters.AddWithValue("@" + KEY_TITLE, KEY_TITLE);
            using (SqlDataReader reader = this.selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    week.id = Convert.ToInt32(reader[0]);
                    week.title = reader[1].ToString();
                }
            }
            return week;
        }

        public List<Week> getAll()
        {
            List<Week> weeks = new List<Week>();
            using (SqlDataReader reader = this.selectAllCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    weeks.Add(new Week()
                    {
                        id = Convert.ToInt32(reader[0]),
                        title = reader[1].ToString(),
                    });
                }
            }
            return weeks;
        }

        public bool isExists(string title)
        {
            SqlCommand cmd = Database.compileCommand("select count(*) from " + WEEK_TABLE + " where " + KEY_TITLE + " =@" + KEY_TITLE);
            cmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            int weeksCount = (int)cmd.ExecuteScalar();
            if (weeksCount > 0) return true;
            return false;
        }
    }
}
