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
    public partial class TruyenDetail : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-2EP69KG\SQLEXPRESS;Initial Catalog=WebDocTruyen;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter dad = new SqlDataAdapter();
        string id;
        string Ma = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"].ToString();
            Ma = id;
            con = new SqlConnection(str);
            con.Open();
            loadDetail();
            loadDSChuongTruyen();
        }
        public void loadDetail()
        {
            com = con.CreateCommand();
            com.CommandText = "select T.MaT, T.TenT, T.Mota, T.Nguon, T.HinhAnh, T.TrangThai, TL.TenTL, TG.TenTG from tblTruyen as T, tblTheLoai as TL, tblTacGia as TG where TG.MaTG = T.MaTG and TL.MaTL = T.MaTL and T.MaT= " + Ma;
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                imgTruyen.Attributes["src"] = r["HinhAnh"].ToString();
                lbTenTruyen.Text= r["TenT"].ToString();
                lbMota.Text= r["Mota"].ToString();
                lbTacGia.Text="Tác Giả: "+ r["TenTG"].ToString(); ;
                lbTheLoai.Text="Thể Loại: "+ r["TenTL"].ToString(); 
                lbNguon.Text="Nguồn: "+ r["Nguon"].ToString(); 
                lbTrangThai.Text="Trạng Thái: "+ r["TrangThai"].ToString();
            }
        }
        public void loadDSChuongTruyen()
        {
            com = con.CreateCommand();
            com.CommandText = "select ROW_NUMBER() OVER (ORDER BY MaCT) AS stt,  * from tblChuongTruyen where MaT= " + Ma;
            dad.SelectCommand = com;
            DataSet ds = new DataSet();
            dad.Fill(ds);
            DLCT.DataSource = ds;
            DLCT.DataBind();
        }
    }
}