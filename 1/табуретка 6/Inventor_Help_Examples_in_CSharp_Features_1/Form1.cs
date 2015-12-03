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
       private Progam sideBarClass;


       private int shet;
       double widthSeat;
       double couplingSeats;
       double thicknessSeats;
       double overhang;
       double lengthLeg;
       double thicknessLeg;
       double couplingLeg;
       double distanceProgam;
       double thicknessProgam;

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
            sideBarClass = new Progam(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
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
                    progClass.Delete();
                    sideBarClass.Delete();
                    legClass.Delete();
                    seatClass.Delete();
                }
                widthSeat = Convert.ToDouble(numericUpDown1.Value);
                couplingSeats = Convert.ToDouble(numericUpDown2.Value);
                thicknessSeats = Convert.ToDouble(numericUpDown3.Value);
                overhang = widthSeat - Convert.ToDouble(numericUpDown4.Value) - 1;
                seatClass.AddSeat(widthSeat, thicknessSeats, couplingSeats);


                lengthLeg = Convert.ToDouble(numericUpDown5.Value);
                thicknessLeg = Convert.ToDouble(numericUpDown6.Value);
                couplingLeg = Convert.ToDouble(numericUpDown7.Value);
                legClass.AddLeg(overhang, lengthLeg, thicknessLeg, couplingLeg);

                distanceProgam = Convert.ToDouble(numericUpDown8.Value);
                thicknessProgam = Convert.ToDouble(numericUpDown9.Value);
                progClass.AddProgam(overhang, thicknessLeg, distanceProgam, thicknessProgam);

                distanceProgam = Convert.ToDouble(numericUpDown11.Value);
                thicknessProgam = Convert.ToDouble(numericUpDown10.Value);
                sideBarClass.AddProgam(overhang, thicknessLeg, distanceProgam, thicknessProgam);
                shet = 1;
            }
            else
            {
                MessageBox.Show("Создайте новый проект");
            }
         
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //сопряжение сидения
            double thicknessSeatsProv = Convert.ToDouble(numericUpDown3.Value);
            conjugationSeat.Text = "0 - " + thicknessSeatsProv * 0.5;
            numericUpDown2.Maximum = Convert.ToDecimal(thicknessSeatsProv * 0.5);

            //Расстояние от сидения до царги
            //double thicknessSeatsProvMin = Convert.ToDouble(numericUpDown11.Minimum);
            //thicknessSeatsProvMin += thicknessSeatsProv - thicknessSeatsProvMin;
            //label16.Text = thicknessSeatsProvMin.ToString();
            //numericUpDown11.Minimum = Convert.ToDecimal(thicknessSeatsProvMin);

            double ProvMin = Convert.ToDouble(numericUpDown11.Minimum);
            double Prov = Convert.ToDouble(numericUpDown3.Value);
            double Prov1 = Convert.ToDouble(numericUpDown10.Value);
            ProvMin += Prov - ProvMin + Prov1;
            label16.Text = ProvMin.ToString();
            numericUpDown11.Minimum = Convert.ToDecimal(ProvMin);  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            //double widthSeatProv = Convert.ToDouble(numericUpDown1.Value) - 1;
            //double overhangProv = Convert.ToDouble(numericUpDown4.Value);
            //double thicknessLegProv = Convert.ToDouble(numericUpDown6.Value);

            //double ostav = widthSeatProv - 2 * (thicknessLegProv + overhangProv);

            //overhangSeat.Text = "0 - " + ostav;
            //thicknessLegText.Text = "0 - " + ostav;

            //numericUpDown4.Maximum = Convert.ToDecimal(ostav);
            //numericUpDown6.Maximum = Convert.ToDecimal(ostav);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            double thicknesLegProv = Convert.ToDouble(numericUpDown6.Value);

            label10.Text = "0 - " + thicknesLegProv * 0.4;

            numericUpDown7.Maximum = Convert.ToDecimal(thicknesLegProv * 0.4);



        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {

            //Расстояние от царги до проножки
            double ProvMin = Convert.ToDouble(numericUpDown8.Minimum);
            double ProvMax = Convert.ToDouble(numericUpDown8.Maximum);
            double Prov = Convert.ToDouble(numericUpDown11.Value);
            double Prov1 = Convert.ToDouble(numericUpDown9.Value);
            ProvMin += Prov - ProvMin + Prov1;
            label18.Text = ProvMin.ToString();
            numericUpDown8.Minimum = Convert.ToDecimal(ProvMin);

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            //Максимаальное расстояние от сидения до проножки 
            double ProvMax = Convert.ToDouble(numericUpDown5.Value);

            label25.Text = ProvMax.ToString();
            numericUpDown8.Maximum = Convert.ToDecimal(ProvMax);  
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            //Расстояние от цаги до проножки
            double ProvMax = Convert.ToDouble(numericUpDown11.Maximum);
            double Prov = Convert.ToDouble(numericUpDown8.Value);
            double Prov1 = Convert.ToDouble(numericUpDown9.Value);
            ProvMax += Prov - ProvMax - Prov1;
            label23.Text = ProvMax.ToString();
            numericUpDown11.Maximum = Convert.ToDecimal(ProvMax);
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            //Расстояние от цаги до проножки
            double ProvMax = Convert.ToDouble(numericUpDown11.Maximum);
            double Prov = Convert.ToDouble(numericUpDown8.Value);
            double Prov1 = Convert.ToDouble(numericUpDown9.Value);
            ProvMax += Prov - ProvMax - Prov1;
            label23.Text = ProvMax.ToString();
            numericUpDown11.Maximum = Convert.ToDecimal(ProvMax);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {

        }








    }

       
}