using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TimeTable.BL.DataHelpers
{
    public class SubGroup
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class SubGroupDataHelper
    {
        private static readonly string SUB_GROUP_TABLE = "[SubGroup]";

        private static readonly string KEY_ID = "Id"; // in database set auto increment 1
        private static readonly string KEY_TITLE = "Title";

        private SqlCommand insertCmd;
        //insert into SUB_GROUP_TABLE(KEY_TITLE) + values(@KEY_TITLE);
        private static readonly string INSERT = "insert into " + SUB_GROUP_TABLE + "(" + KEY_TITLE + ")" +
            " values(@" + KEY_TITLE + ")";

        private SqlCommand updateCmd;
        //update SUB_GROUP_TABLE set KEY_TITLE = @KEY_TITLE where KEY_ID = @KEY_ID
        private static readonly string UPDATE = "update " + SUB_GROUP_TABLE + "set " + KEY_TITLE + " = @" +
            KEY_TITLE + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand deleteCmd;
        //delete from SUB_GROUP_TABLE where KEY_TITLE = @KEY_TITLE
        private static readonly string DELETE = "delete from " + SUB_GROUP_TABLE + " where " + KEY_TITLE + " = @" + KEY_TITLE;

        private SqlCommand selectCmd;
        //select * from SUB_GROUP_TABLE where KEY_CODE = @KEY_CODE
        private static readonly string SELECT = "select * from " + SUB_GROUP_TABLE + " where " + KEY_TITLE + " = @" + KEY_TITLE;

        private SqlCommand selectAllCmd;
        //select * from SUB_GROUP_TABLE
        private static readonly string SELECT_ALL = "select * from " + SUB_GROUP_TABLE;

        public SubGroupDataHelper()
        {
            this.insertCmd = Database.compileCommand(INSERT);
            this.updateCmd = Database.compileCommand(UPDATE);
            this.deleteCmd = Database.compileCommand(DELETE);
            this.selectCmd = Database.compileCommand(SELECT);
            this.selectAllCmd = Database.compileCommand(SELECT_ALL);
        }

        public void insert(SubGroup subGroup)
        {
            insert(subGroup.title);
        }
        private void insert(string title)
        {
            this.insertCmd.Parameters.Clear();
            this.insertCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            insertCmd.ExecuteNonQuery();
        }

        public void update(SubGroup subGroup)
        {
            update(subGroup.id, subGroup.title);
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
            Database.delete(SUB_GROUP_TABLE);
        }

        public SubGroup getByTitle(SubGroup subGroup)
        {
            return getByTitle(subGroup.title);
        }
        private SubGroup getByTitle(string title)
        {
            this.selectCmd.Parameters.Clear();
            SubGroup subGroup = new SubGroup();
            this.selectCmd.Parameters.AddWithValue("@" + KEY_TITLE, KEY_TITLE);
            using (SqlDataReader reader = this.selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    subGroup.id = Convert.ToInt32(reader[0]);
                    subGroup.title = reader[1].ToString();
                }
            }
            return subGroup;
        }

        public List<SubGroup> getAll()
        {
            List<SubGroup> subGroups = new List<SubGroup>();
            using (SqlDataReader reader = this.selectAllCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    subGroups.Add(new SubGroup()
                    {
                        id = Convert.ToInt32(reader[0]),
                        title = reader[1].ToString(),
                    });
                }
            }
            return subGroups;
        }

        public bool isExists(string title)
        {
            SqlCommand cmd = Database.compileCommand("select count(*) from " + SUB_GROUP_TABLE + " where " + KEY_TITLE + " =@" + KEY_TITLE);
            cmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            int groupCount = (int)cmd.ExecuteScalar();
            if (groupCount > 0) return true;
            return false;
        }
    }
}
