using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWebsite
{
    public partial class Profile : System.Web.UI.Page
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] == null)
                Response.Redirect("/Login");
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //string selectStmt = null;
            string UserId = this.Request.Params["Id"];
            //  string selectStmt = @"select FName as [First Name], LName as [Last Name], UserName AS [User Name],
            //                Password, CreatedDate as [Created Date] ,
            //    concat ('<img src=''/',ProfileImg,''' height=''100'' class=''poster rounded-circle''  />')
            //    Image from users where Id=1007";

            //SqlConnection con = new SqlConnection(conString);
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = selectStmt;
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //user_view.DataSource = reader;
            //user_view.DataBind();
            //con.Close();
            //con.Dispose();

           string selectStmt = $@"select FName as [First Name], LName as [Last Name], UserName AS [User Name],
            Password, CreatedDate as [Created Date] ,
            concat ('<img src=''/',ProfileImg,''' height=''50'' class=''userp rounded-circle''  />')
            Image from users where Id=1007";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = selectStmt;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            userdata.DataSource = ds;
            userdata.DataBind();
            con.Close();
            con.Dispose();
        }

        protected void user_view_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[5].Text);
                e.Row.Cells[5].Text = decodedText;
            }
        }
    }
}
