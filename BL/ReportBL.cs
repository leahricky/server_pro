using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
//using PdfSharp.Pdf;
//using PdfSharp.Drawing;

namespace BL
{
    public class ReportBL:IReportBL
    {
        IRoomBookingDL udl;
        public ReportBL(IRoomBookingDL udl)
        {
            this.udl = udl;
        }
        public async Task create_pdf(DateTime date, string type)
        {
            /*יצירת קובץ pdf
             קביעת מאפיינים
            כתיבת כותרות
            יצירת טבלה
            */
            //List<RoomBooking> l_ = await udl.get(type,date.Month, date.Month,null,null );
            // Create new PDF document
            //PdfDocument document = new PdfDocument();
           // this.time = document.Info.CreationDate;
            //document.Info.Title = "PDFsharp Clock Demo";
           // document.Info.Author = "Stefan Lange";
            //document.Info.Subject = "Server time: " +
            //  this.time.ToString("F", CultureInfo.InvariantCulture);

            // Create new page
            //PdfPage page = document.AddPage();
            //page.Width = XUnit.FromMillimeter(200);
            //page.Height = XUnit.FromMillimeter(200);

            // Create graphics object and draw clock
            //XGraphics gfx = XGraphics.FromPdfPage(page);
          //  RenderClock(gfx);


            // Send PDF to browser
          //  MemoryStream stream = new MemoryStream();
            //document.Save("M:\\pdf.pdf");
          //  Response.Clear();
          //   Response.ContentType = "application/pdf";
          //   Response.AddHeader("content-length", stream.Length.ToString());
          //   Response.BinaryWrite(stream.ToArray());
          //   Response.Flush();
          //   stream.Close();
          //   Response.End();

        }

        public async Task send_email()
        {
            //שליחת מייל במקרה ויש ISSENDMAIL
        }

    }
}
