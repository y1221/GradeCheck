using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCheck
{
    public partial class Form1 : Form
    {
        private struct Attends
        {
            public double dblMathAttend;
            public double dblPhysicsAttend;
            public double dblEngAttend;
        }
        private struct Points
        {
            public int intMathPoint;
            public int intPhysicsPoint;
            public int intEngPoint;
        }

        enum Subjects
        {
            math,
            Physics,
            Eng
        }

        const int cstMathAve = 73;
        const int cstPhysicsAve = 65;
        const int cstEngAve = 77;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
        }

        private void btnJudge_Click(object sender, EventArgs e)
        {
            Attends attends = new Attends();
            convTextToValue(txtMathAttend.Text, out attends.dblMathAttend);        //数学の出席率取得
            convTextToValue(txtPhysicsAttend.Text, out attends.dblPhysicsAttend);  //物理の出席率取得
            convTextToValue(txtEngAttend.Text, out attends.dblEngAttend);          //英語の出席率取得

            Points points = new Points();
            convTextToValue(txtMathPoint.Text, out points.intMathPoint);        //数学の点数取得
            convTextToValue(txtPhysicsPoint.Text, out points.intPhysicsPoint);  //物理の点数取得
            convTextToValue(txtEngPoint.Text, out points.intEngPoint);          //英語の点数取得

            //成績判定
            lblMathJudge.Text = judgeGrade(attends.dblMathAttend, points.intMathPoint);
            lblPhysicsJudge.Text = judgeGrade(attends.dblPhysicsAttend, points.intPhysicsPoint);
            lblEngJudge.Text = judgeGrade(attends.dblEngAttend, points.intEngPoint);

            //平均点比較
            lblMathCompare.Text = compareAverage(points.intMathPoint, Subjects.math);
            lblPhysicsCompare.Text = compareAverage(points.intPhysicsPoint, Subjects.Physics);
            lblEngCompare.Text = compareAverage(points.intEngPoint, Subjects.Eng);
        }
        private void convTextToValue(string input, out double value)
        {
            if (double.TryParse(input, out value) == false){
                value = -1.0;
            }
        }
        private void convTextToValue(string input, out int value)
        {
            if (int.TryParse(input, out value) == false)
            {
                value = -1;
            }
        }
        private string judgeGrade(double attend, int point)
        {
            if (80 <= attend && attend <= 100)
            {
                if (80 <= point && point <= 100)
                {
                    return "A判定";
                }
                else if (70 <= point && point < 80)
                {
                    return "B判定";
                }
                else if (60 <= point && point < 70)
                {
                    return "C判定";
                }
                else if (0 <= point && point < 60)
                {
                    return "不合格";
                }
                else
                {
                    return "エラー";
                }

            }
            else if (0 <= attend && attend < 80)
            {
                return "不合格";
            }
            else
            {
                return "エラー";
            }
        }
        private string compareAverage(int point, Subjects subject)
        {
            int average = 0;

            switch (subject)
            {
                case Subjects.math:
                    average = cstMathAve;
                    break;

                case Subjects.Physics:
                    average = cstPhysicsAve;
                    break;

                case Subjects.Eng:
                    average = cstEngAve;
                    break;

                default:
                    return "エラー";
            }

            if (average <= point)
            {
                return "平均点以上";
            }
            else
            {
                return "平均点以下";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMathAttend.Text = "";
            txtMathPoint.Text = "";
            lblMathJudge.Text = "";
            lblMathCompare.Text = "";
            txtPhysicsAttend.Text = "";
            txtPhysicsPoint.Text = "";
            lblPhysicsJudge.Text = "";
            lblPhysicsCompare.Text = "";
            txtEngAttend.Text = "";
            txtEngPoint.Text = "";
            lblEngJudge.Text = "";
            lblEngCompare.Text = "";
        }
    }
}
