using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;
using System.Web.Services.Protocols;

public partial class GroupPage : System.Web.UI.Page
{
    string groupCode;
    string groupTitle;
    WebService ws;

    protected void Page_Load(object sender, EventArgs e)
    {
        ws = new WebService();

        groupsDropDownList.Items.Clear();
        List<Group> groups = ws.getGroups().OrderBy(c => c.code).ToList();
        foreach (Group item in groups)
            groupsDropDownList.Items.Add(item.code);
    }


    protected void insertButton_Click(object sender, EventArgs e)
    {
        groupCode = groupCodeTextBox.Text;
        groupTitle = groupTitleTextBox.Text;
        try
        {
            newGroupStatusMessage.Text = ws.insertGroup(groupCode, groupTitle);
        }
        catch(Exception ex)
        {
            newGroupStatusMessage.Text = ex.Message;
        }
    }
}