using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Instantiate Service
        LoginRegisterService.LoginRegisterServiceClient lrsc = new LoginRegisterService.LoginRegisterServiceClient();
        
        //Assign text box content to object properties
        LoginRegisterService.Fan fan = new LoginRegisterService.Fan();
        fan.FanName = txtFanName.Text;
        fan.FanEmail = txtFanEmail.Text;
        LoginRegisterService.FanLogin fl = new LoginRegisterService.FanLogin();
        fl.FanLoginUserName = txtUserName.Text;
        fl.FanLoginPasswordPlain = txtConfirm.Text;

        //Call the register method in the service
        bool result = lrsc.RegisterFan(fan, fl);

        //Check the results
        if(result)
        {
            lblResult.Text = "You have successfully registered";
        }
        else
        {
            lblResult.Text = "Registration failed";
        }
    }
    protected void lblLogin_Click(object sender, EventArgs e)
    {

    }
}

