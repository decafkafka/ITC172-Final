using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginRegisterService" in code, svc and config file together.
public class LoginRegisterService : ILoginRegisterService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();

    public bool RegisterFan(Fan f, FanLogin fl)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetKeyCode();
            byte[] hashed = ph.HashIt(fl.FanLoginPasswordPlain, code.ToString());

            Fan fan = new Fan();
            fan.FanName = f.FanName;
            fan.FanEmail = f.FanEmail;
            fan.FanDateEntered = DateTime.Now;
            FanLogin fanl = new FanLogin();
            fanl.FanLoginUserName = fl.FanLoginUserName;
            fanl.FanLoginPasswordPlain = fl.FanLoginPasswordPlain;
            fanl.FanLoginRandom = code;
            fanl.FanLoginHashed = hashed;
            fanl.FanLoginDateAdded = DateTime.Now;
            ste.Fans.Add(fan);
            ste.FanLogins.Add(fanl);
            ste.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public int FanLogin(string userName, string Password)
    {
        int id = 0;

        LoginClass lc = new LoginClass(Password, userName);
        id = lc.ValidateLogin();

        return id;
    }
}
