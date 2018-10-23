using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;

public partial class Registration1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
           // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string checkUser = "select count(*) from UserLogin where UserName = '" + TextBoxUserName.Text + "'";
            SqlCommand cmd = new SqlCommand(checkUser, con);
            int checking = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (checking == 1)
            {
                MessageBox.Show("User already exists", "User exists !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            con.Close();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Guid newGuid = Guid.NewGuid();
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string insertQuery = "insert into UserLogin (UserName,Email,Password,PhoneNumber) values ('" + TextBoxUserName.Text + "','" + TextBoxEmail.Text + "','" + TextBoxPwd.Text + "','" + TextBoxPh.Text + "')";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Registration is Successful");

        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex.Message.ToString());
        }


    }
    protected void tbxReset_Click(object sender, EventArgs e)
    {
        TextBoxUserName.Text = "";
        TextBoxPh.Text = "";
        TextBoxPwd.Text = "";
        TextBoxEmail.Text = "";
        TextBoxConfirmPwd.Text = "";

    }
}