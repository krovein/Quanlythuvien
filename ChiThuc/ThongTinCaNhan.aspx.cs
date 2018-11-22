using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChiThuc
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                string name = Request.Form["ctl00$MainContent$infoname"];
                string email = Request.Form["ctl00$MainContent$infoemail"];
                string password = Request.Form["ctl00$MainContent$infoPassword"];
                string dob = Request.Form["ctl00$MainContent$infodob"];
                List<User> arr = (List<User>)Application["user"];
                foreach(User u in arr)
                {
                    if(u.email == email)
                    {
                        u.name = name;
                        u.password = password;
                        //u.repassword = password;
                        //u.dob = dob;
                      
                        break;
                    }
                }
                Application["user"] = arr;
                Session["name"] = name;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
               List<User> user = (List<User>)Application["user"];
                foreach(User u in user)
                {
                    if(Session["email"].ToString() == u.email)
                    {
                        infoname.Value = u.name;
                        infoemail.Value = u.email;
                        infoPassword.Value = u.password;
                        infoPassword.Attributes["type"] = "password";
                        //infodob.Value = u.dob;
                       
                    }
                }
                
            }
        }
    }
}