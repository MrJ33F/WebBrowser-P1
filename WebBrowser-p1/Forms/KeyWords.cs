using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser_p1
{
    public partial class KeyWords : Form
    {
        private bool mouseDown;
        private Point lastMouseLocation;

        public KeyWords()
        {
            InitializeComponent();
        }

        private void BorderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastMouseLocation = e.Location;
        }

        private void BorderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastMouseLocation.X) + e.X, (this.Location.Y - lastMouseLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void BorderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //metode
        public string getKeyWord()
        {
            return textBox1.Text;
        }
    }
}
