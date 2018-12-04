using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFBattle
{
    class TextBoxStreamWriter : System.IO.TextWriter
    {
        private TextBox writer;

        // overrides Encoding and sets to UTF8
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        // allows the current thread to write to an object (Textbox) created in another thread
        public override void Write(char value)
        {
            base.Write(value);
            writer.Dispatcher.BeginInvoke(new Action(() =>
            {
                // data appended to text box as character data is written
                writer.AppendText(value.ToString());
                writer.ScrollToEnd();
            })
            );
        }

        // constructor initiates the textbox control
        public TextBoxStreamWriter(TextBox writer)
        {
            this.writer = writer as TextBox;
        }
    }
}
