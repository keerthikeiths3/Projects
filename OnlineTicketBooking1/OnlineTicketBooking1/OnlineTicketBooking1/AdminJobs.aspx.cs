using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

public partial class AdminJobs : System.Web.UI.Page
{

    int user = 0;
    //int movie = 0;
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ButtonVerify_Click(object sender, EventArgs e)
    {
       
   
        if (IsPostBack)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
            con.Open();
            String checking = "select count(*) from UserLogin where UserName = '" + TextBoxUN1.Text + "'";
            SqlCommand com = new SqlCommand(checking, con);
            user = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (user == 1)
            {
               // Response.Write("User exists!!");
                //ButtonDelete_Click(sender,e);

                if (MessageBox.Show("User Exists.Do you want to delete", "Delete User ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    con.Open();
                    string deleteUser = " delete from UserLogin where UserName = '" + TextBoxUN1.Text + "'";
                    SqlCommand delUser = new SqlCommand(deleteUser, con);
                    delUser.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User deleted successfully");// Response.Redirect("AdminUserOp.aspx");
                }
            }
            else
            {
                Response.Write("Invalid user entered");
            }

        }

    }
 
    protected void ButtonMovieVerify_Click(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
            con.Open();
            String checkmovie = "select count(*) from Movies_Info where Movie_Id = " + TextBoxMovieId.Text + " ";
            SqlCommand com = new SqlCommand(checkmovie, con);
            int movie = Convert.ToInt32(com.ExecuteScalar().ToString());
            
            if (movie == 1)
            {

                MessageBox.Show("Movie exists!!");
                String SelectQuery = "select * from Movies_Info where Movie_Id = " + TextBoxMovieId.Text + " ";
                com = new SqlCommand(SelectQuery, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    TextBoxMovieName.Text = dr[1].ToString();
                    TextBoxML.Text        = dr[2].ToString();
                    TextBoxMG.Text        = dr[3].ToString();
                    TextBoxMD.Text        = dr[4].ToString();
                    tbxRelDt.Text         = dr[5].ToString();
                
                }

                // Response.Write("Movie exists!!");
               // Response.Redirect("AdminMovieOp.aspx");
                //ButtonDelete_Click(sender,e);

                con.Close();
            }
            else
            {
                MessageBox.Show("Invalid movie entered, if you want to add a new movie, click on ADD");
                //Response.Write("Invalid movie entered, if you want to add a new movie, click on ADD");
            }

        }
    }


    protected void btnAddUpdate_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            con.Open();
            String checkmovie = "select count(*) from Movies_Info where Movie_Id = '" + TextBoxMovieId.Text + "'";
            SqlCommand com = new SqlCommand(checkmovie, con);
            int movie = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (movie == 0)
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
                //con.Open();
                string addMovie = " insert into Movies_Info (Movie_Id,Movie_Name,Movie_Language,Movie_Genre,Movie_Description,Release_Date) values ('" + TextBoxMovieId.Text + "','" + TextBoxMovieName.Text + "','" + TextBoxML.Text + "','" + TextBoxMG.Text + "','" + TextBoxMD.Text + "', '"+ tbxRelDt.Text +"') ";
                SqlCommand addM = new SqlCommand(addMovie, con);
                addM.ExecuteNonQuery();
                MessageBox.Show("Movie added successfully");
            }
            else
            {
                string updateMovie = " update Movies_Info set Movie_Id = " + TextBoxMovieId.Text + ", Movie_Name = '" + TextBoxMovieName.Text + "', Movie_Language = '" + TextBoxML.Text + "', Movie_Genre = '" + TextBoxMG.Text + "', Movie_Description = '" + TextBoxMD.Text + "' where Movie_Id = '" + TextBoxMovieId.Text + "'";
                SqlCommand updateM = new SqlCommand(updateMovie, con);
                updateM.ExecuteNonQuery();
                MessageBox.Show("Movie updated successfully");
            }

            con.Close();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            con.Open();
            String checkmovie = "select count(*) from Movies_Info where Movie_Id = '" + TextBoxMovieId.Text + "'";
            SqlCommand com = new SqlCommand(checkmovie, con);
            int movie = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (movie == 1)
            {
                string deleteMovie = " delete from Movies_Info where Movie_Id = '" + TextBoxMovieId.Text + "'";
                SqlCommand delMovie = new SqlCommand(deleteMovie, con);
                delMovie.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie details deleted");
            }
            else
            {
                MessageBox.Show("Movie does not exist");
            }

        }

    }
    protected void btnReset1_Click(object sender, EventArgs e)
    {
        TextBoxMovieId.Text   = "";
        TextBoxMovieName.Text = "";
        TextBoxML.Text        = "";
        TextBoxMG.Text        = "";
        TextBoxMD.Text        = "";
        tbxRelDt.Text         = "";
    }
}