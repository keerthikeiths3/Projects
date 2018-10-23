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
                MessageBox.Show("Invalid user entered");
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
                String SelectQuery = "select Movie_Id,Movie_Name,Movie_Language,Movie_Genre,Movie_Description, CONVERT(VARCHAR(10),Release_Date,111) from Movies_Info where Movie_Id = " + TextBoxMovieId.Text + " ";
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
                addM = new SqlCommand("select Movie_Id from Movies_Info", con);
                SqlDataReader dr = addM.ExecuteReader();
                drpMovieId.Items.Clear();
                drpMovieId.Items.Add("");
                while (dr.Read())
                {

                    drpMovieId.Items.Add(dr[0].ToString());
                
                }
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
               // string deletefromtheatre = "delete from Theatres where Movie_Id = '" + TextBoxMovieId.Text + "'";
               // SqlCommand delMvTheatre = new SqlCommand(deletefromtheatre, con);
                //delMvTheatre.ExecuteNonQuery();
                string deleteMovie = " delete from Movies_Info where Movie_Id = '" + TextBoxMovieId.Text + "'";
                SqlCommand delMovie = new SqlCommand(deleteMovie, con);
                delMovie.ExecuteNonQuery();
               // con.Close();
                MessageBox.Show("Movie details deleted");
                delMovie = new SqlCommand("select Movie_Id from Movies_Info", con);
                SqlDataReader dr = delMovie.ExecuteReader();
                drpMovieId.Items.Clear();
                drpMovieId.Items.Add("");
                while (dr.Read())
                {

                    drpMovieId.Items.Add(dr[0].ToString());

                }
                dr.Close();
            }
            else
            {
                MessageBox.Show("Movie does not exist");
            }
            con.Close();
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
    protected void btnTheatre_Click(object sender, EventArgs e)
    {
        Response.Redirect("TheatreOperations.aspx");
    }
    protected void btnTheatreVerify_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
            con.Open();
            SqlCommand  delMovie = new SqlCommand("select Movie_Id from Movies_Info", con);
            SqlDataReader dr1 = delMovie.ExecuteReader();
            drpMovieId.Items.Clear();
            drpMovieId.Items.Add("");
            while (dr1.Read())
            {

                drpMovieId.Items.Add(dr1[0].ToString());

            }
            dr1.Close();
            String checktheatre = "select count(*) from Theatres where Theatre_Id = " + tbxTheatre_ID.Text + " ";
            SqlCommand com = new SqlCommand(checktheatre, con);
            int theatre = Convert.ToInt32(com.ExecuteScalar().ToString());

            if (theatre == 1)
            {

                MessageBox.Show("Theatre exists!!");
              //  String SelectQuery = "select Movie_Id,Movie_Name,Movie_Language,Movie_Genre,Movie_Description, CONVERT(VARCHAR(10),Release_Date,111) from Movies_Info where Movie_Id = " + TextBoxMovieId.Text + " ";
                String SelQuery = "select * from theatres where Theatre_Id = " + tbxTheatre_ID.Text + "   ";
                com = new SqlCommand(SelQuery, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    tbxTheatre_Name.Text = dr[1].ToString();
                    tbxTotal_Seats.Text = dr[3].ToString();
                    drpMovieId.ClearSelection();
                    drpMovieId.Items.FindByValue(dr[2].ToString()).Selected = true;

                }
                dr.Close();

                // Response.Write("Movie exists!!");
                // Response.Redirect("AdminMovieOp.aspx");
                //ButtonDelete_Click(sender,e);
                SqlCommand addM3 = new SqlCommand("select Theatre_Id from Theatres", con);
                 dr = addM3.ExecuteReader();
                drpTID.Items.Clear();
                drpTID.Items.Add("");
                while (dr.Read())
                {

                    drpTID.Items.Add(dr[0].ToString());

                }
                dr.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("Invalid theatre entered, if you want to add a new theatre, click on ADD");
                //Response.Write("Invalid movie entered, if you want to add a new movie, click on ADD");
            }

        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            con.Open();
            String checktht = "select count(*) from Theatres where Theatre_Id = '" + tbxTheatre_ID.Text + "'";
            SqlCommand com = new SqlCommand(checktht, con);
            int tht = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (tht == 1)
            {
                string deletetht = " delete from Theatres where Theatre_Id = '" + tbxTheatre_ID.Text + "'";
                SqlCommand deltheatre = new SqlCommand(deletetht, con);
                deltheatre.ExecuteNonQuery();
                // con.Close();
                MessageBox.Show("Theatre details deleted");
                SqlCommand addM2 = new SqlCommand("select Theatre_Id from Theatres", con);
                SqlDataReader dr = addM2.ExecuteReader();
                drpTID.Items.Clear();
                drpTID.Items.Add("");
                while (dr.Read())
                {

                    drpTID.Items.Add(dr[0].ToString());

                }
                
            }
            else
            {
                MessageBox.Show("Theatre does not exist");
            }
            con.Close();
        }

    }
    protected void btnAddUpd_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            con.Open();
            String checkmovie = "select count(*) from Theatres where Theatre_Id = '" + tbxTheatre_ID.Text + "'";
            SqlCommand com = new SqlCommand(checkmovie, con);
            int movie = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (tbxTheatre_ID.Text == "" || tbxTheatre_Name.Text == "" || drpMovieId.SelectedItem.Text == "" || tbxTotal_Seats.Text == "")
            {
                MessageBox.Show("None of the fields should be empty");


            }
            else
            {
                if (movie == 0)
                {


                    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketBookingConnectionString"].ConnectionString);
                    //con.Open();
                    string addMovie = " insert into Theatres (Theatre_Id,Theatre_Name,Movie_Id,Total_Seats) values ('" + tbxTheatre_ID.Text + "','" + tbxTheatre_Name.Text + "','" + drpMovieId.SelectedItem.Text + "','" + tbxTotal_Seats.Text + "') ";
                    SqlCommand addM = new SqlCommand(addMovie, con);
                    addM.ExecuteNonQuery();
                    MessageBox.Show("Theatre added successfully");



                }
                else
                {
                    string updateMovie = " update Theatre_Id set Movie_Id = " + drpMovieId.SelectedItem.Text + ", Theatre_Name = '" + tbxTheatre_Name.Text + "', Total_Seats = '" + tbxTotal_Seats.Text + "'";
                    SqlCommand updateM = new SqlCommand(updateMovie, con);
                    updateM.ExecuteNonQuery();
                    MessageBox.Show("Theatre updated successfully");
                }

                SqlCommand addM1 = new SqlCommand("select Theatre_Id from Theatres", con);
                SqlDataReader dr = addM1.ExecuteReader();
                drpTID.Items.Clear();
                drpTID.Items.Add("");
                while (dr.Read())
                {

                    drpTID.Items.Add(dr[0].ToString());

                }


                con.Close();
            }
        }
    }
    protected void btnRes_Click(object sender, EventArgs e)
    {
        tbxTheatre_ID.Text ="";
        tbxTheatre_Name.Text = "" ;
        drpMovieId.SelectedItem.Text ="" ;
        tbxTotal_Seats.Text = "";
    }


    protected void btnVerifyshows_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand addM5 = new SqlCommand("select  CONVERT(VARCHAR(10),Show_Date,111) Show_Date,Show_Time from Theatre_shows where theatre_Id =" + drpTID.SelectedItem.Text + "", con);
        SqlDataReader dr = addM5.ExecuteReader();
        drpSDate.Items.Clear();
        drpSTime.Items.Clear();
        drpSDate.Items.Add("");
        drpSTime.Items.Add("");
        while (dr.Read())
        {
            if (drpSDate.Items.IndexOf(drpSDate.Items.FindByValue(dr[0].ToString()))<0)
            {
                drpSDate.Items.Add(dr[0].ToString());

            }

            if (drpSTime.Items.IndexOf(drpSTime.Items.FindByValue(dr[1].ToString())) < 0)
            {
                drpSTime.Items.Add(dr[1].ToString());
            }
        }

        dr.Close();
        con.Close();

    }


    protected void btnDeleTime_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            con.Open();
            String deletetimedate = "delete  from Theatre_Shows where Theatre_Id = " + drpTID.SelectedItem.Text + " and show_date='"+drpSDate.SelectedItem.Text+"' and show_time='"+drpSTime.SelectedItem.Text+"'";
            SqlCommand com = new SqlCommand(deletetimedate, con);

            com.ExecuteNonQuery();
              con.Close();
                MessageBox.Show("Theatre shows deleted");
            }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        drpTID.Text = "";
        drpSDate.Text = "";
        drpSTime.Text = "";
    }
}