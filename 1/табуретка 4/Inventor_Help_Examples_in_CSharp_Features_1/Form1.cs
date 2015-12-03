using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Inventor;
using System.Diagnostics;
using System.Reflection;

namespace Inventor_Help_Examples_in_CSharp_Features_1
{
    public partial class Form1 : Form
    {
       private Init Inve;
       private newProject newProj;
       private Seat seatClass;
       private leg legClass;
       private Progam progClass;
       private int shet;

       double widthSeat;
       double couplingSeats;
       double thicknessSeats;
       double overhang;
       double lengthLeg;
       double thicknessLeg;
       double couplingLeg;

        public Form1()
        {
            InitializeComponent();
            Inve = new Init();
        }

        //Создание нового проекта
        private void button3_Click(object sender, EventArgs e)
        {
            shet = 0;

            newProj = new newProject(Inve.InitInventor());
            newProj.calculation();

            seatClass = new Seat(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
            legClass = new leg(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
            progClass = new Progam(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
        }
        //Проверка включен ли Inventor
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Inve.InitInventor() == null)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        //Построение сидушки
        private void button1_Click(object sender, EventArgs e)
        {
            if (newProj != null)
            {
                if (shet != 0)
                {
                    legClass.Delete();
                    seatClass.Delete();
                    progClass.Delete();
                }
                widthSeat = Convert.ToDouble(numericUpDown1.Value);
                couplingSeats = Convert.ToDouble(numericUpDown2.Value);
                thicknessSeats = Convert.ToDouble(numericUpDown3.Value);
                overhang = widthSeat - Convert.ToDouble(numericUpDown4.Value) -1;
                seatClass.AddSeat(widthSeat, thicknessSeats, couplingSeats);


                lengthLeg = Convert.ToDouble(numericUpDown5.Value);
                thicknessLeg = Convert.ToDouble(numericUpDown6.Value);
                couplingLeg = Convert.ToDouble(numericUpDown7.Value);
                legClass.AddLeg(overhang, lengthLeg, thicknessLeg, couplingLeg);

                progClass.AddProgam(overhang, thicknessLeg);
                shet += 1;
            }
            else
            {
                MessageBox.Show("Создайте новый проект");
            }
         
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double thicknessSeatsProv = Convert.ToDouble(numericUpDown3.Value);

            conjugationSeat.Text = "0 - " + thicknessSeatsProv / 2;

            numericUpDown2.Maximum = Convert.ToDecimal(thicknessSeatsProv / 2);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            double widthSeatProv = Convert.ToDouble(numericUpDown1.Value) - 1;
            double overhangProv = Convert.ToDouble(numericUpDown4.Value);
            double thicknessLegProv = Convert.ToDouble(numericUpDown6.Value);

            double ostav = widthSeatProv - 2 * (thicknessLegProv + overhangProv);

            overhangSeat.Text = "0 - " + ostav;
            thicknessLegText.Text = "0 - " + ostav;

            numericUpDown4.Maximum = Convert.ToDecimal(ostav);
            numericUpDown6.Maximum = Convert.ToDecimal(ostav);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            double widthSeatProv = Convert.ToDouble(numericUpDown1.Value);
            double thicknessLegProv = Convert.ToDouble(numericUpDown6.Value);



        }








    }

       
}