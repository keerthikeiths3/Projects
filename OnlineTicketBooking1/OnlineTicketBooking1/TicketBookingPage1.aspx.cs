using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;

public partial class TicketBookingPage1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Show_Time = "", Show_Date = "", Theatre_Name = "", Movie_Id = "";
            Show_Time = (string)(Session["Show_Time"]);
            Show_Date = (string)(Session["Show_Date"]);
            Theatre_Name = (string)(Session["Theatre_Name"]);
            Movie_Id = (string)(Session["Movie_Id"]);

            con.Open();
            string selectQuery = "select distinct a.Seat_Type from Seats_Information a,Theatres b, Theatre_Shows c where a.Theatre_Id =  b.Theatre_Id and a.Theatre_Id =  c.Theatre_Id and b.Theatre_Name = '" + Theatre_Name + "' and c.Show_Time ='" + Show_Time + "' and c.Show_Date = '" + Show_Date + "'and b.Movie_Id = '" + Movie_Id + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            drdClass.Items.Clear();
            drdClass.Items.Add("Select Class");

            while (dr.Read())
            {

                drdClass.Items.Add(dr[0].ToString());

            }
            con.Close();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Show_Time = "", Show_Date = "", Theatre_Name = "", Movie_Id = "";
        Show_Time = (string)(Session["Show_Time"]);
        Show_Date = (string)(Session["Show_Date"]);
        Theatre_Name = (string)(Session["Theatre_Name"]);
        Movie_Id = (string)(Session["Movie_Id"]);

        con.Open();
        string selectQuery = "select Min( a.Seat_Remaining )from Seats_Information a,Theatres b, Theatre_Shows c where a.Theatre_Id =  b.Theatre_Id and a.Theatre_Id =  c.Theatre_Id and b.Theatre_Name = '" + Theatre_Name + "' and c.Show_Time ='" + Show_Time + "' and c.Show_Date = '" + Show_Date + "' and a.Seat_Type = '" + drdClass.SelectedItem.Text + "' and b.Movie_Id = '" + Movie_Id + "'";
        SqlCommand cmd = new SqlCommand(selectQuery, con);
        SqlDataReader dr = cmd.ExecuteReader();


        while (dr.Read())
        {
            tbxSeatsAvailable.Text = dr[0].ToString();

            //drdClass.Items.Add(dr[0].ToString());

        }
        con.Close();

        drdSeats.SelectedIndex = 0;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {

            tbxComboSelected.Text = tbtMiniCombo.Text;
            tbtPrice.Text = tbtComboPriceSmall.Text;
        }

    }
    protected void tbtComboMenuSmall_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton2.Checked)
        {

            tbxComboSelected.Text = tbtMediumCombo.Text;
            tbtPrice.Text = tbtComboPriceMedium.Text;
        }
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton3.Checked)
        {

            tbxComboSelected.Text = tbtLargeCombo.Text;
            tbtPrice.Text = tbtComboPriceLarge.Text;
        }
    }
    protected void tbxReset_Click(object sender, EventArgs e)
    {
        tbxComboSelected.Text = "";
        tbtPrice.Text = "";
        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;

    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        if (drdClass.SelectedIndex > 0 && drdSeats.SelectedIndex > 0)
        {

            string Show_Time = "", Show_Date = "", Theatre_Name = "", Theatre_Id = "", Movie_Id = "", UserName = "", MovieName = "";
            Show_Time = (string)(Session["Show_Time"]);
            Show_Date = (string)(Session["Show_Date"]);
            Theatre_Name = (string)(Session["Theatre_Name"]);
            Theatre_Id = (string)(Session["Theatre_Id"]);
            Movie_Id = (string)(Session["Movie_Id"]);
            UserName = (string)(Session["New"]);
            MovieName = (string)(Session["Movie_Name"]);

            con.Open();
            string UpdateQuery = "update Seats_Information set Seat_Remaining = Seat_Remaining -" + drdSeats.SelectedItem.Text + "  where Theatre_Id ='" + Theatre_Id + "' and Seat_Type ='" + drdClass.SelectedItem.Text + "'and  Show_Time ='" + Show_Time + "' and Show_Date = '" + Show_Date + "'";
            SqlCommand cmd = new SqlCommand(UpdateQuery, con);
            cmd.ExecuteNonQuery();
            string InsertQuery = "insert into ticketbookinginfo (Booking_Id,UserName,Movie_Name,Movie_Id,Theatre_Id,Theatre_Name,Seat_Count,ComboSelected,Total_Price,Seat_Type,Show_Date,Show_Time) values ((select ISNULL(MAX(Booking_Id)+1,1) from ticketbookinginfo),'" + UserName + "','" + MovieName + "','" + Movie_Id + "','" + Theatre_Id + "','" + Theatre_Name + "','" + drdSeats.SelectedItem.Text + "','" + tbxComboSelected.Text + "','" + tbxTotalAmount.Text + "','" + drdClass.SelectedItem.Text + "','"+Show_Date+"','"+Show_Time+"')";
            cmd = new SqlCommand(InsertQuery, con);
            cmd.ExecuteNonQuery();
            //commit;

            Response.Redirect("PaymentGateway1.aspx");
        }
    }
    protected void drdSeats_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (drdSeats.SelectedIndex == 0 || drdClass.SelectedIndex <= 0)
        {
            tbxComboPrice.Text = "";
            tbxTicketPrice.Text = "";
            tbxTax.Text = "";
            tbxTotalAmount.Text = "";
            btnPay.Enabled = false;

        }

        if (drdSeats.SelectedIndex > 0 && drdClass.SelectedIndex > 0)
        {


            if (drdClass.SelectedItem.Text == "Gold")
            {

                tbxTicketPrice.Text = (Convert.ToInt32(drdSeats.SelectedItem.Text) * 20).ToString();


            }

            else if (drdClass.SelectedItem.Text == "Platinum")
            {

                tbxTicketPrice.Text = (Convert.ToInt32(drdSeats.SelectedItem.Text) * 25).ToString();

            }

            else if (drdClass.SelectedItem.Text == "Silver")
            {

                tbxTicketPrice.Text = (Convert.ToInt32(drdSeats.SelectedItem.Text) * 15).ToString();
            }


            tbxComboPrice.Text = tbtPrice.Text;
            tbxTax.Text = (Convert.ToDouble(tbxTicketPrice.Text) * 0.05).ToString();
            tbxTotalAmount.Text = (Convert.ToInt32(tbxTicketPrice.Text) + Convert.ToDouble(tbxTax.Text) + Convert.ToInt32(tbxComboPrice.Text)).ToString();
            // tbxTotalAmount.Text = Convert.ToInt32(tbxTicketPrice.Text).ToString() + Convert.ToInt32(tbxTax.Text).ToString() + Convert.ToInt32(tbxComboPrice.Text).ToString();

            tbxComboPrice.Text += "$";
            tbxTicketPrice.Text += "$";
            tbxTax.Text += "$";
            tbxTotalAmount.Text += "$";


            btnPay.Enabled = true;
        }

    }
    protected void tbxSeatsAvailable_TextChanged(object sender, EventArgs e)
    {

    }
}

