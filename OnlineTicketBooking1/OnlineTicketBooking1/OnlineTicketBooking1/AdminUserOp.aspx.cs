using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminUserOp : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonUserDelete_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

            con.Open();
            String checking = "select count(*) from UserLogin where UserName = '" + TextBoxUser.Text + "'";
            SqlCommand com = new SqlCommand(checking, con);
            int user = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (user == 1)
            {
                
                con.Open();
                string deleteUser = " delete from UserLogin where UserName = '" + TextBoxUser.Text + "'";
                SqlCommand delUser = new SqlCommand(deleteUser, con);
                delUser.ExecuteNonQuery();
                con.Close();
                Response.Write("User deleted");
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                Response.Write("User does not exist");
            }

        }
    }
}