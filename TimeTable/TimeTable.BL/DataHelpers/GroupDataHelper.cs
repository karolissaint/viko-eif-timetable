using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TimeTable.BL.DataHelpers
{
    public class Group
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
    }

    public class GroupDataHelper
    {
        private static readonly string GROUP_TABLE = "[Group]"; //skliaustai naudojami nes Group sutampa su SQL komanda group by

        private static readonly string KEY_ID = "Id"; // in database set auto increment 1
        private static readonly string KEY_CODE = "Code";
        private static readonly string KEY_TITLE = "Title";

        private SqlCommand insertCmd;
        //insert into GROUP_TABLE(KEY_CODE, KEY_TITLE) + values(@KEY_CODE, @KEY_TITLE);
        private static readonly string INSERT = "insert into " + GROUP_TABLE + "(" + KEY_CODE +
            ", " + KEY_TITLE + ") " + "values(@" + KEY_CODE + ", @" + KEY_TITLE + ")";

        private SqlCommand updateCmd;
        //update GROUP_TABLE set KEY_TITLE = @KEY_TITLE, KEY_CODE = @KEY_CODE where KEY_ID = @KEY_ID
        private static readonly string UPDATE = "update " + GROUP_TABLE + "set " + KEY_TITLE + " = @" +
            KEY_TITLE + ", " + KEY_CODE + " = @" + KEY_CODE + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand deleteCmd;
        //delete from GROUP_TABLE where KEY_ID = @KEY_ID
        private static readonly string DELETE = "delete from " + GROUP_TABLE + " where " + KEY_CODE + " = @" + KEY_CODE;

        private SqlCommand selectCmd;
        //select * from GROUP_TABLE where KEY_CODE = @KEY_CODE
        private static readonly string SELECT = "select * from " + GROUP_TABLE + " where " + KEY_CODE + " = @" + KEY_CODE;

        private SqlCommand selectAllCmd;
        //select * from GROUP_TABLE
        private static readonly string SELECT_ALL = "select * from " + GROUP_TABLE;

        public GroupDataHelper()
        {
            this.insertCmd = Database.compileCommand(INSERT);
            this.updateCmd = Database.compileCommand(UPDATE);
            this.deleteCmd = Database.compileCommand(DELETE);
            this.selectCmd = Database.compileCommand(SELECT);
            this.selectAllCmd = Database.compileCommand(SELECT_ALL);
        }

        public void insert(Group group)
        {
            insert(group.code, group.title);
        }
        private void insert(string code, string title)
        {
            this.insertCmd.Parameters.Clear();
            this.insertCmd.Parameters.AddWithValue("@"+KEY_CODE, code);
            this.insertCmd.Parameters.AddWithValue("@"+KEY_TITLE, title);
            insertCmd.ExecuteNonQuery();
        }

        public void update(Group group)
        {
            update(group.id, group.code, group.title);
        }
        private void update(int id, string code, string title)
        {
            this.updateCmd.Parameters.Clear();
            this.updateCmd.Parameters.AddWithValue("@" + KEY_ID, id);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
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
            Database.delete(GROUP_TABLE);
        }

        public Group getByCode(Group group)
        {
            return getByCode(group.code);
        }
        private Group getByCode(string code)
        {
            this.selectCmd.Parameters.Clear();
            Group group = new Group();
            this.selectCmd.Parameters.AddWithValue("@" + KEY_CODE, KEY_CODE);
            using (SqlDataReader reader = this.selectCmd.ExecuteReader())
            {
                if(reader.Read())
                {
                    group.id = Convert.ToInt32(reader[0]);
                    group.title = reader[1].ToString();
                    group.code = reader[2].ToString();
                }
            }
            return group;
        }

        public List<Group>getAll()
        {
            List<Group> groups = new List<Group>();
            using (SqlDataReader reader = this.selectAllCmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    groups.Add(new Group() {
                        id = Convert.ToInt32(reader[0]),
                        title = reader[1].ToString(),
                        code = reader[2].ToString()
                    });
                }
            }
                return groups;
        }

        public bool isExists(string code)
        {
            SqlCommand cmd = Database.compileCommand("select count(*) from " + GROUP_TABLE + " where " + KEY_CODE + " =@" + KEY_CODE);
            cmd.Parameters.AddWithValue("@" + KEY_CODE, code);
            int groupCount = (int)cmd.ExecuteScalar();
            if (groupCount > 0) return true;
            return false;
        }
    }
}
