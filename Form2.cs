using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to close this form?", "Exit", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question).ToString() == "OK")
            {
                this.Close();
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            FGrades mark = new FGrades();
            Validator validate = new Validator();
            if (validate.NumericGrade(txtFinal.Text)){
                if (validate.NumericGrade(txtMidterm.Text))
                {
                    if (validate.NumericGrade(txtProject.Text))
                    {
                        mark.Final = Convert.ToDouble(txtFinal.Text);
                        mark.Project = Convert.ToDouble(txtProject.Text);
                        mark.Midterm = Convert.ToDouble(txtMidterm.Text);

                        txtMidtermConverted.Text = mark.MidtermPercent().ToString();
                        txtProjectConverted.Text = mark.ProjectPercent().ToString();
                        txtFinalConverted.Text = mark.FinalPercent().ToString();
                        txtTotal.Text = mark.TotalPercent().ToString();
                        txtLetterGrade.Text = mark.LetterGrade().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Wrong input for project grade");
                        txtProject.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input for midterm grade");
                    txtMidterm.Focus();
                }
            }
            else
            {
                MessageBox.Show("Wrong input for final grade");
                txtFinal.Focus();
            }
        }


        static string dirPath = @".\S2023\";
        string txtPath = dirPath + "FExam.txt";
        string xmlPath = dirPath + "FExam.xml";
        private void Form2_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
        private void btnWriteTxt_Click(object sender, EventArgs e)
        {
            FileStream fsW = new FileStream(txtPath, FileMode.Append, FileAccess.Write);
            StreamWriter objW = new StreamWriter(fsW);
            objW.Write(txtMidterm.Text + "|");
            objW.Write(txtProject.Text + "|");
            objW.Write(txtFinal.Text + "|");
            objW.Write(txtTotal.Text + "|");
            objW.WriteLine(txtLetterGrade.Text);
            objW.Close();
            fsW.Close();
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            // create the XmlWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true; settings.IndentChars = (" ");
            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(xmlPath, settings);
            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Grades");

            FileStream fsR = new FileStream(txtPath, FileMode.Open, FileAccess.Read);
            StreamReader objR = new StreamReader(fsR);

            while (objR.Peek() != -1)
            {
                string line = objR.ReadLine(); //read a line (product data) from text file
                string[] arrLine = line.Split('|'); //create an array of string data from the line

                xmlOut.WriteStartElement("Grade"); 
                xmlOut.WriteElementString("Midterm", arrLine[0]); // textBox1.Text.Trim());
                xmlOut.WriteElementString("Project", arrLine[1]); // textBox2.Text.Trim());
                xmlOut.WriteElementString("Final", arrLine[2]);
                xmlOut.WriteElementString("Total", arrLine[3]);
                xmlOut.WriteElementString("LetterGrade", arrLine[4]);
                xmlOut.WriteEndElement();
            }
            objR.Close();
            fsR.Close();
            // write the end tag for the root element
            xmlOut.WriteEndElement();
            // close the XmlWriter object
            xmlOut.Close();
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(xmlPath, settings);
            string tempStr = "",midterm="",final="",total="",project="",grade="";

            if (xmlIn.ReadToDescendant("Grade"))
            {

                do
                {
                    xmlIn.ReadStartElement("Grade");
                    midterm = xmlIn.ReadElementContentAsString();
                    project = xmlIn.ReadElementContentAsString();
                    final = xmlIn.ReadElementContentAsString();
                    total = xmlIn.ReadElementContentAsString();
                    grade = xmlIn.ReadElementContentAsString();
                    tempStr += "Midterm:" + midterm + "\n"  +
                        "Project:" + project + "\n" + "Final:" + final + "\n" +
                        "Total:" + total + "\n" + "grade:" + grade;
                    MessageBox.Show(tempStr, "Reading");
                    tempStr = "";
                }
                while (xmlIn.ReadToNextSibling("Grade"));
            }
            // close the XmlReader object
            xmlIn.Close();
            MessageBox.Show(tempStr);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "0";
            txtProjectConverted.Text = "0";
            txtProject.Text = "0";
            txtMidtermConverted.Text = "0";
            txtMidterm.Text = "0";
            txtLetterGrade.Text = "F";
            txtFinalConverted.Text = "0";
            txtFinal.Text = "0";
            
        }
    }
}
