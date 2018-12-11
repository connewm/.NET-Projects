using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


/**
 * Connor Newman -- CSE 4253
 * The purpose of this application is to allow the creation of a serializable list of "reports" using a GUI.
 * The application can be used for any format of report with certain stipulations. Because of this, its main purpose is 
 * for organizing reports for the purpose of research. There are certain functionalities to help with this:
 *  Title: plain text entry for report title
 *  Subject: plain text for storing subject of research
 *  Link: Allows user to provide a web link to the actual report or relevant resource with exception handling
 *  File: Allows user to attach a PDF file and access it using the web browser with exception handling
 *  Summary: Rich text allowing images, hyperlinks, and plain text for creating a summary of the given report
 *  Save: saves the current report
 * In addition, users save report lists as file type ".rlist" and can access entries that were saved previously
 * Saving has error checking meaning that users who have not either saved the current report, report list, or both, will be
 * prompted to do so before exiting.
 * 
 * Future Improvements: 
 *  -This program could be made better by adding functionality for attaching and viewing other file types
 *      such as (.docx, .txt, etc.)
 *  -Modifying the current program into a Works Cited generator could also be another useful function of the program
 *  -Redirecting invalid hyperlinks to a search engine, with the 'invalid' link (or a keyword) as the search term.
 *      Currently Process.Start() simply throws an exception for invalid links, meaning essentially links
 *      must be copied and pasted, although the exception is caught gracefully and execution continues
 *      
 *      Rather than throwing an exception, perhaps have it redirect to a search engine if the link is "invalid"
 *  -IMPORTANT: For now, ReportList uses absolute filepaths
 **/

namespace ProgrammingAssignment4
{
    public partial class ReportList : Form
    {
        // tracks changes to see if current report has been saved
        bool reportHasSaved = true;
        // tracks changes to see if report list has been saved
        bool listHasSaved = true;
        List<ReportInfo> reporter = new List<ReportInfo>();
        BindingList<ReportInfo> bindingReportList;

        public ReportList()
        {
            InitializeComponent();
            // create a binding lsit from the ReportInfo List
            bindingReportList = new BindingList<ReportInfo>(reporter);
            bindingReportList.RaiseListChangedEvents = true;
            bindingReportList.AllowNew = true;
            bindingReportList.AllowEdit = true;

            // set the data source for the list box
            this.rList.DataSource = bindingReportList;
            this.rList.DisplayMember = "Title";

            // when the program is opened we want it to behave like a 'New Report' was clicked
            ReportInfo newReport = new ReportInfo();
            bindingReportList.Add(newReport);
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Get rid of filler text when focused
        private void textBox1_wasFocused(object sender, EventArgs e)
        {
            ReportInfo report = new ReportInfo();
            if (this.textBox1.Text == report.Title)
            {
                this.textBox1.Text = "";
            }
        }

        // get rid of filler text when focused
        private void textBox2_wasFocused(object sender, EventArgs e)
        {
            ReportInfo report = new ReportInfo();
            if (this.textBox2.Text == report.Subject)
            {
                this.textBox2.Text = "";
            }
        }

        // get rid of filler text when focused, return link to default when textBox3 empty
        private void textBox3_wasFocused(object sender, EventArgs e)
        {
            ReportInfo report = new ReportInfo();
            if (this.textBox3.Text == report.Link)
            {
                this.textBox3.Text = "";
            }
            if (this.textBox3.Text == "")
            {
                
                this.linkLabel1.Text = report.WebLinkDefaultText;
            }
        }

        // if textBox3 loses focus while empty, return link text to default
        private void textBox3_notFocused(object sender, EventArgs e)
        {
            ReportInfo report = new ReportInfo();
            if (this.textBox3.Text == "")
            {
                this.linkLabel1.Text = report.WebLinkDefaultText;
            }
        }

        // indicate if changes to Title property are saved, discluding auto population of filler text on report generation
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // only report changes if text has changed from default text
            if (this.textBox1.Text != new ReportInfo().Title)
            {
                this.reportHasSaved = false;
                this.listHasSaved = false;
            }

        }

        // indicate if changes to Link property are saved, discluding auto population of filler text on report generation
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // only report changes if text has changed from default text
            if (this.textBox3.Text != new ReportInfo().Link)
            {
                this.reportHasSaved = false;
                this.listHasSaved = false;
            }

            // dynamically update the link text

            if (this.textBox3.Text != "")
            {
                this.linkLabel1.Text = this.textBox3.Text;
            }
        }

        // indicate if changes to Subject property are saved, discluding auto population of filler text on report generation
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // only report changes if text has changed from default text
            if (this.textBox2.Text != new ReportInfo().Subject)
            {
                this.reportHasSaved = false;
                this.listHasSaved = false;
            }

        }


        // behavior when a new report is generated
        private void newReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportInfo newReport = new ReportInfo();
            // adds new report to both lists
            bindingReportList.Add(newReport);
            // sets the selected one in the list box by using the count
            this.rList.SetSelected(reporter.Count - 1, true);
            
        }

        // allows the user to delete the currently selected report
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Added title in warning message so user knows which report is currently selected
            string name;
            if (this.textBox1.Text == new ReportInfo().Title)
            {
                name = "Default";
            } else
            {
                name = this.textBox1.Text;
            }
            
            if (MessageBox.Show(string.Format("You are deleting the current report with Title: {0}, are you sure you would like to continue?", name), "Report List", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    bindingReportList.RemoveAt(this.rList.SelectedIndex);
                    this.rList.SetSelected(reporter.Count - 1, true);
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.Close();
                }
            }
        }

        // save button behavior -- saves data to bound report list, updating listbox
        private void saveButton_Click(object sender, EventArgs e)
        {
            int index = this.rList.SelectedIndex;
            ReportInfo report = this.rList.SelectedItem as ReportInfo;
            if (report != null)
            {
                report.Title = this.textBox1.Text;
                report.Subject = this.textBox2.Text;
                int temp = this.linkLabel2.Links.Count;
                // report link is same as text
                report.Link = this.textBox3.Text;
                report.FileSource = this.linkLabel2.Links[0].LinkData as string;
                temp = this.linkLabel2.Links.Count;
                // reset the linklabel links collection to count 0
                
                report.FileText = this.linkLabel2.Text;
                report.DatePublished = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day);
                report.Summary = this.richTextBox1.Rtf;

                // syncs list box with save button hit
                bindingReportList.ResetItem(index);
                // no unsaved changes in current report only
                this.reportHasSaved = true;
            }
        }

        // directs user to web link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(this.textBox3.Text);
            }
            // catches invalid link error gracefully with error message dialog
            catch(Win32Exception)
            {
                MessageBox.Show("Not a valid Link","Report List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }


        // tracks when user selects report from list box and populates fields
        private void rList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportInfo report = (ReportInfo)this.rList.SelectedItem;
            if (report != null)
            {
                this.textBox1.Text = report.Title;
                this.textBox2.Text = report.Subject;
                this.textBox3.Text = report.Link;
                this.linkLabel1.Text = report.Link;
                // check for linklabel links count 0 then add
                this.linkLabel2.Links[0] = new LinkLabel.Link(0, 0, report.FileSource);
                this.linkLabel2.Text = report.FileText;
                this.dateTimePicker1.Value = new DateTime(report.DatePublished.Year, report.DatePublished.Month, report.DatePublished.Day);
                this.richTextBox1.Rtf = report.Summary;
            }
        }

        // saves report list data in XML format
        private void saveWorksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFile.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer s = new XmlSerializer(reporter.GetType());
                using (TextWriter w = new StreamWriter(saveFile.FileName))
                {
                    s.Serialize(w, reporter);
                }

            }
            // becomes true when the entire list project has saved, even if the current report hasnt been saved to the list
            this.listHasSaved = true;
        }

        // checks for changes to DatePublished property, not counting default values which are auto populated on report generation
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ReportInfo temp = new ReportInfo();
            if (this.dateTimePicker1.Value.Month != temp.DatePublished.Month || this.dateTimePicker1.Value.Day != temp.DatePublished.Day || this.dateTimePicker1.Value.Year != temp.DatePublished.Year)
            {
                this.reportHasSaved = false;
                this.listHasSaved = false;
            }
        }

        // opens .rlist file and parses XML into ReportInfo which is then added to the BindingList represented in the lsit box
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (this.openFile.ShowDialog() == DialogResult.OK)
            {
                
                XmlSerializer s = new XmlSerializer(reporter.GetType());
                using (TextReader reader = new StreamReader(openFile.FileName))
                {
                    List<ReportInfo> addLists = (List <ReportInfo>) s.Deserialize(reader);
                    foreach(ReportInfo report in addLists)
                    {
                        // add all reports that aren't the default generated report
                        // this saves the current file from having two default generated reports
                        if (report.Title != new ReportInfo().Title)
                        {
                            bindingReportList.Add(report);
                        }
                    }
                }
            }
        }

        // display different error messages for unsaved lsit and report before closing
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if neither the report nor list project has been saved
            if (!this.reportHasSaved && !this.listHasSaved)
            {
                // user has option to ignore dialog
                if (MessageBox.Show("There are unsaved changes to the project and current report, are you sure you want to close?", "Report List", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // the user has ignored the warning and its ok to close
                    this.Close();
                }
            } else if (!this.reportHasSaved)
            {
                // the current report is unsaved
                if(MessageBox.Show("There are unsaved changes to the current report, are you sure you want to close?", "Report List", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
                // the project is unsaved
            } else if (!this.listHasSaved)
            {
                if (MessageBox.Show("There are unsaved changes to the list project, are you sure you want to close?", "Report List", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            } else
            {
                // close without check
                this.Close();
            }
        }

        // helper method to extract the name of the PDF from the link for display purposes
        private string getPDFName(string filepath)
        {

            int index = filepath.LastIndexOf('\\');
            return filepath.Substring(index + 1);
            
        }

        // opens dialog for selecting PDF to attach -- simply pulls PDF filepath and name and stores in ReportInfo
        private void browseButton_Click(object sender, EventArgs e)
        {
            if (this.browseFile.ShowDialog() == DialogResult.OK)
            {
                // indicate report and lsit have been changed
                this.listHasSaved = false;
                this.reportHasSaved = false;
                // add a new link to linklabel with the PDF file path
                this.linkLabel2.Links[0] = new LinkLabel.Link(0, 0, this.browseFile.FileName);
                // set its text to the PDF actual name
                this.linkLabel2.Text = getPDFName(this.browseFile.FileName);
            }
        }

        // uses the web browser to display the associated PDF link if it is valid -- allows for local filepath
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // combine the current directory of any machine to the 

            try
            {
                Process.Start(this.linkLabel2.Links[0].LinkData as string);
            }
            // for cases of invalid or non-existing link -- catch gracefully with error dialog
            catch (Win32Exception)
            {
                /*
                 * When an absolute filepath is not found, the program will search for an relative filepath within the project folder.
                 * i.e. if a PDF is saved within a folder called D:\example\example\ProgrammingAssignment4\ProgrammingAssignment4\PDF-files
                 * and that absolute path cannot be found, the program then takes the current directoy (which is default ...\ProgrammingAssignment4\bin\(either Debug or Release)
                 * and gets the absolute path up to the parent directory of bin, which should be the project directory
                 * 
                 * It then concats that with the relative location of the PDF by cutting the absolute portion of the filepath, i.e. everything before the project directory
                 * In the example above it cuts off "D:\example\example\ProgrammingAssignment4" leaving only "\ProgrammingAssignment4\PDF-files"
                 * 
                 * It concats these two to make a relative filepath assuming the file is within the same directory IN the project folder.
                 * This does not cover all relative filepaths the PDF could have, but covers one instance in which a relative filepath would be needed
                 * 
                 * For all other cases where the PDF is at a relative filepath, the program simply throws an exception and the file must be re-added to the Report List
                 * */
                try
                {
                    string relativePath = string.Concat(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("bin") - 1),  // 22 -- the length of project directory name, ProgrammingAssignment4
                        this.linkLabel2.Links[0].LinkData.ToString().Substring(linkLabel2.Links[0].LinkData.ToString().LastIndexOf("ProgrammingAssignment4") + 22));
                    Process.Start(relativePath);
                    // set the link to the relative, allowing it to be saved for future use -- won't have to create this string every time its accessed
                    this.linkLabel2.Links[0] = new LinkLabel.Link(0, 0, relativePath);
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("Filepath not set or invalid", "Report List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Filepath not set", "Report List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Track rich text box (Summary) changes not including default value which is empty string
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // if the text box is not empty
            if (this.richTextBox1.Text != "")
            {
                this.listHasSaved = false;
                this.reportHasSaved = false;
            }
        }

        
    }
}
