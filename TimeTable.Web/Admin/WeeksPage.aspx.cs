using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;

public partial class Admin_WeeksPage : System.Web.UI.Page
{
    Week week;
    WebService ws;
    List<Week> weeks;

    protected void Page_Load(object sender, EventArgs e)
    {
        week = new Week();
        ws = new WebService();
        weeks = ws.getWeeks().OrderBy(s => s.title).ToList();
        if (!IsPostBack)
        {
            weeksToUpdateDropDownList.Items.Insert(0, new ListItem("Please select", ""));
            foreach (Week item in weeks)
            {
                weeksToDeleteListBox.Items.Add(item.title);
                weeksToUpdateDropDownList.Items.Add(item.title);
            }
        }
    }

    protected void insertButton_Click(object sender, EventArgs e)
    {
        week.title = weekTitleTextBox.Text;

        string status = ws.insertWeek(week.title);
        addWeekHelperLabel.ForeColor = System.Drawing.Color.Red;

        if (status == null)
        {
            weeksToDeleteListBox.Items.Add(week.title);
            weeksToUpdateDropDownList.Items.Add(week.title);

            addWeekHelperLabel.ForeColor = System.Drawing.Color.Green;
            status = "Week succesfully added!";
        }

        addWeekHelperLabel.Text = status;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        ListBox list = weeksToDeleteListBox;
        for (int i = list.Items.Count - 1; i >= 0; i--)
        {
            if (list.Items[i].Selected)
            {
                ws.deleteWeek(list.Items[i].Text);

                weeksToUpdateDropDownList.Items.Remove(list.Items[i].Text);
                list.Items.RemoveAt(i);
            }
        }
    }

    protected void weeksToUpdateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = weeksToUpdateDropDownList;
        int i = list.SelectedIndex;
        if (i > 0)
        {
            weekTitleToUpdateTextBox.Text = list.Items[i].Text;
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        DropDownList list = weeksToUpdateDropDownList;

        string status;
        updateHelpLabel.ForeColor = System.Drawing.Color.Red;

        int i = list.SelectedIndex;
        if (i > 0)
        {
            string title = weekTitleToUpdateTextBox.Text;
            int id = ws.getWeek(list.Items[i].Text).id;

            status = ws.updateWeek(id, title);
            if (status == null)
            {
                weeksToDeleteListBox.Items.FindByText(list.Items[i].Text).Text = title;
                weeksToUpdateDropDownList.Items.FindByText(list.Items[i].Text).Text = title;

                updateHelpLabel.ForeColor = System.Drawing.Color.Green;
                status = "Week succesfully updated!";
            }
        }
        else
        {
            status = "Please select week to update!";
        }
        updateHelpLabel.Text = status;
    }
}