using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminMovieOp : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonMovieUpdate_Click(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            con.Open();
            String checkmovie = "select count(*) from Movies_Info where Movie_Id = '" + TextBoxMovieId1.Text + "'";
            SqlCommand com = new SqlCommand(checkmovie, con);
            int movie = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (movie >= 1)
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
                con.Open();
                string updateMovie = " update Movies_Info set Movie_Id = " + TextBoxMovieId1.Text + ", Movie_Name = '" + TextBoxMovieName1.Text + "', Movie_Language = '" + TextBoxMovieLang.Text + "', Movie_Genre = '" + TextBoxMovieGenre.Text + "', Movie_Description = '" + TextBoxMovieDesc.Text + "' where Movie_Id = '" + TextBoxMovieId1.Text + "'";
                SqlCommand updateM = new SqlCommand(updateMovie, con);
                updateM.ExecuteNonQuery();
                con.Close();
                Response.Write("Movie updated");
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                Response.Write("Movie does not exist, try adding it");

            }

        }


    }
    protected void ButtonMovieDelete_Click(object sender, EventArgs e)
    {


         if (IsPostBack)
        {
            con.Open();
            String checkmovie = "select count(*) from Movies_Info where Movie_Id = '" + TextBoxMovieId1.Text + "'";
            SqlCommand com = new SqlCommand(checkmovie, con);
            int movie = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (movie >= 1)
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
                con.Open();
                string deleteMovie = " delete from Movies_Info where Movie_Id = '" + TextBoxMovieId1.Text + "'";
                SqlCommand delMovie = new SqlCommand(deleteMovie, con);
                delMovie.ExecuteNonQuery();
                con.Close();
                Response.Write("Movie details deleted");
            }
            else
            {
                Response.Write("Movie does not exist");
            }

        }

    }

}