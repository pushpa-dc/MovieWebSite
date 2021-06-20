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
    public partial class Detail : System.Web.UI.Page
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string movieId = this.Request.Params["id"];
            string selectStmt = $@"select m.MovieId as Id,m.MovieDescription as Description, m.MovieName as Movie, YEAR(m.ReleaseDate ) AS [Release Year],
                                g.GenereName as Genre,d.DirectorName as Director,concat ('<img src=''/Content/Img/',m.Img,''' height=''100'' class=''poster''  />')Poster,
        concat('<a href=''/Default?id=', m.MovieId,'''>',' 
        <img src=''Content/edit.png'' height=''30'' class=''edt'' />','</a>')Edit,
        concat('<a href=''/Default?Removeid=', m.MovieId,'''>','Delete','</a>') [Delete]                        
        from movies m 
        join genres g on m.genre = g.GenereId
        join director d on m.director = d.DirectorId where MovieId={movieId}";

            

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = selectStmt;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            datalist1.DataSource = ds;
            datalist1.DataBind();
            con.Close();
            con.Dispose();
        }

    }
}