using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            draw.Click += new EventHandler(this.drawButton_Click);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int filecount = 0;

                foreach (string file in open.FileNames)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(file);

                    int txtLength = 0, k = 0;
                    string txt1;
                    
                    string[] txt2 = new string[2];
                    string[,] txt3 = new string[10000, 2];

                    txt1 = sr.ReadLine();
                    while (txt1 != null)
                    {
                        txtLength++;
                        txt2 = txt1.Split(' ');
                        txt3[k, 0] = txt2[0];
                        txt3[k, 1] = txt2[1];
                        k++;
                        txt1 = sr.ReadLine();
                    }
                    sr.Close();

                    for (int i = 0; i < txtLength; i++)
                    {
                        this.chart1.Series[filecount].Points.AddXY(txt3[i, 0], txt3[i, 1]);
                    }

                    filecount++;
                    txtLength = 0;
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
