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
            return groupDataHelper.getAll();
        }
        [WebMethod]
        public Group getGroup(string code)
        {
            return groupDataHelper.getByCode(code);
        }
        [WebMethod]
        public string insertGroup(string code, string title)
        {
            return groupDataHelper.insert(new Group() { code = code, title = title });
        }
        [WebMethod]
        public string updateGroup(int id, string code, string title)
        {
            return groupDataHelper.update(new Group() { id = id, code = code, title = title });
        }
        [WebMethod]
        public void deleteGroup(string code)
        {
            groupDataHelper.delete(code);
        }
        #endregion
        #region SubGroup methods

        SubGroupDataHelper subGroupDataHelper = new SubGroupDataHelper();

        [WebMethod]
        public List<SubGroup> getSubGroups()
        {
            return subGroupDataHelper.getAll();
        }
        [WebMethod]
        public SubGroup getSubGroup(string title)
        {
            return subGroupDataHelper.getByTitle(new SubGroup() { title = title });
        }
        [WebMethod]
        public string insertSubGroup(string title)
        {
            return subGroupDataHelper.insert(new SubGroup() { title = title });
        }
        [WebMethod]
        public string updateSubGroup(int id, string title)
        {
            return subGroupDataHelper.update(new SubGroup() { id = id, title = title });
        }
        [WebMethod]
        public void deleteSubGroup(string title)
        {
            subGroupDataHelper.delete(title);
        }
        #endregion
        #region Week methods
        WeekDataHelper weekDataHelper = new WeekDataHelper();
        [WebMethod]
        public List<Week> getWeeks()
        {
            return weekDataHelper.getAll();
        }
        [WebMethod]
        public Week getWeek(string title)
        {
            return weekDataHelper.getByTitle(new Week() { title = title });
        }
        [WebMethod]
        public string insertWeek(string title)
        {
            return weekDataHelper.insert(new Week() { title = title });
        }
        [WebMethod]
        public string updateWeek(int id, string title)
        {
            return weekDataHelper.update(new Week() { id = id, title = title });
        }
        [WebMethod]
        public void deleteWeek(string title)
        {
            weekDataHelper.delete(title);
        }
        #endregion
        #region Cabinet methods
        CabinetDataHelper cabDataHelper = new CabinetDataHelper();
        [WebMethod]
        public List<Cabinet> getCabinets()
        {
            return cabDataHelper.getAll();
        }
        [WebMethod]
        public Cabinet getCabinet(string code)
        {
            return cabDataHelper.getByCode(new Cabinet() { code = code });
        }
        [WebMethod]
        public string insertCabinet(string code)
        {
            return cabDataHelper.insert(new Cabinet() { code = code });
        }
        [WebMethod]
        public string updateCabinet(int id, string code)
        {
            return cabDataHelper.update(new Cabinet() { id = id, code = code });
        }
        [WebMethod]
        public void deleteCabinet(string code)
        {
            cabDataHelper.delete(code);
        }
        #endregion
        #region Lecturer methods
        LecturerDataHelper lecDataHelper = new LecturerDataHelper();

        [WebMethod]
        public List<Lecturer> getLecturers()
        {
            return lecDataHelper.getAll();
        }
        [WebMethod]
        public Lecturer getLecturer(string name, string lastname)
        {
            return lecDataHelper.getByNameAndLastName(name, lastname);
        }
        [WebMethod]
        public string insertLecturer(string name, string lastname)
        {
            return lecDataHelper.insert(new Lecturer() { name = name, lastname = lastname });
        }
        [WebMethod]
        public string updateLecturer(int id, string name, string lastname)
        {
            return lecDataHelper.update(new Lecturer() { id = id, name = name, lastname = lastname });
        }
        [WebMethod]
        public void deleteLecturer(int id)
        {
            lecDataHelper.delete(id);
        }
        #endregion
    }
}
