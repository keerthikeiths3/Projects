using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;

public partial class BookingTicket1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["New"] != null)
            {
                lbl_Welcome.Text += Session["New"].ToString()+"!!!";

            }

            else
            {

                Response.Redirect("Home.aspx");
            }

            
            con.Open();
            string selectQuery = "select distinct a.Movie_Name from Movies_Info a,Theatres b where a.Movie_Id =  b.Movie_Id and a.Release_Date <= GETDATE()";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            drdSelectMovie.Items.Clear();
            drdSelectMovie.Items.Add("Select Movie");

            while (dr.Read())
            {

                drdSelectMovie.Items.Add(dr[0].ToString());

            }

            drdSelectMovie.SelectedIndex = 0;
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


    }
    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        //Session["New"] = null;

        Response.Redirect("Home.aspx");


    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drdSelectMovie.SelectedIndex > 0)
        {
            con.Open();
            string selectQuery = "select distinct b.Theatre_Name from Movies_Info a,Theatres b where a.Movie_Id =  b.Movie_Id and a.Movie_Name ='" + drdSelectMovie.SelectedItem.Text + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            drdSelectTheatre.Items.Clear();
            drdSelectTheatre.Items.Add("Select Theatre");

            while (dr.Read())
            {

                drdSelectTheatre.Items.Add(dr[0].ToString());

            }
            con.Close();



        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drdSelectTheatre.SelectedIndex > 0)
        {
            con.Open();
            string selectQuery = "select distinct CONVERT(VARCHAR(10),b.Show_Date,111) from Theatres a,Theatre_Shows b where a.Theatre_Id =  b.Theatre_Id and a.Theatre_Name ='" + drdSelectTheatre.SelectedItem.Text + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            drdSelectDate.Items.Clear();
            drdSelectDate.Items.Add("Select Date");

            while (dr.Read())
            {

                drdSelectDate.Items.Add(dr[0].ToString());

            }
            con.Close();



        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drdSelectTheatre.SelectedIndex > 0)
        {
            con.Open();
            string selectQuery = "select distinct b.Show_Time from Theatres a,Theatre_Shows b where a.Theatre_Id =  b.Theatre_Id and a.Theatre_Name ='" + drdSelectTheatre.SelectedItem.Text + "' and b.Show_Date = '" + drdSelectDate.SelectedItem.Text + "'";
            
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            drdSelectTime.Items.Clear();
            drdSelectTime.Items.Add("Select Time");

            while (dr.Read())
            {

                drdSelectTime.Items.Add(dr[0].ToString());

            }

            dr.Close();//check this
            string selectQuery1 = "select  a.Theatre_Id,a.Movie_Id from Theatres a where  a.Theatre_Name ='" + drdSelectTheatre.SelectedItem.Text + "'";

            SqlCommand cmd1 = new SqlCommand(selectQuery1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {

                Session["Theatre_Id"] = dr1[0].ToString();
                Session["Movie_Id"] = dr1[1].ToString();

            }

            con.Close();
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnBookNow_Click(object sender, EventArgs e)
    {

      
        if (drdSelectMovie.SelectedIndex > 0 && drdSelectTheatre.SelectedIndex > 0 && drdSelectDate.SelectedIndex > 0 && drdSelectTime.SelectedIndex > 0)
        {

            Session["Movie_Name"] = drdSelectMovie.SelectedItem.Text;
            Session["Theatre_Name"] = drdSelectTheatre.SelectedItem.Text;
            Session["Show_Date"] = drdSelectDate.SelectedItem.Text;
            Session["Show_Time"] = drdSelectTime.SelectedItem.Text;

            Response.Redirect("TicketBookingPage1.aspx");
        
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        MessageBox.Show("Hello");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        drdSelectMovie.Items.Clear();
        drdSelectTheatre.Items.Clear();

    }
}