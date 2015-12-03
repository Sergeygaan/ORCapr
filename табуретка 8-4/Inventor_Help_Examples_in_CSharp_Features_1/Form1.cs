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
    public partial class MainForm : Form
    {
       private Init Inve;
       private newProject newProj;
       private Data DataClass;


       public MainForm()
        {
            InitializeComponent();
            Inve = new Init();
        }

        //Создание нового проекта
        public void button3_Click(object sender, EventArgs e)
        {
            newProj = new newProject(Inve.InitInventor());
            newProj.calculation();

            DataClass = new Data();
        }

        //Проверка включен ли Inventor
        public void Form1_Load(object sender, EventArgs e)
        {
            if (Inve.InitInventor() == null)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        //Построение сидушки
        public void button1_Click(object sender, EventArgs e)
        {
            if (newProj != null)
            {
                //переменные для сидушки
                DataClass.widthSeatForm(Convert.ToDouble(numericUpDown1.Value));
                DataClass.couplingSeatsForm(Convert.ToDouble(numericUpDown2.Value));
                DataClass.thicknessSeatsForm(Convert.ToDouble(numericUpDown3.Value));
                DataClass.overhangForm(DataClass.widthSeatForm(-1) - Convert.ToDouble(numericUpDown4.Value) - 1);

                //переменные для ножки
                DataClass.lengthLegForm(Convert.ToDouble(numericUpDown5.Value));
                DataClass.thicknessLegForm(Convert.ToDouble(numericUpDown6.Value));
                DataClass.couplingLegForm(Convert.ToDouble(numericUpDown7.Value));

                //переменные для проножки
                DataClass.distanceProgamForm(Convert.ToDouble(numericUpDown8.Value));
                DataClass.thicknessProgamForm(Convert.ToDouble(numericUpDown9.Value));

                // переменные для царги
                DataClass.distanceSideBarForm(Convert.ToDouble(numericUpDown11.Value));
                DataClass.thicknessSideBarForm(Convert.ToDouble(numericUpDown10.Value));
                
                //вызов метода для построения табурета
                newProj.DataProgram(DataClass);
            }
            else
            {
                MessageBox.Show("Создайте новый проект");
            }
         
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //сопряжение сидения
            double _thicknessSeatsProv = Convert.ToDouble(numericUpDown3.Value);
            conjugationSeat.Text = "0 - " + _thicknessSeatsProv * 0.5;
            numericUpDown2.Maximum = Convert.ToDecimal(_thicknessSeatsProv * 0.5);


            double _ProvMin = Convert.ToDouble(numericUpDown11.Minimum);
            double _Prov = Convert.ToDouble(numericUpDown3.Value);
            double _Prov1 = Convert.ToDouble(numericUpDown10.Value);
            _ProvMin += _Prov - _ProvMin + _Prov1;
            label16.Text = _ProvMin.ToString();
            numericUpDown11.Minimum = Convert.ToDecimal(_ProvMin);  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Параметры свеса не более 20 % от ширины сидения
            double _Prov = Convert.ToDouble(numericUpDown1.Value);
            overhangSeat.Text = "1 - " + _Prov * 0.2;
            numericUpDown4.Maximum = Convert.ToDecimal(_Prov * 0.2);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            //Параметры толщины ножки
            double _Prov = Convert.ToDouble(numericUpDown1.Value);
            double _Prov1 = Convert.ToDouble(numericUpDown4.Value);
            double _sum = (_Prov / 2) - _Prov1;
            thicknessLegText.Text = "1 - " + _sum;
            numericUpDown6.Maximum = Convert.ToDecimal(_sum);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            double _Prov = Convert.ToDouble(numericUpDown6.Value);

            label10.Text = "0 - " + _Prov * 0.4;

            numericUpDown7.Maximum = Convert.ToDecimal(_Prov * 0.4);

            //Толщина царги
            double _Prov1 = Convert.ToDouble(numericUpDown6.Value);
            label24.Text = "0 - " + _Prov1;

            numericUpDown10.Maximum = Convert.ToDecimal(_Prov1);

            //Толщина проножки
            double _Prov2 = Convert.ToDouble(numericUpDown6.Value);

            label26.Text = "0 - " + _Prov2;

            numericUpDown9.Maximum = Convert.ToDecimal(_Prov2);

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {

            //Расстояние от царги до проножки
            double _ProvMin = Convert.ToDouble(numericUpDown8.Minimum);
            double _ProvMax = Convert.ToDouble(numericUpDown8.Maximum);
            double _Prov = Convert.ToDouble(numericUpDown11.Value);
            double _Prov1 = Convert.ToDouble(numericUpDown9.Value);
            _ProvMin += _Prov - _ProvMin + _Prov1;
            label18.Text = _ProvMin.ToString();
            numericUpDown8.Minimum = Convert.ToDecimal(_ProvMin);

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            //Максимаальное расстояние от сидения до проножки 
            double _ProvMax = Convert.ToDouble(numericUpDown5.Value);

            label25.Text = _ProvMax.ToString();
            numericUpDown8.Maximum = Convert.ToDecimal(_ProvMax);  
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            //Расстояние от цаги до проножки
            double _ProvMax = Convert.ToDouble(numericUpDown11.Maximum);
            double _Prov = Convert.ToDouble(numericUpDown8.Value);
            double _Prov1 = Convert.ToDouble(numericUpDown9.Value);
            _ProvMax += _Prov - _ProvMax - _Prov1;
            label23.Text = _ProvMax.ToString();
            numericUpDown11.Maximum = Convert.ToDecimal(_ProvMax);
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            //Расстояние от цаги до проножки
            double _ProvMax = Convert.ToDouble(numericUpDown11.Maximum);
            double _Prov = Convert.ToDouble(numericUpDown8.Value);
            double _Prov1 = Convert.ToDouble(numericUpDown9.Value);
            _ProvMax += _Prov - _ProvMax - _Prov1;
            label23.Text = _ProvMax.ToString();
            numericUpDown11.Maximum = Convert.ToDecimal(_ProvMax);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {

        }








    }

       
}