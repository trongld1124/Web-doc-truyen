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
    public partial class QLTruyen : System.Web.UI.Page
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
            txtMaT.Enabled = false;
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
            com.CommandText = "select T.*, (select tblDanhMuc.TenDM from tblDanhMuc where tblDanhMuc.MaDM= T.MaDM) as TenDM, (select tblTheLoai.TenTL from tblTheLoai where tblTheLoai.MaTL= T.MaTL) as TenTL  from tblTruyen as T";
            dad.SelectCommand = com;
            DataSet ds = new DataSet();
            dad.Fill(ds);
            DLTruyen.DataSource = ds;
            DLTruyen.DataBind();

        }
        protected void btnDoDL_Click(Object sender, EventArgs e)
        {
            LinkButton btnClick = (LinkButton)sender;
            string more = btnClick.CommandArgument.ToString();
            com = con.CreateCommand();
            com.CommandText = "select T.*, (select tblDanhMuc.TenDM from tblDanhMuc where tblDanhMuc.MaDM= T.MaDM) as TenDM, (select tblTheLoai.TenTL from tblTheLoai where tblTheLoai.MaTL= T.MaTL) as TenTL  from tblTruyen as T";
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                if (more.Equals(r["MaT"].ToString()))
                {
                    txtMaT.Text = r["MaT"].ToString();
                    txtMaT.Enabled = false;
                    txtTenT.Text = r["TenT"].ToString();
                    txtMaDM.Text = r["TenDM"].ToString();
                    txtMaDM.Enabled = false;
                    txtMaTL.Text = r["TenTL"].ToString();
                    txtMaTL.Enabled = false;
                    txtMaTG.Text = r["MaTG"].ToString();
                    txtMaTG.Enabled = false;
                    txtNguon.Text = r["Nguon"].ToString();
                    txtMoTa.Value = r["Mota"].ToString();
                    txtTT.Text = r["TrangThai"].ToString();
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string MaT = txtMaT.Text;
            string TenT = txtTenT.Text;
            string DM = txtMaDM.Text;
            string TL = txtMaTL.Text;
            string TG = txtMaTG.Text;
            string Nguon = txtNguon.Text;
            string Mota = txtMoTa.Value.ToString();
            string TT = txtTT.Text;
            int MaTG;
            try
            {
                MaTG=int.Parse(TG);
            }
            catch(Exception exc)
            {
                lbThongBao.Text = "Vui lòng nhập đúng các giá trị!";
                return;
            }
            if (TenT.Length == 0 || DM.Length == 0 || TL.Length == 0 || TG.Length == 0 || Nguon.Length == 0 || Mota.Length == 0 || TT.Length == 0)
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ các giá trị!";
                return;
            }
            string ImgUrl;
            if (ful.HasFile)
            {
                ImgUrl = "./imgTruyen/" + ful.FileName;
                ful.SaveAs(Server.MapPath("./imgTruyen/" + ful.FileName));
                lbThongBao.Text = ImgUrl;
            }
            else
            {
                lbThongBao.Text = "Vui Lòng Chọn File Hình Ảnh";
                return;
            }
            try
            {
                int MaDM = getMaDM(DM);
                int MaTL = getMaTL(TL);
                com = con.CreateCommand();
                com.CommandText = "insert into tblTruyen(TenT, MaDM, MaTL, MaTG, Nguon, HinhAnh, Mota, TrangThai) " +
                    "values(N'"+TenT+"', "+MaDM+", "+MaTL+", "+ MaTG + ", N'"+Nguon+"', N'"+ImgUrl+"', N'"+Mota+"', N'"+TT+"')";
                com.ExecuteNonQuery();
                lbThongBao.Text = "Thêm Thành Công!";
                loadData();
                reset();
            }
            catch (Exception exp)
            {
                lbThongBao.Text = "Thêm truyện không thành công";
                return;
            }
        }
        public int getMaDM(string TenDM)
        {
            int kq = 0;
            com = con.CreateCommand();
            com.CommandText = "select * from tblDanhMuc";
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            bool kt = false;
            foreach(DataRow r in dt.Rows)
            {
                if (TenDM.Equals(r["TenDM"].ToString()))
                {
                    kq = int.Parse(r["MaDM"].ToString());
                    kt = true;
                }
            }
            if (kt)
            {
                return kq;
            }
            else
            {
                foreach (DataRow r in dt.Rows)
                {
                    kq= int.Parse(r["MaDM"].ToString());
                }
                kq++;
                try
                {
                    com = con.CreateCommand();
                    com.CommandText = "insert into tblDanhMuc(TenDM) values(N'" + TenDM + "')";
                    com.ExecuteNonQuery();
                }
                catch(Exception ex)
                {

                }
                return kq;
            }
        }
        public int getMaTL(string TenTL)
        {
            
            int kq = 0;
            com = con.CreateCommand();
            com.CommandText = "select * from tblTheLoai";
            dad.SelectCommand = com;
            DataTable dt = new DataTable();
            dad.Fill(dt);
            bool kt = false;
            foreach (DataRow r in dt.Rows)
            {
                if (TenTL.Equals(r["TenTL"].ToString()))
                {
                    kq = int.Parse(r["MaTL"].ToString());
                    kt = true;
                }
            }
            if (kt)
            {
                return kq;
            }
            else
            {
                foreach (DataRow r in dt.Rows)
                {
                    kq = int.Parse(r["MaTL"].ToString());
                }
                kq++;
                try
                {
                    com = con.CreateCommand();
                    com.CommandText = "insert into tblTheLoai(TenTL) values(N'" + TenTL + "')";
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                return kq;
            }
        }
        public void reset()
        {
            txtMaT.Text = "";
            txtMaT.Enabled = false;
            txtTenT.Text = "";
            txtMaDM.Text = "";
            txtMaDM.Enabled = true;
            txtMaTL.Text = "";
            txtMaTL.Enabled = true;
            txtMaTG.Text = "";
            txtMaTG.Enabled = true;
            txtNguon.Text = "";
            txtMoTa.Value = "";
            txtTT.Text = "";
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            reset();
            lbThongBao.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string maT = txtMaT.Text;
            string tenT = txtTenT.Text;
            string nguon = txtNguon.Text;
            string mota = txtMoTa.Value.ToString();
            string tt = txtTT.Text;
            if (maT.Length == 0)
            {
                lbThongBao.Text = "Vui lòng chọn truyện để sửa!";
                return;
            }
            if(tenT.Length==0||nguon.Length == 0 ||mota.Length == 0 ||tt.Length == 0)
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ thông tin để sửa!";
                return;
            }
            try
            {
                com = con.CreateCommand();
                com.CommandText = "update tblTruyen set TenT= N'"+tenT+"', Nguon= N'"+nguon+"', Mota= N'"+mota+"', TrangThai= N'"+tt+"' where MaT=" + maT;
                com.ExecuteNonQuery();
                lbThongBao.Text = "Sửa thành công!";
                loadData();
                reset();
            }
            catch(Exception ex)
            {
                lbThongBao.Text = "Sửa không thành công!";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string MaT = txtMaT.Text;
            if (MaT.Length == 0)
            {
                lbThongBao.Text = "Vui lòng chọn truyện để xóa";
                return;
            }
            com = con.CreateCommand();
            com.CommandText = "delete from tblTruyen where MaT=" + MaT;
            com.ExecuteNonQuery();
            lbThongBao.Text = "Xóa thành công!";
            loadData();
            reset();
        }
    }
}