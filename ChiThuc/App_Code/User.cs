using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime ns { get; set; }


    public User()
    {

    }
    public User(int id, string name, string email, string password, DateTime ns)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.password = password;
        this.ns = ns;

    }
}

