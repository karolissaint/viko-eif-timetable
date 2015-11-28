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

        [WebMethod]
        public List<Cabinet> getCabinets()
        {
            return Database.getCabinets();
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
    }
}
