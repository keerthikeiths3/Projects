using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;

public partial class PaymentGateway1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (tbxName.Text != "" && tbxCardNo.Text != "" && tbxCvv.Text != "" && tbxPhNo.Text != "")
        {
            MessageBox.Show("Booking Confirmed");
            Response.Redirect("TicketSummary.aspx");
        }

        else
        {
            Response.Write("Please fill the above information to confirm ticket booking");
            
        }
    }
}