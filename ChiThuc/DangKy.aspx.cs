﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChiThuc
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loi.Text = "";    
        }
        protected void btndangky_click(object sender, EventArgs e)
        {
            if (Request.Form["nameRegister"] != null)
            {
                string name = Request.Form["nameRegister"];
                string email = Request.Form["emailRegister"];
                string password = Request.Form["PasswordRegister"];
                string repassword = Request.Form["RepasswordRegister"];
                string dob = Request.Form["dobRegister"];
                //User user = new User(name, email, password, repassword, dob);
                List<User> arr = (List<User>)Application["user"];
                if (password != repassword)
                {
                    loi.Text = "Mật khẩu và xác nhận mật khẩu không giống nhau!";
                    return;
                }
                int tg = 0;
                if (arr.Count == 0)
                {
                    arr = new List<User>();
                }
                else
                {
                    foreach (User u in arr)
                    {
                        if (u.email != email)
                        {

                        }
                        else
                        {
                            loi.Text = "Email đã tồn tại. Vui long nhập email khác !";
                            tg = 1;
                        }
                    }
                }
                if (tg == 1)
                {

                }
                else
                {
                    //arr.Add(user);
                    Application["user"] = arr;
                    Session["login"] = 1;
                    Session["name"] = name;
                    Session["email"] = email;
                    Response.Redirect("Trangchu.aspx");
                }

            }
        }

      
    }
}