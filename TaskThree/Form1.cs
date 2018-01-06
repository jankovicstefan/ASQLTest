using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaskTwo;
using System.Xml.Linq;

namespace TaskThree
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XMLHelper xmlHelper = new XMLHelper();

        private void createXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);

                var element = new XDocument(xmlHelper.CreateAndSaveXml(dir));

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML file | *.xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    element.Save(Path.GetFullPath(sfd.FileName));
                    DialogResult msgResult = MessageBox.Show("XML Successfully Saved at \n" + Path.GetFullPath(sfd.FileName),
                                            "Success", 
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> elements = new List<string>();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML file|*.xml";
            DialogResult result = ofd.ShowDialog();

            elements = this.xmlHelper.GetXMLData(ofd.FileName);

            dataGrid.Rows.Clear();

            for (int i=0; i< elements.Count; i+=3)
            {
                dataGrid.Rows.Add(elements[i], elements[i + 1], elements[i + 2]);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
