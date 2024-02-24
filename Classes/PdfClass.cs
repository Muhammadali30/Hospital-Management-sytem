using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using System.Windows.Media;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Aspose.Pdf.Facades;

namespace Final_Project.Classes
{
    class PdfClass
    {
        public void create_pdf()
        {
        //    PdfDocument document = new PdfDocument();
        //    PdfPage page = document.AddPage();
        //    XGraphics gfx = XGraphics.FromPdfPage(page);
        //    gfx.DrawString("Hello, World!", new XFont("Arial", 12), XBrushes.Black,
        //        new XRect(10, 10, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

        //    // Save the PDF document to a file
        //    string pdfFilePath = "output.pdf";
        //    document.Save(pdfFilePath);
        //    document.Close();

        //    // Create a PdfiumViewer control
        //    PdfViewer pdfViewer = new PdfViewer();

        //    // Load the PDF document into the PdfiumViewer control
        //    pdfViewer.Load(pdfFilePath);

        //    // Add the PdfiumViewer control to a container in your UI
        //    yourContainer.Controls.Add(pdfViewer); // Replace 'yourContainer' with the name of your container control

        //    // Set the size of the PdfiumViewer control
        //    pdfViewer.Dock = DockStyle.Fill; // If using Windows Forms

        //    // Make the container visible
        //    yourContainer.Visible = true;
        }
    }
}
