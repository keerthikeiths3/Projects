using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            lblMovieName.Text = "";
            lblMovieSummary.Text= "";
        }
        else
        {
            lblMovieName.Text = "Click on a movie";
            lblMovieSummary.Text = "Movie summary";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "Avengers Age of Ultron";
        lblMovieSummary.Text = "When Tony Stark (Robert Downey Jr.) jumpstarts a dormant peacekeeping program, things go terribly awry, forcing him, Thor (Chris Hemsworth), the Incredible Hulk (Mark Ruffalo) and the rest of the Avengers to reassemble. As the fate of Earth hangs in the balance, the team is put to the ultimate test as they battle Ultron (James Spader), a technological terror hell-bent on human extinction. Along the way, they encounter two mysterious and powerful newcomers, Pietro and Wanda Maximoff.";
        //Response.Redirect("MoviesInfo.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "Golmaal 4";
        lblMovieSummary.Text = "Golmaal is a series of Indian action comedy films directed by Rohit Shetty and produced by Dhillin Mehta. All three films starred Ajay Devgan, Arshad Warsi, Tusshar Kapoor in lead roles. The first film Golmaal: Fun Unlimited is released in 2006, the second film Golmaal Returns is released in 2008 and the third film Golmaal 3 is released in 2010.";
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "Kick 2";
        lblMovieSummary.Text = "Kick 2 is an upcoming Telugu film written by Vakkantham Vamsi and directed by Surender Reddy. It features Ravi Teja as the protagonist and it is the sequel of the 2009 blockbuster Telugu film Kick starring Ravi Teja , which is also directed by Surender Reddy. The film is produced by actor Nandamuri Kalyan Ram on N.T.R. Arts banner";
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "The Longest Ride";
        lblMovieSummary.Text = "Former bull-riding champion Luke (Scott Eastwood) and college student Sophia (Britt Robertson) are in love, but conflicting paths and ideals threaten to tear them apart: Luke hopes to make a comeback on the rodeo circuit, and Sophia is about to embark on her dream job in New York's art world. As the couple ponder their romantic future, they find inspiration in Ira (Alan Alda), an elderly man whose decades-long romance with his beloved wife withstood the test of time.";
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "Furious 7";
        lblMovieSummary.Text = "A dead man's brother seeks revenge on the Toretto gang.It is the sequel to the 2013 film Fast & Furious 6 and the seventh installment in the Fast & Furious film series. The film was written by Chris Morgan and directed by James Wan.";
    }
}