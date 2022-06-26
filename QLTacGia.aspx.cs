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
    public partial class QLTacGia : System.Web.UI.Page
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
            com = con.CreateCommand();
            com.CommandText = "select * from tblTacGia";
            dad.SelectCommand = com;
            DataSet ds = new DataSet();
            dad.Fill(ds);
            DLTacGia.DataSource = ds;
            DLTacGia.DataBind();
        }
        protected void btnDoDL_Click(Object sender, EventArgs e)
        {
            LinkButton btnClick = (LinkButton)sender;
            string more = btnClick.CommandArgument.ToString();
            com = con.CreateCommand();
            com.CommandText = "select * from tblTacGia";
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                if (more.Equals(r["MaTG"].ToString()))
                {
                    txtMaTG.Text = r["MaTG"].ToString();
                    txtTenTG.Text = r["TenTG"].ToString();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtMaTG.Text.Length!=0)
            {
                lbThongBao.Text = "Vui lòng làm tươi dữ liệu rồi thêm mới";
                return;
            }
            if (txtTenTG.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng nhập Tên TG để thêm";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "insert into tblTacGia(TenTG) values(N'"+txtTenTG.Text+"')";
                com.ExecuteNonQuery();
                lbThongBao.Text = "Thêm thành công";
                reset();
                loadData();
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Thêm thất bại!";
            }
        }
        public void reset()
        {
            txtMaTG.Text = "";
            txtMaTG.Enabled = false;
            txtTenTG.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            reset();
            loadData();
            lbThongBao.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtMaTG.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng chọn Tác Giả để sửa";
                return;
            }
            if (txtTenTG.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng nhập Tên TG để Sửa";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "update tblTacGia set TenTG= N'"+txtTenTG.Text+"' where MaTG= "+txtMaTG.Text;
                com.ExecuteNonQuery();
                lbThongBao.Text = "Sửa thành công";
                reset();
                loadData();
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Sửa thất bại!";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txtMaTG.Text.Length == 0)
            {
                lbThongBao.Text = "Vui lòng chọn Tác Giả để xóa";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "delete from tblTacGia where MaTG= " + txtMaTG.Text;
                com.ExecuteNonQuery();
                lbThongBao.Text = "Xóa thành công";
                reset();
                loadData();
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Xóa thất bại!";
            }
        }
    }
}