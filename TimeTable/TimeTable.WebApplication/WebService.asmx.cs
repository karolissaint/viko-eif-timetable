using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using TimeTable.BL;
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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region Cabinet methods
        [WebMethod]
        public List<Cabinet> getCabinets()
        {
            List<Cabinet> list = Database.getCabinets();
            return list;
        }
        [WebMethod]
        public void insertCabinet(string code)
        {
            Database.insertCabinet(code);
        }
        [WebMethod]
        public void updateCabinet(string currentCode, string updateCode)
        {
            Database.updateCabinet(currentCode, updateCode);
        }
        [WebMethod]
        public void removeCabinet(string code)
        {
            Database.removeCabinet(code);
        }
        #endregion
        #region Group methods
        [WebMethod]
        public List<Group> getGroups()
        {
            List<Group> list = Database.getGroups();
            if (list == null) throw new Exception("Groups list empty");
            return list;
        }
        [WebMethod]
        public void insertGroup(string code, string title)
        {
            Database.insertGroup(code, title);
        }
        [WebMethod]
        public void updateGroup(string currentCode, string updateCode, string title)
        {
            Database.updateGroup(currentCode, updateCode, title);
        }
        [WebMethod]
        public void removeGroup(string code)
        {
            Database.removeGroup(code);
        }
        #endregion
    }
}
