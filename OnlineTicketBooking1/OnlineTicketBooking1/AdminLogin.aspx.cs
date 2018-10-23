using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

public partial class AdminLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            con.Open();
            String checking = "select count(*) from Admin where AdminUserName = '" + TextBoxAdminUN.Text + "'";
            SqlCommand com = new SqlCommand(checking, con);
            int adminuser = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (adminuser == 1)
            {
                con.Open();
                string verifyPassword = " select password from Admin where Password = '" + TextBoxAdminPwd.Text + "'";
                SqlCommand pwdCom = new SqlCommand(verifyPassword, con);
                string pwd = pwdCom.ExecuteScalar().ToString().Replace(" ", "");
                if (pwd == TextBoxAdminPwd.Text)
                {
                   
                 
                    //Response.Write("Entered password is correct");
                    Response.Redirect("AdminJobs.aspx");
                   
                }
                else
                {
                    MessageBox.Show("Entered password is incorrect");
                }

            }

            else
            {
                MessageBox.Show("Username does not exist");
            }
        }


    }
    protected void btnReset9_Click(object sender, EventArgs e)
    {

        TextBoxAdminUN.Text  = "";
        TextBoxAdminPwd.Text = "";
    }
}