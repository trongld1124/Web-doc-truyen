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
    public partial class AdminHP : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-2EP69KG\SQLEXPRESS;Initial Catalog=WebDocTruyen;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter dad = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            ktSS();
            con = new SqlConnection(str);
            con.Open();
            loadData();
            
        }
        public void ktSS()
        {

            if ((Boolean)Session["admin"] == false)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        public void loadData()
        {
            DataTable dt = new DataTable();
            com = con.CreateCommand();
            com.CommandText = "select count(tblTruyen.MaT) as TongT from tblTruyen;";
            dad.SelectCommand = com;
            dt.Clear();
            dad.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                lbTongT.Text = r["TongT"].ToString();
            }
            com = con.CreateCommand();
            com.CommandText = "select count(tblChuongTruyen.MaCT) as TongCT from tblChuongTruyen;";
            dad.SelectCommand = com;
            dt.Clear();
            dad.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                lbTongCT.Text = r["TongCT"].ToString();
            }
            com = con.CreateCommand();
            com.CommandText = "select count(tblTacGia.MaTG) as TongTG from tblTacGia;";
            dad.SelectCommand = com;
            dt.Clear();
            dad.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                lbTongTG.Text = r["TongTG"].ToString();
            }
        }
    }
}