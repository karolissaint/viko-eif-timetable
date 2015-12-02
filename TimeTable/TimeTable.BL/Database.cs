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
        public static SqlConnection conn = new SqlConnection(@"Server = .\SQLExpress; Database = timeTableDb; Trusted_Connection = True;");
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
        #region Group methods, "code" - IR14B - less than 5 symbols, "title" - Išmanieji irenginiai - less than 40 symbols
        private static GroupDataHelper groupDataHelper = new GroupDataHelper();

        public static List<Group> getGroups()
        {
            return groupDataHelper.getAll();
        }
        public static string insertGroup(string code, string title)
        {
            if (code == "" || code == null) return "Group code can't be empty!";
            if (groupDataHelper.isExists(code)) return "That group already exist!";
            else
            {
                Group group = new Group()
                {
                    code = code,
                    title = title
                };
                groupDataHelper.insert(group);
            }
            return "Group succesfully added!";
        }
        public static void updateGroup(int id, string code, string title)
        {
            Group group = new Group()
            {
                id = id,
                code = code,
                title = title
            };
            groupDataHelper.update(group);
        }
        public static void deleteGroup(string code)
        {
            if (groupDataHelper.isExists(code))
            {
                groupDataHelper.delete(code);
            }
        }
        #endregion
        #region SubGroup Methods
        private static SubGroupDataHelper subGroupDataHelper = new SubGroupDataHelper();

        public static List<SubGroup> getSubGoups()
        {
            return subGroupDataHelper.getAll();
        }
        public static void insertSubGroup(string title)
        {
            if (!subGroupDataHelper.isExists(title))
            {
                subGroupDataHelper.insert(new SubGroup() { title = title });
            }
        }
        public static void updateSubGroup(int id, string title)
        {
            if(!subGroupDataHelper.isExists(title))
            {
                subGroupDataHelper.update(new SubGroup() { id = id, title = title });
            }
        }
        public static void deleteSubGroup(string title)
        {
            if(subGroupDataHelper.isExists(title))
            {
                subGroupDataHelper.delete(title);
            }
        }
        #endregion
        #region Week Methods
        private static WeekDataHelper weekDataHelper = new WeekDataHelper();
        public static List<Week> getWeeks()
        {
            return weekDataHelper.getAll();
        }
        public static void insertWeek(string title)
        {
            if(!weekDataHelper.isExists(title))
            {
                weekDataHelper.insert(new Week() { title = title });
            }
        }
        public static void updateWeek(int id, string title)
        {
            if(!weekDataHelper.isExists(title))
            {
                weekDataHelper.update(new Week() { id = id, title = title });
            }
        }
        public static void deleteWeek(string title)
        {
            if(weekDataHelper.isExists(title))
            {
                weekDataHelper.delete(title);
            }
        }
        #endregion
    }
}
