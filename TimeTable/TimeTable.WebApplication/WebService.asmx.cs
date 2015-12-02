using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using TimeTable.BL;
using TimeTable.BL.DataHelpers;
using System.Web.UI;

namespace TimeTable.WebApplication
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public WebService()
        {
            try
            {
                Database.conn.Open();
            }
            catch
            {

            }
        }

        #region Group methods

        GroupDataHelper groupDataHelper = new GroupDataHelper();

        [WebMethod]
        public List<Group> getGroups()
        {
            return Database.getGroups();
        }
        [WebMethod]
        public string insertGroup(string code, string title)
        {
            if (code == "") throw new Exception("Group can't be empty!");
            return Database.insertGroup(code, title);
        }
        [WebMethod]
        public void updateGroup(int id, string code, string title)
        {
            Database.updateGroup(id, code, title);
        }
        [WebMethod]
        public void deleteGroup(string code)
        {
            Database.deleteGroup(code);
        }
        #endregion
        #region SubGroup methods
        [WebMethod]
        public List<SubGroup> getSubGroups()
        {
            return Database.getSubGoups();
        }
        [WebMethod]
        public void insertSubGroup(string title)
        {
            Database.insertSubGroup(title);
        }
        [WebMethod]
        public void updateSubGroup(int id, string title)
        {
            Database.updateSubGroup(id, title);
        }
        [WebMethod]
        public void deleteSubGroup(string title)
        {
            Database.deleteSubGroup(title);
        }
        #endregion
        #region Week methods
        [WebMethod]
        public List<Week> getWeeks()
        {
            return Database.getWeeks();
        }
        [WebMethod]
        public void insertWeek(string title)
        {
            Database.insertWeek(title);
        }
        [WebMethod]
        public void updateWeek(int id, string title)
        {
            Database.updateWeek(id, title);
        }
        [WebMethod]
        public void deleteWeek(string title)
        {
            Database.deleteWeek(title);
        }
        #endregion
    }
}
