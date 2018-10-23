using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      String Temp;
      Temp = (string)(Session["New"]);
      //Temp = Temp.ToLower();


      if (!string.IsNullOrEmpty(Temp))
      {

          if (Temp != "keerthi")
          {
              ImageButton5.Visible = false;
          }
          else
          {
              ImageButton5.Visible = true;

          }

      }

      else
      {
          ImageButton5.Visible = false;
      
      }

    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Session["New"] = "";
    }
}
