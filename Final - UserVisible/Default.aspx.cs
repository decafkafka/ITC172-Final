using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Instantiate the service
        LoginRegisterService.LoginRegisterServiceClient lrsc = new LoginRegisterService.LoginRegisterServiceClient();

        //Call the method
        int id = lrsc.FanLogin(txtUserName.Text, txtPassword.Text);

        //Check the results
        if (id != 0)
        {
            Session["id"] = id;
            Response.Redirect("Search.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid Login";
        }
    }
}