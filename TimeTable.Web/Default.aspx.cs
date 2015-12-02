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
        List<Group> groups = ws.getGroups().OrderBy(c => c.code).ToList();
        foreach (Group item in groups)
            groupsDropDownList.Items.Add(item.code);

        List<SubGroup> subGroups = ws.getSubGroups().OrderBy(s => s.title).ToList();
        foreach (SubGroup item in subGroups)
            subGroupsDropDownList.Items.Add(item.title);

        List<Week> weeks = ws.getWeeks().OrderBy(w => w.title).ToList();
        foreach (Week item in weeks)
            weeksDropDownList.Items.Add(item.title);

        
        //events
        adminButton.Click += AdminButton_Click;

        
    }

    private void AdminButton_Click(object sender, EventArgs e)
    {

    }
}