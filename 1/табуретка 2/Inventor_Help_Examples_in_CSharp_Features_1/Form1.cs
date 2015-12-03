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
                }
                double widthSeat = Convert.ToDouble(textBox1.Text);
                double couplingSeats = Convert.ToDouble(textBox2.Text);
                double thicknessSeats = Convert.ToDouble(textBox3.Text);
                double overhang = Convert.ToDouble(textBox4.Text);
                seatClass.AddSeat(widthSeat, thicknessSeats, couplingSeats);


                double lengthLeg = Convert.ToDouble(textBox5.Text);
                double thicknessLeg = Convert.ToDouble(textBox6.Text);
                double couplingLeg = Convert.ToDouble(textBox7.Text);
                legClass.AddLeg(overhang, lengthLeg, thicknessLeg, couplingLeg);

                shet += 1;
            }
            else
            {
                MessageBox.Show("Создайте новый проект");
            }
         
        }

    }

       
}