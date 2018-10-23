using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

public partial class Login1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            String checking = "select count(*) from UserLogin where UserName = '" + TextBoxUN.Text + "'";
            SqlCommand com = new SqlCommand(checking, con);
            int user = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (user == 1)
            {
                con.Open();
                string verifyPassword = " select password from UserLogin where UserName = '" + TextBoxUN.Text + "'";
                SqlCommand pwdCom = new SqlCommand(verifyPassword, con);
                string pwd = pwdCom.ExecuteScalar().ToString().Replace(" ", "");
                if (pwd == TextBoxPassword.Text)
                {
                    Session["New"] = TextBoxUN.Text;
                    Response.Write("Entered password is correct");
                    Response.Redirect("BookingTicket1.aspx");
                }
                else
                {
                    Response.Write("Entered password is incorrect");
                }

            }

            else
            {
                MessageBox.Show("Username does not exist");
            }

        }

    }
}