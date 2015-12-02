using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //events
        
    }

    protected void loginform_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if(loginform.UserName == "admin" && loginform.Password == "admin")
        {
            e.Authenticated = true;        
        }
        else
        {
            e.Authenticated = false;
        }
    }



    protected void loginform_LoggedIn(object sender, EventArgs e)
    {
        
    }
}