using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebServiceReference;

public partial class Admin_LecturersPage : System.Web.UI.Page
{
    WebService ws;
    Lecturer lec;
    List<Lecturer> lecs;
    protected void Page_Load(object sender, EventArgs e)
    {
        ws = new WebService();
        lec = new Lecturer();
        lecs = ws.getLecturers().OrderBy(l => l.name).ToList();
        if (!IsPostBack)
        {
            updateDropDownList.Items.Insert(0, new ListItem("Please select", ""));
            deleteListBox.Items.Clear();
            foreach (Lecturer item in lecs)
            {
                deleteListBox.Items.Add(item.name + " " + item.lastname);
                updateDropDownList.Items.Add(item.name + " " + item.lastname);
            }
        }

    }

    protected void insertButton_Click(object sender, EventArgs e)
    {
        lec.name = nameTextBox.Text;
        lec.lastname = lastnameTextBox.Text;
        string status = ws.insertLecturer(lec.name, lec.lastname);

        addHelperLabel.ForeColor = System.Drawing.Color.Red;

        if (status == null)
        {
            deleteListBox.Items.Add(lec.name + " " + lec.lastname);
            updateDropDownList.Items.Add(lec.name + " " + lec.lastname);

            addHelperLabel.ForeColor = System.Drawing.Color.Green;
            status = "Lecturer succesfully added!";
        }
        addHelperLabel.Text = status;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        ListBox deleteList = deleteListBox;
        DropDownList updateList = updateDropDownList;
        for (int i = deleteList.Items.Count - 1; i >= 0; i--)
        {
            if (deleteList.Items[i].Selected)
            {
                string[] words = deleteList.Items[i].Text.Split(' ');
                string name = words[0];
                string lastname = words[1];
                int id = ws.getLecturer(name, lastname).id;
                ws.deleteLecturer(id);
                updateList.Items.Remove(deleteList.Items[i].Text);
                deleteList.Items.RemoveAt(i);
            }
        }
    }

    protected void groupsToUpdateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = updateDropDownList;
        int i = list.SelectedIndex;
        if (i > 0)
        {
            string[] words = list.Items[i].Text.Split(' ');
            string name = words[0];
            string lastname = words[1];
            nameToUpdateTextBox.Text = name;
            lastnameToUpdateTextBox.Text = lastname;
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

            string[] words = list.Items[i].Text.Split(' ');
            int id = ws.getLecturer(words[0], words[1]).id;

            status = ws.updateLecturer(id, nameToUpdateTextBox.Text, lastnameToUpdateTextBox.Text);
            if (status == null)
            {
                string name = nameToUpdateTextBox.Text;
                string lastname = lastnameToUpdateTextBox.Text;
                deleteListBox.Items.FindByText(list.Items[i].Text).Text = name + " " + lastname;
                updateDropDownList.Items.FindByText(list.Items[i].Text).Text = name + " " + lastname;

                updateHelpLabel.ForeColor = System.Drawing.Color.Green;
                status = "Lecturer succesfully updated!";
            }
        }
        else
        {
            status = "Please select lecturer to update!";
        }
        updateHelpLabel.Text = status;
    }
}