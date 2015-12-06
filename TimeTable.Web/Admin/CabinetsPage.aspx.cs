using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;

public partial class Admin_CabinetsPage : System.Web.UI.Page
{

    Cabinet cab;
    WebService ws;
    List<Cabinet> cabs;

    protected void Page_Load(object sender, EventArgs e)
    {
        cab = new Cabinet();
        ws = new WebService();
        cabs = ws.getCabinets().OrderBy(c => c.code).ToList();
        if (!IsPostBack)
        {
            updateDropDownList.Items.Insert(0, new ListItem("Please select", ""));
            foreach (Cabinet item in cabs)
            {
                deleteListBox.Items.Add(item.code);
                updateDropDownList.Items.Add(item.code);
            }
        }
    }

    protected void insertButton_Click(object sender, EventArgs e)
    {
        cab.code = titleTextBox.Text;

        string status = ws.insertCabinet(cab.code);
        addHelperLabel.ForeColor = System.Drawing.Color.Red;

        if (status == null)
        {
            deleteListBox.Items.Add(cab.code);
            updateDropDownList.Items.Add(cab.code);

            addHelperLabel.ForeColor = System.Drawing.Color.Green;
            status = "Cabinet succesfully added!";
        }

        addHelperLabel.Text = status;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        ListBox list = deleteListBox;
        for (int i = list.Items.Count - 1; i >= 0; i--)
        {
            if (list.Items[i].Selected)
            {
                ws.deleteCabinet(list.Items[i].Text);

                updateDropDownList.Items.Remove(list.Items[i].Text);
                list.Items.RemoveAt(i);
            }
        }
    }

    protected void updateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = updateDropDownList;
        int i = list.SelectedIndex;
        if (i > 0)
        {
            titleToUpdateTextBox.Text = list.Items[i].Text;
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        DropDownList list = updateDropDownList;

        string status;
        updateHelpLabel.ForeColor = System.Drawing.Color.Red;

        int i = list.SelectedIndex;
        if (i > 0)
        {
            string title = titleToUpdateTextBox.Text;
            int id = ws.getCabinet(list.Items[i].Text).id;

            status = ws.updateCabinet(id, title);
            if (status == null)
            {
                deleteListBox.Items.FindByText(list.Items[i].Text).Text = title;
                updateDropDownList.Items.FindByText(list.Items[i].Text).Text = title;

                updateHelpLabel.ForeColor = System.Drawing.Color.Green;
                status = "Cabinet succesfully updated!";
            }
        }
        else
        {
            status = "Please select cabinet to update!";
        }
        updateHelpLabel.Text = status;
    }
}