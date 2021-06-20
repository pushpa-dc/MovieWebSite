using MovieWebsite.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MovieWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text;
            string password = txt_Password.Text;

            if (!(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)))
            {

                string selectQuery = $@"select * from users where username='{userName}'
                                        and password='{password}'";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = selectQuery;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    SetSession(reader);
                    Response.Redirect("/Movies.aspx");
                }
                while (reader.Read())
                {
                    reader.GetString(1);
                }
                con.Close();
                con.Dispose();
            }
            else
            {
                SetErrorMessage();
            }

        }

        private void SetSession(SqlDataReader reader)
        {
            AppUser user = null;
            while (reader.Read())
            {
                user = new AppUser
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    FName = reader["FName"].ToString(),
                    LName = reader["LName"].ToString(),
                    MName = reader["MName"].ToString(),
                    Address = reader["Address"].ToString(),
                    Img = reader["ProfileImg"].ToString(),
                    UserName = reader["FName"].ToString()
                };
            }
            Session["CurrentUser"] = user;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //if (Session["CurrentUser"] != null)
            //    Response.Redirect("/");
        }
        private void SetErrorMessage()
        {
            msg_error.Visible = true;
            var ctrl = new HtmlGenericControl("p") { InnerText = "Invalid credentials" };
            ctrl.Style.Add("color", "white");
            ctrl.Style.Add("background-color", "red");
            ctrl.Style.Add("padding", "5px");
            msg_error.Controls.Add(ctrl);
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            string Fname = firstName.Text;
            string Lnme = lastName.Text;
            string UName = UserName.Text;
            string Password = UserPassword.Text;

            string path = Server.MapPath("/Content/Img/");
            string uploadImage = "null";
            if (FileUploadSign.HasFile)
            {
                string ext = Path.GetExtension(FileUploadSign.FileName);
                if (ext == ".jpg" || ext == ".png")
                {
                    FileUploadSign.SaveAs(path + FileUploadSign.FileName);
                    uploadImage = "Content/Img/" + FileUploadSign.FileName;
                    error_1.Text = "File upload successfully";
                }
                else
                {
                    error_1.Text = "YOu only allowed to insert jpg and png image.";
                }
            }
            if (!(string.IsNullOrWhiteSpace(Fname) || string.IsNullOrWhiteSpace(Lnme) 
                || string.IsNullOrWhiteSpace(UName) ||
                string.IsNullOrWhiteSpace(Password)))
            {
                string insert = $"insert into users(FName,LName,UserName,Password,ProfileImg)" +
                    $" values('{Fname}','{Lnme}','{UName}','{Password}','{uploadImage}')";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = insert;
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Redirect("/Movies.aspx");
            }
            else
            {
                sinUpErrMsg();
            }

        }

        private void sinUpErrMsg()
        {
            msg_error1.Visible = true;

        }

    }
}