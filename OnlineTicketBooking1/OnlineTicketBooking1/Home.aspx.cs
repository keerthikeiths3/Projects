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
        Session["New"] = null;
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
        lblMovieName.Text = "Maggie 2015";
        lblMovieSummary.Text = "Maggie is an upcoming American independent horror film directed by Henry Hobson, written by John Scott 3, and starring Arnold Schwarzenegger, Abigail Breslin and Joely Richardson. The film is a dramatic departure for Schwarzenegger, who is more known for his action hero roles.";
    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "The Lazarus Effect";
        lblMovieSummary2.Text = "The Lazarus Effect is a 2015 American science fiction horror film directed by David Gelb and written by Luke Dawson and Jeremy Slater. The film stars Mark Duplass, Olivia Wilde, Donald Glover, Evan Peters, and Sarah Bolger. The film was theatrically released on February 27, 2015 by Relativity Media.";
    }
    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "Furious 7";
        lblMovieSummary2.Text = "A dead man's brother seeks revenge on the Toretto gang.It is the sequel to the 2013 film Fast & Furious 6 and the seventh installment in the Fast & Furious film series. The film was written by Chris Morgan and directed by James Wan.";
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "S/O Satyamurthy";
        lblMovieSummary2.Text = "S/O Satyamurthy (read as Son of Satyamurthy) is a 2015 Telugu family drama written and directed by Trivikram Srinivas and produced by S. Radha Krishna under the banner Haarika & Haasine Creations. It features an ensemble cast of Allu Arjun, Upendra, Samantha Ruth Prabhu, Sneha, Adah Sharma, Nithya Menen, Rajendra Prasad, Brahmanandam and Ali. Prakash Raj makes a crucial cameo appearance as Satyamurthy.";
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "NH10";
        lblMovieSummary2.Text = "NH10 is a 2015 Indian crime-thriller film directed by Navdeep Singh. It stars Anushka Sharma and Neil Bhoopalam in lead roles, and marks the production debut of Sharma. The film is co-produced by Phantom Films and Eros International. It tells the story of a young couple whose road trip goes awry after an encounter with a group of violent criminals. The film's title refers to the 403 km long National Highway 10 in India.";
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        lblMovieName.Text = "Home";
        lblMovieSummary2.Text = "Home is a 2015 American 3D computer-animated buddy comedy film[4] produced by DreamWorks Animation and distributed by 20th Century Fox. It is based on Adam Rex's 2007 children's book The True Meaning of Smekday and stars Jim Parsons, Rihanna, Jennifer Lopez, and Steve Martin. Tim Johnson is the director of the film, Chris Jenkins and Suzanne Buirgy are its producers, and the adaptation is by Tom J. Astle and Matt Ember. The story takes place on planet Earth, where an alien race called the Boov invade the planet. However, a teenage girl named Tip manages to avoid capture and goes on the run.";
    }
}