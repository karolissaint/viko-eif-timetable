using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;

public partial class Admin_LectureTitlesPage : System.Web.UI.Page
{
    LectureTitle lectureTitle;
    WebService ws;
    List<LectureTitle> lectureTitles;
    protected void Page_Load(object sender, EventArgs e)
    {
        lectureTitle = new LectureTitle();
        ws = new WebService();
        lectureTitles = ws.getLectureTitles().OrderBy(s => s.title).ToList();
        if (!IsPostBack)
        {
            updateDropDownList.Items.Insert(0, new ListItem("Please select", ""));
            foreach (LectureTitle item in lectureTitles)
            {
                deleteListBox.Items.Add(item.title);
                updateDropDownList.Items.Add(item.title);
            }
        }
    }

    protected void insertButton_Click(object sender, EventArgs e)
    {
        lectureTitle.title = titleTextBox.Text;

        string status = ws.insertLectureTitle(lectureTitle.title);
        addHelperLabel.ForeColor = System.Drawing.Color.Red;

        if (status == null)
        {
            deleteListBox.Items.Add(lectureTitle.title);
            updateDropDownList.Items.Add(lectureTitle.title);

            addHelperLabel.ForeColor = System.Drawing.Color.Green;
            status = "Week succesfully added!";
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
                ws.deleteLectureTitle(list.Items[i].Text);

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
            int id = ws.getLectureTitle(list.Items[i].Text).id;

            status = ws.updateLectureTitle(id, title);
            if (status == null)
            {
                deleteListBox.Items.FindByText(list.Items[i].Text).Text = title;
                updateDropDownList.Items.FindByText(list.Items[i].Text).Text = title;

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