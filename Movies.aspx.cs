using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MovieWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string selectStmt = @"select m.MovieId as Id,m.MovieDescription as Description, m.MovieName as Movie, YEAR(m.ReleaseDate ) AS [Release Year],
                                g.GenereName as Genre,d.DirectorName as Director,concat ('<img src=''/Content/Img/',m.Img,''' height=''100'' class=''poster''  />')Poster,
        concat('<a href=''/Default?id=', m.MovieId,'''>',' 
        <img src=''Content/edit.png'' height=''30'' class=''edt'' />','</a>')Edit,
        concat('<a href=''/Default?Removeid=', m.MovieId,'''>','Delete','</a>') [Delete]                        
        from movies m 
        join genres g on m.genre = g.GenereId
        join director d on m.director = d.DirectorId;";


            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = selectStmt;
            con.Open();
            SqlDataAdapter sda =new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            datalist.DataSource = ds;
            datalist.DataBind();
            con.Close();
            con.Dispose();
        }
    }
}