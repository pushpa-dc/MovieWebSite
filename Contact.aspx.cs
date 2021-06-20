using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWebsite
{
    public partial class Contact : Page
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["CurrentUser"] == null)
            //    Response.Redirect("/");
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            string gender = male.Checked ? "Male" : "Female";

            string name_txt = name.Text;
            string address_txt = address.Text;
            string phone_txt = phone.Text;
            //int drp = int.Parse(drp_list.SelectedItem.Value);

            string all = name_txt + address_txt + phone_txt;
            render.Text = all;
            if (!(string.IsNullOrWhiteSpace(name_txt) || string.IsNullOrWhiteSpace(address_txt)))
            {

                //string insertQuery = $"insert into students(Name,Address,Faculty) values('{ name_txt}','{ address_txt}',{drp});";
                //SqlConnection connection = new SqlConnection(conString);
                //SqlCommand cmd = connection.CreateCommand();
                //cmd.CommandText = insertQuery;
                //connection.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                //connection.Close();
                //connection.Dispose();

            }


            //if (!String.IsNullOrWhiteSpace(all))
            //    render.Text = "Name : " + name_txt + "Address : " + address_txt + "Phone : " + phone_txt + "Faculty :   " + drp_list.SelectedItem.Text + gender;

        }

        protected void Del_Item(object sender, EventArgs e)
        {

            //string del = "delete from students";
            //SqlConnection con = new SqlConnection(conString);
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = del;
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //con.Dispose();
        }
    }
}
