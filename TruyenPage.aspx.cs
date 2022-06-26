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
    public partial class TruyenPage : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-2EP69KG\SQLEXPRESS;Initial Catalog=WebDocTruyen;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter dad = new SqlDataAdapter();
        string id;
        string loaiTruyen = "";
        string Ma = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"].ToString();
            con = new SqlConnection(str);
            con.Open();
            loadTieuDe();
            loadTruyen();
        }
        public void loadTieuDe()
        {
            loaiTruyen = id[0].ToString() + id[1].ToString();
            lbTieuDe.Text = loaiTruyen;
            Ma = id[2].ToString();
            if (loaiTruyen.Equals("DM"))
            {
                com = con.CreateCommand();
                com.CommandText = "Select * from tblDanhMuc where MaDM="+Ma;
                dad.SelectCommand = com;
                DataTable dt = new DataTable();
                dad.Fill(dt);
                foreach(DataRow r in dt.Rows)
                {
                    lbTieuDe.Text = r["TenDM"].ToString();
                }
            }
            else
            {
                com = con.CreateCommand();
                com.CommandText = "Select * from tblTheLoai where MaTL=" + Ma;
                dad.SelectCommand = com;
                DataTable dt = new DataTable();
                dad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    lbTieuDe.Text = r["TenTL"].ToString();
                }
            }
        }
        public void loadTruyen()
        {
            if (loaiTruyen.Equals("DM"))
            {
                com = con.CreateCommand();
                com.CommandText = "Select tblTruyen.MaT, tblTruyen.TenT, tblTruyen.HinhAnh, tblTacGia.TenTG, (select count(tblChuongTruyen.MaCT) from tblChuongTruyen where tblChuongTruyen.MaT= tblTruyen.MaT) as soCT from tblTacGia, tblTruyen where tblTacGia.MaTG= tblTruyen.MaTG and tblTruyen.MaDM=" + Ma;
                dad.SelectCommand = com;
                DataSet ds = new DataSet();
                dad.Fill(ds);
                DLT.DataSource = ds;
                DLT.DataBind();
            }
            else
            {
                com = con.CreateCommand();
                com.CommandText = "Select tblTruyen.MaT, tblTruyen.TenT, tblTruyen.HinhAnh, tblTacGia.TenTG, (select count(tblChuongTruyen.MaCT) from tblChuongTruyen where tblChuongTruyen.MaT= tblTruyen.MaT) as soCT from tblTacGia, tblTruyen where tblTacGia.MaTG= tblTruyen.MaTG and tblTruyen.MaTL=" + Ma;
                dad.SelectCommand = com;
                DataSet ds = new DataSet();
                dad.Fill(ds);
                DLT.DataSource = ds;
                DLT.DataBind();
            }
        }

    }
}