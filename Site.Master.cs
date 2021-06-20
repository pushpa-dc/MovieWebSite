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
    public partial class SiteMaster : MasterPage
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           string movieId = this.Request.Params["profilid"];
            string selectStmt = $"select * from users where Id=1007";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = selectStmt;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                reader.GetString(1);
            }
            //profileImage.DataSource = reader;
            //profileImage.DataBind();
            con.Close();
            con.Dispose();

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string selectStmt = $@"select Id, FName as [First Name], LName as [Last Name], UserName AS [User Name],
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
            //userlist.DataSource = ds;
            //userlist.DataBind();
            //con.Close();
            //con.Dispose();

        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("/Login");
        }

        protected void profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Profile.aspx");
        }

        
    }
}