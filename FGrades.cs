using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    internal class FGrades
    {//The following are marks on midterm, project and final
        private double midterm;
        private double project;
        private double final;
        private double total;

        public double Midterm { get; set; }
        public double Project { get; set; }
        public double Final { get; set; }

        public FGrades() { }
        public FGrades(double midterm)
        {
            this.midterm = midterm;
        }
        public FGrades(double midterm,double project)
        {
            this.midterm = midterm;
            this.project = project;
        }
        public FGrades(double midterm, double project,double final)
        {
            this.midterm = midterm;
            this.project = project;
            this.final = final;
        }
        public double MidtermPercent()
        {
            return Midterm * 0.3;
        }
        public double ProjectPercent()
        {
            return Project * 0.3;
        }
        public double FinalPercent()
        {
            return Final * 0.4;
        }
        public double TotalPercent()
        {
            total= Midterm * 0.3 + Project * 0.3 + Final * 0.4;
            return total;
        }
        public string LetterGrade()
        {

            if(total<=100 && total >= 90)
            {
                return "A";
            }
            else if (total < 90 && total >= 80)
            {
                return "B";
            }
            else if (total < 80 && total >= 70)
            {
                return "C";
            }
            else if (total < 70 && total >= 60)
            {
                return "D";
            }
            else if (total < 60 && total >= 0)
            {
                return "F";
            }
            return "NAG";
        }
    }

}
