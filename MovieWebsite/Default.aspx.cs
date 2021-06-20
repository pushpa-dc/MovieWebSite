using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWebsite
{
    public partial class Default : Page
    {
        readonly string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        private void LoadGenre()
        {

            string selectStmt = "select * from genres";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = selectStmt;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            drp_genre.DataSource = reader;
            drp_genre.DataTextField = "GenereName";
            drp_genre.DataValueField = "GenereId";
            drp_genre.DataBind();
            con.Close();
            con.Dispose();
        }

        private void LoadDirector()
        {
            string sql = "select * from director";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            director_dropdown.DataSource = reader;
            director_dropdown.DataTextField = "DirectorName";
            director_dropdown.DataValueField = "Directorid";
            director_dropdown.DataBind();
            con.Close();
            con.Dispose();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {

            string selectStmt = @"select m.MovieId as Id, m.MovieName as Movie, YEAR(m.ReleaseDate ) AS [Release Year],
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

            SqlDataReader reader = cmd.ExecuteReader();
            grid.DataSource = reader;
            grid.DataBind();
            con.Close();
            con.Dispose();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string currentUrl = "Removeid";

            if (url.Contains(currentUrl))
            {
                delete_btn.Visible = true;
                add_btn.Visible = false;
            }

            if (Session["CurrentUser"] == null)
                Response.Redirect("/Movies.aspx");
            if (!IsPostBack)
            {
                LoadGenre();
                LoadDirector();
                string movieId = this.Request.Params["id"];
                string deleteId = this.Request.Params["Removeid"];

                if (!string.IsNullOrWhiteSpace(movieId))
                {

                    string selectStmt = $"select * from movies where MovieId={movieId};";
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = selectStmt;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        hid_movieId.Value = reader["MovieId"].ToString();
                        name.Text = reader["MovieName"].ToString();
                        date.Text = reader["ReleaseDate"].ToString();
                        desc.Text = reader["MovieDescription"].ToString();
                        drp_genre.SelectedValue = reader["Genre"].ToString();
                        director_dropdown.SelectedValue = reader["Director"].ToString();
                    }
                    con.Close();
                    con.Dispose();
                }
                if (!string.IsNullOrWhiteSpace(deleteId))
                {

                    string selectStmt = $"select * from movies where MovieId={deleteId};";
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = selectStmt;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        hid_movieId.Value = reader["MovieId"].ToString();
                        name.Text = reader["MovieName"].ToString();
                        date.Text = reader["ReleaseDate"].ToString();
                        desc.Text = reader["MovieDescription"].ToString();
                        drp_genre.SelectedValue = reader["Genre"].ToString();
                        director_dropdown.SelectedValue = reader["Director"].ToString();
                    }
                    con.Close();
                    con.Dispose();
                }
            }
        }

        private void make_delete()
        {
            string deleteId = this.Request.Params["Removeid"];
            if (!string.IsNullOrWhiteSpace(deleteId))
            {
                string
                deleteQuery = $"delete from movies where MovieId={deleteId}";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = deleteQuery;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();

            }
        }


        protected void add_btn_Click(object sender, EventArgs e)
        {
            string id = hid_movieId.Value;
            string Name_Text = name.Text;
            string Release_Date = date.Text;
            string Description = desc.Text;
            int genre = int.Parse(drp_genre.SelectedValue);
            int director = int.Parse(director_dropdown.SelectedValue);
            string path = Server.MapPath("/Content/Img/");
            string uploadImage = "null";
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName);
                if (ext == ".jpg" || ext == ".png")
                {
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    uploadImage = FileUpload1.FileName;
                    error_1.Text = "File upload successfully";
                }
                else
                {
                    error_1.Text = "YOu only allowed to insert jpg and png image.";
                }
            }
            else
            {
                error_1.Text = "Please select a file";
            }
            if (!(string.IsNullOrWhiteSpace(Name_Text)))
            {
                string sqlStmt = "";
                if (string.IsNullOrWhiteSpace(id))
                {
                    sqlStmt = $"insert into movies(MovieName,ReleaseDate,MovieDescription,Genre,Director,Img) values('{ Name_Text}','{ Release_Date}','{Description}',{genre},{director},'{uploadImage}');";
                    add_btn.Text = "Add";
                    Response.Redirect("/Movies.aspx");
                }
                else
                {
                    sqlStmt = $"update movies set MovieName='{Name_Text}', ReleaseDate='{Release_Date}', MovieDescription='{Description}',Genre={genre},Director={director},Img='{uploadImage}' where MovieId={id}";
                    add_btn.Text = "Update";
                }

                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sqlStmt;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                
                con.Close();
                con.Dispose();
                if (!string.IsNullOrWhiteSpace(id))
                    Response.Redirect("/Default.aspx");
            }

            
        }
        protected void grd_movies_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[5].Text);
                string decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells[6].Text);
                string decodedText2 = HttpUtility.HtmlDecode(e.Row.Cells[7].Text);
                e.Row.Cells[5].Text = decodedText;
                e.Row.Cells[6].Text = decodedText1;
                e.Row.Cells[7].Text = decodedText2;
            }

        }




        protected void Delete_Click(object sender, EventArgs e)
        {

            make_delete();
            Response.Redirect("/Default");
        }

    }
}