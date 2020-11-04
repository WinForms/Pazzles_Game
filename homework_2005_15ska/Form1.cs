using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_2005_15ska
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        void shakeList()
        {
            for (int i = allnum.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = allnum[j].Text;
                allnum[j].Text = allnum[i].Text;
                allnum[i].Text = temp;
            }
        }
        void checkWin()
        {
            bool f = false;
            if (allnum[0].Text == "")
            {
                for (int i = 1; i < allnum.Count; i++)
                {
                    if (allnum[i].Text == i.ToString())
                    {
                        f = true;
                    }
                    else
                    {
                        f = false;
                        i = allnum.Count;
                    }
                }
            }
            else if (allnum[allnum.Count - 1].Text == "")
            {
                for (int i = 0; i < allnum.Count - 1; i++)
                {
                    if (allnum[i].Text == (i + 1).ToString())
                    {
                        f = true;
                    }
                    else
                    {
                        f = false;
                        i = allnum.Count;
                    }
                }
            }
            else { f = false; }

            if (f)
            {
                MessageBox.Show("Congatulations! You Win!", "You Win");
            }
        }

        int findEmptyPos()
        {
            int pos = 0;
            for (int i = 0; i < allnum.Count; i++)
            {
                if (allnum[i].Text == ""|| allnum[i].Text == "0")
                {
                    pos = i;
                    i = allnum.Count;
                }
            }
            return pos;
        }
        bool checkWinPossible()
        {
            bool f = false;
            int sum = 0;
            allnum[findEmptyPos()].Text = "0";
            List<int> intallnum = new List<int>();
            for (int i = 0; i < allnum.Count; i++)
            {
                intallnum.Add(int.Parse(allnum[i].Text));
            }
            for (int i = 0; i < 16; ++i)
            {
                if (intallnum[i] != 0)
                {
                    for (int j = 0; j < i; ++j)
                    {
                        if (intallnum[j] > intallnum[i])
                        { ++sum; }
                    }
                }
            }
            sum += 1+ findEmptyPos()/ 4;
            if (sum % 2 == 0)
            { f = true; }
            allnum[findEmptyPos()].Text = "";
            return f;
        }
        void fillList()
        {
            if (allnum.Count() > 0)
            { allnum.Clear(); }
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    allnum.Add(new Label()
                    {
                        Name = k.ToString(),
                        Size = new Size(100, 100),
                        Text = k.ToString(),
                        Location = new System.Drawing.Point(j * 100, i * 100),
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        BackColor = System.Drawing.SystemColors.GradientInactiveCaption
                    });
                    k++;
                }
            }
            for (int i = 0; i < allnum.Count; i++)
            {
                if (allnum[i].Text == "0")
                {
                    allnum[i].Text = "";
                }
                Controls.Add(allnum[i]);
            }
        }
        void fillListEndEmpty()
        {
            if (allnum.Count() > 0)
            { allnum.Clear(); }
            int k = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    allnum.Add(new Label()
                    {
                        Name = k.ToString(),
                        Size = new Size(100, 100),
                        Text = k.ToString(),
                        Location = new System.Drawing.Point(j * 100, i * 100),
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        BackColor = System.Drawing.SystemColors.GradientInactiveCaption
                    });
                    k++;
                }
            }
            for (int i = 0; i < allnum.Count; i++)
            {
                if (allnum[i].Text == "16")
                {
                    allnum[i].Text = "";
                }
                Controls.Add(allnum[i]);
            }
        }


        List<Label> allnum = new List<Label>();

        public Form1()
        {
            InitializeComponent();
            //fillList();
            fillListEndEmpty();
            //allnum[13].Text = "15";
            //allnum[14].Text = "14";
            shakeList();
            while (!checkWinPossible())
            {
                shakeList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                int pos = findEmptyPos();

                #region
                //if (e.KeyData == Keys.Up)
                //{
                //    var temp = allnum[pos].Text;
                //    allnum[pos].Text = allnum[pos - 4].Text;
                //    allnum[pos - 4].Text = temp;
                //}
                //if (e.KeyData == Keys.Down)
                //{
                //    var temp = allnum[pos].Text;
                //    allnum[pos].Text = allnum[pos + 4].Text;
                //    allnum[pos + 4].Text = temp;
                //}
                //if (e.KeyData == Keys.Left)
                //{
                //    if (pos != 0 && pos != 4 && pos != 8 && pos != 12)
                //    {
                //        var temp = allnum[pos].Text;
                //        allnum[pos].Text = allnum[pos - 1].Text;
                //        allnum[pos - 1].Text = temp;
                //    }
                //}
                //if (e.KeyData == Keys.Right)
                //{
                //    if (pos != 3 && pos != 7 && pos != 11 && pos != 15)
                //    {
                //        var temp = allnum[pos].Text;
                //        allnum[pos].Text = allnum[pos + 1].Text;
                //        allnum[pos + 1].Text = temp;
                //    }
                //}
                #endregion


                if (e.KeyData == Keys.Up)
                {

                    var temp = allnum[pos].Text;
                    allnum[pos].Text = allnum[pos + 4].Text;
                    allnum[pos + 4].Text = temp;
                    checkWin();
                }
                if (e.KeyData == Keys.Down)
                {
                    var temp = allnum[pos].Text;
                    allnum[pos].Text = allnum[pos - 4].Text;
                    allnum[pos - 4].Text = temp;
                    checkWin();
                }
                if (e.KeyData == Keys.Left)
                {
                    if (pos != 3 && pos != 7 && pos != 11 && pos != 15)
                    {
                        var temp = allnum[pos].Text;
                        allnum[pos].Text = allnum[pos + 1].Text;
                        allnum[pos + 1].Text = temp;
                    }
                    checkWin();
                }
                if (e.KeyData == Keys.Right)
                {
                    if (pos != 0 && pos != 4 && pos != 8 && pos != 12)
                    {
                        var temp = allnum[pos].Text;
                        allnum[pos].Text = allnum[pos - 1].Text;
                        allnum[pos - 1].Text = temp;
                    }
                    checkWin();
                }
            }
            catch { }
        }
    }
}
