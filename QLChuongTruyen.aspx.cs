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
    public partial class QLChuongTruyen : System.Web.UI.Page
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
            txtTenT.Enabled = false;
            txtMaCT.Enabled = false;
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
            com = con.CreateCommand();
            com.CommandText = "select *, (select tblTruyen.TenT from tblTruyen where tblTruyen.MaT= tblChuongTruyen.MaT ) as TenT from tblChuongTruyen";
            dad.SelectCommand = com;
            DataSet ds = new DataSet();
            dad.Fill(ds);
            DLChuongTruyen.DataSource = ds;
            DLChuongTruyen.DataBind();
        }
        protected void btnDoDL_Click(Object sender, EventArgs e)
        {
            LinkButton btnClick = (LinkButton)sender;
            string more = btnClick.CommandArgument.ToString();
            com = con.CreateCommand();
            com.CommandText = "select *, (select tblTruyen.TenT from tblTruyen where tblTruyen.MaT= tblChuongTruyen.MaT ) as TenT from tblChuongTruyen";
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                if (more.Equals(r["MaCT"].ToString()))
                {
                    txtMaCT.Text = r["MaCT"].ToString();
                    txtTenCT.Text = r["TenCT"].ToString();
                    txtMaT.Text = r["MaT"].ToString();
                    txtTenT.Text = r["TenT"].ToString();
                    txtND.Value = r["NoiDung"].ToString();
                }
            }
        }
        public void reset()
        {
            txtMaCT.Text = "";
            txtTenCT.Text = "";
            txtMaT.Text = "";
            txtTenT.Text = "";
            txtND.Value = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtMaCT.Text.Length != 0)
            {
                lbThongBao.Text = "Vui lòng làm tươi trước khi thêm !";
                return;
            }
            string TenCT = txtTenCT.Text;
            string MaT = txtMaT.Text;
            string ND = txtND.Value.ToString();
            if (TenCT.Length == 0 || MaT.Length == 0 || ND.Length == 0)
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ thông tin rồi thêm";
                return;
            }
            if (txtTenT.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng kiểm tra mã Truyện trước rồi thêm";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "insert into tblChuongTruyen(TenCT, MaT, NoiDung) values (N'" + TenCT + "', " + MaT + ", N'" + ND + "')";
                com.ExecuteNonQuery();
                lbThongBao.Text = "Thêm thành công!";
                loadData();
                reset();
            }
            catch(Exception ex)
            {
                lbThongBao.Text = "Thêm thất bại!";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtMaCT.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng chọn Chương Truyện để sửa!";
                return;
            }
            string TenCT = txtTenCT.Text;
            string MaT = txtMaT.Text;
            string ND = txtND.Value.ToString();
            if (TenCT.Length == 0 || MaT.Length == 0 || ND.Length == 0)
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ thông tin rồi sửa!";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "update tblChuongTruyen set TenCT= N'"+TenCT+"', MaT= "+MaT+", NoiDung= N'"+ND+"' where MaCT= "+txtMaCT.Text;
                com.ExecuteNonQuery();
                lbThongBao.Text = "Sửa thành công!";
                loadData();
                reset();
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Sửa thất bại!";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txtMaCT.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng chọn Chương Truyện để xóa!";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "delete from tblChuongTruyen where MaCT="+ txtMaCT.Text;
                com.ExecuteNonQuery();
                lbThongBao.Text = "Xóa thành công!";
                loadData();
                reset();
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Xóa thất bại!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            reset();
            loadData();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            com = con.CreateCommand();
            com.CommandText = "select * from tblTruyen";
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                if (txtMaT.Text.Equals(r["MaT"].ToString()))
                {
                    txtTenT.Text = r["TenT"].ToString();
                }
            }
        }
    }
}