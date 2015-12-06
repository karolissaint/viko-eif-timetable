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
    Group group;
    WebService ws;
    List<Group> groups;

    protected void Page_Load(object sender, EventArgs e)
    {
        ws = new WebService();
        group = new Group();
        groups = ws.getGroups().OrderBy(g => g.code).ToList();
        if (!IsPostBack)
        {
            groupsToUpdateDropDownList.Items.Insert(0, new ListItem("Please select", ""));
            groupsToDeleteListBox.Items.Clear();
            foreach (Group item in groups)
            {
                groupsToDeleteListBox.Items.Add(item.code);
                groupsToUpdateDropDownList.Items.Add(item.code);
            }
        }
    }

    protected void insertButton_Click(object sender, EventArgs e)
    {
        group.code = groupCodeTextBox.Text;
        group.title = groupTitleTextBox.Text;
        string status = ws.insertGroup(group.code, group.title);

        addGroupHelperLabel.ForeColor = System.Drawing.Color.Red;

        if (status == null)
        {
            groupsToDeleteListBox.Items.Add(group.code);
            groupsToUpdateDropDownList.Items.Add(group.code);

            addGroupHelperLabel.ForeColor = System.Drawing.Color.Green;
            status = "Group succesfully added!";
        }
        addGroupHelperLabel.Text = status;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        ListBox list = groupsToDeleteListBox;
        DropDownList updateList = groupsToUpdateDropDownList;
        for(int i = list.Items.Count - 1; i >= 0; i--)
        {
            if (list.Items[i].Selected)
            {
                ws.deleteGroup(list.Items[i].Text);
                updateList.Items.Remove(list.Items[i].Text);
                list.Items.RemoveAt(i);
            }
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        DropDownList list = groupsToUpdateDropDownList;

        string status;
        updateHelpLabel.ForeColor = System.Drawing.Color.Red;

        int i = list.SelectedIndex;
        if (i > 0)
        {
            string code = groupCodeToUpdateTextBox.Text;
            string title = groupTitleToUpdateTextBox.Text;
            int id  = ws.getGroup(list.Items[i].Text).id;

            status = ws.updateGroup(Convert.ToInt32(id), code, title);
            if (status == null)
            {
                groupsToDeleteListBox.Items.FindByText(list.Items[i].Text).Text = code;
                groupsToUpdateDropDownList.Items.FindByText(list.Items[i].Text).Text = code;

                updateHelpLabel.ForeColor = System.Drawing.Color.Green;
                status = "Group succesfully updated!";
            }
        }
        else
        {
            status = "Please select group to update!";
        }
        updateHelpLabel.Text = status;
    }

    protected void groupsToUpdateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = groupsToUpdateDropDownList;
        int i = list.SelectedIndex;
        if (i > 0)
        {
            groupCodeToUpdateTextBox.Text = list.Items[i].Text;
            groupTitleToUpdateTextBox.Text = ws.getGroup(list.Items[i].Text).title;
        }
    }
}