#region Copyright
/***************************************************************************************
 ******Copyright (C) 2016 Pritam Zope*****
 
  <copyright file="Start_Form.cs" company="">
  
 {-  Program Name = Silver-J
      An Integrated Development Environment(IDE) for Java Programming
      Language written In C#   -}  
 
   This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
  
   Please credit me if you reuse, don't sell it under your own name, don't pretend you're me
  </copyright>
  * ****************************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Silver_J
{
    public partial class Start_Form : Form
    {
        Timer timer = new Timer();
     
        bool isPanelDragged = false;
        Point offset;

        public Start_Form()
        {
            InitializeComponent();
            SetAndStartTimer();
        }

        private void SetAndStartTimer()
        {
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        static int count = 0;

        void timer_Tick(object sender, EventArgs e)
        {
            count += 2;

            if (count==100)
            {
                timer.Stop();
                this.Close();
            }
        }



        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanelDragged = true;
                Point pointStartPosition = this.PointToScreen(new Point(e.X, e.Y));
                offset = new Point();
                offset.X = this.Location.X - pointStartPosition.X;
                offset.Y = this.Location.Y - pointStartPosition.Y;
            }
            else
            {
                isPanelDragged = false;
            }
            if (e.Clicks == 2)
            {
                isPanelDragged = false;
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isPanelDragged = false;
        }

        private void Start_Form_Load(object sender, EventArgs e)
        {
            //generate a text for the loading area
            Generate();
        }

        void Generate()
        {
            List<string> Quotes = new List<string>();

            Random rand = new Random();

            StreamReader textReader = new StreamReader("StartText.txt");

            string line = "";

            while (!textReader.EndOfStream)
            {
                line = textReader.ReadLine();
                Quotes.Add(line);
            }

            label3.Text = Quotes[rand.Next(1, Quotes.Count)];
        }

        private void panelWithBorder1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/thinkjava-ide/");
        }
    }
}
