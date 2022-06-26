using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Web_Doc_Truyen
{
    public partial class LoginPage : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-2EP69KG\SQLEXPRESS;Initial Catalog=WebDocTruyen;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter dad = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
        }

        protected void tbnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Value.ToString();
            string password = txtPassword.Value.ToString();
            if (username.Length == 0 || password.Length == 0)
            {
                lbTB.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }
            else
            {
                com = con.CreateCommand();
                com.CommandText = "select * from tblAdmin";
                dad.SelectCommand = com;
                DataTable dt = new DataTable();
                dad.Fill(dt);
                bool kq = false;
                foreach(DataRow r in dt.Rows)
                {
                    if (username.Equals(r["Username"].ToString()) && password.Equals(r["Password"].ToString()))
                    {
                        kq = true;
                    }
                }
                if (kq)
                {
                    Session["admin"] = true;
                    Response.Redirect("AdminHP.aspx");
                }
                else
                {
                    lbTB.Text = "Thông tin đăng nhập không đúng!";
                }
            }
        }
    }
}