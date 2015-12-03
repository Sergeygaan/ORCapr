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
       private Seat seatClass;
       private leg legClass;
       private Progam progClass;
       private Progam sideBarClass;

       private double _widthSeat;
       private double _couplingSeats;
       private double _thicknessSeats;
       private double _overhang;
       private double _lengthLeg;
       private double _thicknessLeg;
       private double _couplingLeg;
       private double _distanceProgam;
       private double _thicknessProgam;
       private bool _Init;

       public MainForm()
        {
            InitializeComponent();
            Inve = new Init();
        }

        //Создание нового проекта
        public void button3_Click(object sender, EventArgs e)
        {
            _Init = false;

            newProj = new newProject(Inve.InitInventor());
            newProj.calculation();

            seatClass = new Seat(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
            legClass = new leg(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
            progClass = new Progam(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
            sideBarClass = new Progam(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
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
                if (_Init != false)
                {
                    progClass.Delete();
                    sideBarClass.Delete();
                    legClass.Delete();
                    seatClass.Delete();
                }
                _widthSeat = Convert.ToDouble(numericUpDown1.Value);
                _couplingSeats = Convert.ToDouble(numericUpDown2.Value);
                _thicknessSeats = Convert.ToDouble(numericUpDown3.Value);
                _overhang = _widthSeat - Convert.ToDouble(numericUpDown4.Value) - 1;
                seatClass.AddSeat(_widthSeat, _thicknessSeats, _couplingSeats);


                _lengthLeg = Convert.ToDouble(numericUpDown5.Value);
                _thicknessLeg = Convert.ToDouble(numericUpDown6.Value);
                _couplingLeg = Convert.ToDouble(numericUpDown7.Value);
                legClass.AddLeg(_overhang, _lengthLeg, _thicknessLeg, _couplingLeg);

                _distanceProgam = Convert.ToDouble(numericUpDown8.Value);
                _thicknessProgam = Convert.ToDouble(numericUpDown9.Value);
                progClass.AddProgam(_overhang, _thicknessLeg, _distanceProgam, _thicknessProgam);

                _distanceProgam = Convert.ToDouble(numericUpDown11.Value);
                _thicknessProgam = Convert.ToDouble(numericUpDown10.Value);
                sideBarClass.AddProgam(_overhang, _thicknessLeg, _distanceProgam, _thicknessProgam);
                _Init = true;
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