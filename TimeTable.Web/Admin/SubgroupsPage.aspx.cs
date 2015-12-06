using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;

public partial class Admin_SubgroupsPage : System.Web.UI.Page
{
    SubGroup subgroup;
    WebService ws;
    List<SubGroup> subgroups;

    protected void Page_Load(object sender, EventArgs e)
    {
        subgroup = new SubGroup();
        ws = new WebService();
        subgroups = ws.getSubGroups().OrderBy(s => s.title).ToList();
        if(!IsPostBack)
        {
            subGroupsToUpdateDropDownList.Items.Insert(0, new ListItem("Please select", ""));
            foreach (SubGroup item in subgroups)
            {
                subGroupsToDeleteListBox.Items.Add(item.title);
                subGroupsToUpdateDropDownList.Items.Add(item.title);
            }
        }
    }



    protected void insertButton_Click(object sender, EventArgs e)
    {
        subgroup.title = subGroupTitleTextBox.Text;

        string status = ws.insertSubGroup(subgroup.title);
        addSubgroupHelperLabel.ForeColor = System.Drawing.Color.Red;

        if(status == null)
        {
            subGroupsToDeleteListBox.Items.Add(subgroup.title);
            subGroupsToUpdateDropDownList.Items.Add(subgroup.title);

            addSubgroupHelperLabel.ForeColor = System.Drawing.Color.Green;
            status = "Group succesfully added!";
        }

        addSubgroupHelperLabel.Text = status;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        ListBox list = subGroupsToDeleteListBox;
        for (int i = list.Items.Count - 1; i >= 0; i--)
        {
            if (list.Items[i].Selected)
            {
                ws.deleteSubGroup(list.Items[i].Text);

                subGroupsToUpdateDropDownList.Items.Remove(list.Items[i].Text);
                list.Items.RemoveAt(i);
            }
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        DropDownList list = subGroupsToUpdateDropDownList;

        string status;
        updateHelpLabel.ForeColor = System.Drawing.Color.Red;

        int i = list.SelectedIndex;
        if (i > 0)
        {
            string title = subGroupTitleToUpdateTextBox.Text;
            int id = ws.getSubGroup(list.Items[i].Text).id;

            status = ws.updateSubGroup(id, title);
            if (status == null)
            {
                subGroupsToDeleteListBox.Items.FindByText(list.Items[i].Text).Text = title;
                subGroupsToUpdateDropDownList.Items.FindByText(list.Items[i].Text).Text = title;

                updateHelpLabel.ForeColor = System.Drawing.Color.Green;
                status = "Subgroup succesfully updated!";
            }
        }
        else
        {
            status = "Please select subgroup to update!";
        }
        updateHelpLabel.Text = status;
    }

    protected void subGroupsToUpdateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = subGroupsToUpdateDropDownList;
        int i = list.SelectedIndex;
        if (i > 0)
        {
            subGroupTitleToUpdateTextBox.Text = ws.getSubGroup(list.Items[i].Text).title;
        }
    }
}