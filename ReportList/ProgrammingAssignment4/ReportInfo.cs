using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingAssignment4
{
    [Serializable]
    public class ReportInfo
    {
        public ReportInfo()
        {
            // Title of report
            Title = "Enter Report Title...";
            // Subject of report
            Subject = "Enter Report Subject...";
            // web address
            Link = "Enter a web link for the report if available...";
            // link text to be displayed upon initializing report info
            WebLinkDefaultText = "http://example.com";
            // Stores PDF filepath
            FileSource = "";
            // stores PDF file name
            FileText = "Browse for a PDF File";
            // date and time of publish
            DatePublished = new DateTime(2010, 1, 1);
        }

        public string Title { get; set; }
        public string Subject { get; set; }
        public string Link { get; set; }
        public string WebLinkDefaultText { get; set; }
        public string FileSource { get; set; }
        public string FileText { get; set; }
        public DateTime DatePublished { get; set; }
        public string Summary { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
