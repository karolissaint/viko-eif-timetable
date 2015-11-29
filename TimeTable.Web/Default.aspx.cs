using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebService ws = new WebService();

        //List<Cabinet> cabinets = ws.getCabinets().ToList();
        //foreach (Cabinet item in cabinets)
        //    cabinetsDropDownList.Items.Add(item.code);

        List<Group> groups = ws.getGroups().OrderBy(c => c.title).ToList();
        foreach (Group item in groups)
            groupsDropDownList.Items.Add(item.code);
    }
}