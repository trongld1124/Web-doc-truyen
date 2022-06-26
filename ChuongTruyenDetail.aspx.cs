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
    public partial class ChuongTruyenDetail : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-2EP69KG\SQLEXPRESS;Initial Catalog=WebDocTruyen;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter dad = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string id = "";
        string MaCT = "";
        string MaT = "";
        string chuonght = "";
        int tongchuong = 0;
        string NoiDung = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"].ToString();
            MaCT = id;
            con = new SqlConnection(str);
            con.Open();
            loadCT();
        }
        public void loadCT()
        {
            com = con.CreateCommand();
            com.CommandText = "select * from tblChuongTruyen where MaCT=" + MaCT;
            dad.SelectCommand = com;
            dt.Clear();
            dad.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                MaT = r["MaT"].ToString();
            }
            /**/
            com = con.CreateCommand();
            com.CommandText = "select ROW_NUMBER() OVER (ORDER BY tblChuongTruyen.MaCT) AS stt,  tblChuongTruyen.MaCT, tblChuongTruyen.NoiDung, tblChuongTruyen.TenCT, tblTruyen.TenT from tblChuongTruyen, tblTruyen where tblTruyen.MaT= tblChuongTruyen.MaT and tblChuongTruyen.MaT=" + MaT;
            dad.SelectCommand = com;
            dt.Clear();
            dad.Fill(dt);
            tongchuong = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (MaCT.Equals(r["MaCT"].ToString()))
                {
                    lbTenT.Text = r["TenT"].ToString();
                    lbTenCT.Text ="Chương "+ r["stt"].ToString()+": "+ r["TenCT"].ToString();
                    chuonght = r["stt"].ToString();
                    NoiDung= r["NoiDung"].ToString();
                    loadND(NoiDung);
                }
                tongchuong++;
            }
        }
        public void loadND(string ND)
        {
            DataTable dtND = new DataTable();
            DataColumn nd = new DataColumn("nd");
            dtND.Columns.Add(nd);
            char[] delimiterChars = { '”', '.' };
            string[] words = ND.Split(delimiterChars);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains("“"))
                {
                    words[i] += "”";
                }
                else if (words[i].Contains("."))
                {
                    words[i] += "..";
                }
                else
                {
                    words[i] += ".";
                }
                DataRow row = dtND.NewRow();
                row["nd"] = words[i];
                dtND.Rows.Add(row);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dtND);
            DLND.DataSource = ds;
            DLND.DataBind();
        }

        protected void btnSau_Click(object sender, EventArgs e)
        {
            if (chuonght.Equals(tongchuong.ToString()))
            {
                return;
            }
            else
            {
                int cht = int.Parse(chuonght) + 1;
                string MaSau = getMaCT(cht.ToString());
                Response.Redirect("ChuongTruyenDetail.aspx?ID=" + MaSau);
            }
        }

        protected void btnTruoc_Click(object sender, EventArgs e)
        {
            if (chuonght.Equals("1")){
                return;
            }
            else
            {
                int cht = int.Parse(chuonght) - 1;
                string MaTruoc = getMaCT(cht.ToString());
                Response.Redirect("ChuongTruyenDetail.aspx?ID=" + MaTruoc);
            }
        }
        public string getMaCT(string numCT)
        {
            string kq = "";
            foreach (DataRow r in dt.Rows)
            {
                if (numCT.Equals(r["stt"].ToString()))
                {
                    kq = r["MaCT"].ToString();
                }
            }
            return kq;
        }
    }
}