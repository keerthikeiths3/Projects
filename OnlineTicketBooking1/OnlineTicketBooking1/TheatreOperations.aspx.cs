using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;

public partial class TheatreOperations : System.Web.UI.Page
{
    static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            BindData();

        }

    }

    private void BindData()
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");

        string strQuery = "select t.theatre_name, t.theatre_id ,m.movie_id,m.movie_name,m.movie_language,CONVERT(VARCHAR(10),s.Show_Date,111) Show_Date,s.show_time from Theatres t,Movies_Info m,Theatre_Shows s where t.movie_id = m.movie_id and s.theatre_id = t.theatre_id";
        //string strQuery = "select * from Theatres";
        SqlCommand cmd = new SqlCommand(strQuery, con);
        con.Open();

        {
            SqlDataAdapter sda = new SqlDataAdapter();
            // cmd.Connection = con;
            sda.SelectCommand = cmd;
           // using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }

    protected void AddNewCustomer(object sender, EventArgs e)
    {
       // string Movie_Id = "";
       // Movie_Id = (string)(Session["Movie_Id"]);

        string Theatre_Name = ((System.Web.UI.WebControls.TextBox)GridView1.FooterRow.FindControl("txtTheatreName")).Text;


        string Theatre_Id = ((System.Web.UI.WebControls.TextBox)GridView1.FooterRow.FindControl("txtTheatreId")).Text;

        string Movie_Id = ((System.Web.UI.WebControls.TextBox)GridView1.FooterRow.FindControl("txtMovieId")).Text;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
        
        string insertQuery = "insert into Theatres (Theatre_Name, Theatre_Id, Movie_Id,Total_Seats) values ('" + Theatre_Name + "','" + Theatre_Id + "','" + Movie_Id +"','100')";
        con.Open();
        SqlCommand cmd = new SqlCommand(insertQuery,con);
        cmd.ExecuteNonQuery();

        con.Close();

        Theatre_Name = Theatre_Id = Movie_Id = "";


    }



    protected void UpdateMovie(object sender, GridViewUpdateEventArgs e)
    {

        string Show_Date = ((System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("lblShowDate")).Text;


        string Show_Time = ((System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("lblShowTime")).Text;
        string Theatre_Id = ((System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("lblTheatreId")).Text;

        string Movie_Id = ((System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("lblMovieId")).Text;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");

        string UpdateQuery = "update Theatre_Shows set Show_Date = '" + Show_Date + "', Show_Time ='" + Show_Time + "' where Theatre_Id ='" + Theatre_Id + "' ";
        con.Open();
        SqlCommand cmd = new SqlCommand(UpdateQuery, con);
        cmd.ExecuteNonQuery();

       // GridView1.EditIndex = -1;

        // GridView1.DataSource = GetData(cmd);

        // GridView1.DataBind();
        //con.Close();

    }


    //protected void DeleteCustomer(object sender, EventArgs e)
    //{

    //    LinkButton lnkRemove = (LinkButton)sender;

    //    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");

    //   // string UpdateQuery = "update Theatre_Shows set Show_Date = '" + Show_Date + "', Show_Time ='" + Show_Time + "' where Theatre_Id ='" + Theatre_Id + "'  ";
    //   // con.Open();
    //    SqlCommand cmd = new SqlCommand();
    //    //cmd.ExecuteNonQuery();

    //    cmd.CommandText = "delete from  theatres where " +

    //    "Theatre_Id=@Theatre_Id;" +

    //     "select CustomerID,ContactName,CompanyName from customers";

    //    cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value

    //        = lnkRemove.CommandArgument;

    //    GridView1.DataSource = GetData(cmd);

    //    GridView1.DataBind();

    //}

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
       // GridView1.DataSource = dt;
        //GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        UpdateMovie(sender,e);
    }
}



   
