using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class TicketSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string UserName = "";
            UserName = (string)(Session["New"]);
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicket;Integrated Security=True");
            con.Open();
           //String movieDetails = "select * from ticketbookinginfo where UserName = '" + UserName + "' ";
            String movieDetails = "select Booking_Id,UserName,Movie_Name,Theatre_Name,Seat_Count,ComboSelected,Seat_Type,CONVERT(VARCHAR(10),Show_Date,111),Show_Time,Total_Price from ticketbookinginfo  where UserName ='" + UserName + "'";

            
            SqlCommand com = new SqlCommand(movieDetails, con);
            
          
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    //tbxConfirmationId.Text = dr[0].ToString();
                    //tbxNameOnTicket.Text = dr[1].ToString();
                    //tbxMovieName.Text = dr[2].ToString();
                    //tbxTheatreName.Text = dr[5].ToString();
                    //tbxSeats.Text = dr[6].ToString();
                    //tbxCombo.Text = dr[7].ToString();
                    //tbxSeatType.Text = dr[9].ToString();
                    //tbxShowDate.Text = dr[10].ToString();
                    //tbxShowTime.Text = dr[11].ToString();
                    //tbxPrice.Text = dr[8].ToString();

                    tbxConfirmationId.Text = dr[0].ToString();
                    tbxNameOnTicket.Text = dr[1].ToString();
                    tbxMovieName.Text = dr[2].ToString();
                    tbxTheatreName.Text = dr[3].ToString();
                    tbxSeats.Text = dr[4].ToString();
                    tbxCombo.Text = dr[5].ToString();
                    tbxSeatType.Text = dr[6].ToString();
                    tbxShowDate.Text = dr[7].ToString();
                    tbxShowTime.Text = dr[8].ToString();
                    tbxPrice.Text = dr[9].ToString();

                }

                con.Close();

        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
        try
        {


            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open(); 
            PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
            pdfDoc.Open();
            //Set Font Properties for PDF File
            Font fnt = FontFactory.GetFont("Times New Roman", 14);
            PdfPTable PdfTable = new PdfPTable(2);
            PdfPCell PdfPCell = null;
            

            pdfDoc.Add(new Paragraph("BOOKING CONFIRMATION".PadLeft(80)));
            pdfDoc.Add(new Paragraph(" "));
            //Retrieve content from design side
            String chk;
            chk = "CONFIRMATION ID";
            string confirmationId = tbxConfirmationId.Text;
           // PdfPCell = new PdfPCell(new Phrase(new Chunk(chk + confirmationId)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(confirmationId); 
 
            //String chk;
            //chk = ("CONFIRMATION ID".PadRight(50,' '));
            //string confirmationId = tbxConfirmationId.Text.PadRight(30);
            //PdfPCell = new PdfPCell(new Phrase(new Chunk(chk + confirmationId)));
            //PdfTable.AddCell(PdfPCell);         

            chk = "MOVIE NAME";
            string movieName = tbxMovieName.Text;
           // PdfPCell movieName1 = new PdfPCell(new Phrase(new Chunk(chk + movieName)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(movieName); 

            chk = "THEATRE NAME";
            string theatreName = tbxTheatreName.Text;
            //PdfPCell theatreName1 = new PdfPCell(new Phrase(new Chunk(chk + theatreName)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(theatreName);


            chk = "NUMBER OF SEATS BOOKED";
            string noSeats = tbxSeats.Text;
            //PdfPCell noSeats1 = new PdfPCell(new Phrase(new Chunk(chk + noSeats)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(noSeats);


            chk = "COMBO SELECTED";
            string combo = tbxCombo.Text;
           // PdfPCell combo1 = new PdfPCell(new Phrase(new Chunk(chk + combo)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(combo);


            chk = "SEAT TYPE";
            string seatType = tbxSeatType.Text;
           // PdfPCell seatType1 = new PdfPCell(new Phrase(new Chunk(chk + seatType)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(seatType);


            chk = "SHOW DATE";
            string showDate = tbxShowDate.Text;
           // PdfPCell showDate1 = new PdfPCell(new Phrase(new Chunk(chk + showDate)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(showDate);


            chk = "SHOW TIME";
            string showTime = tbxShowTime.Text;
            //PdfPCell showTime1 = new PdfPCell(new Phrase(new Chunk(chk + showTime)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(showTime);


            chk = "TOTAL PRICE";
            string price = tbxPrice.Text;
            //PdfPCell price1 = new PdfPCell(new Phrase(new Chunk(chk + price)));
            PdfTable.AddCell(chk);
            PdfTable.AddCell(price);

            pdfDoc.Add(PdfTable);
            //pdfWriter.CloseStream = false;  
            //pdfDoc.Close();  
            //Response.Buffer = true;  
            //Response.ContentType = "application/pdf";  
            /*Response.AddHeader("content-disposition", "attachment;filename=TicketConfirmation.pdf");  
            Response.Cache.SetCacheability(HttpCacheability.NoCache);  
            Response.Write(pdfDoc); */
            //Response.End();  


            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TicketConfirmation.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);

            System.Web.HttpContext.Current.Response.Write(pdfDoc);

            Response.Flush();
            Response.End();

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }


    }
}