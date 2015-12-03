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
        Init Inve;
        newProject newProj;
        Seat seatClass;
        leg legClass;

        public Form1()
        {
            InitializeComponent();
            Inve = new Init();
        }

        //Создание нового проекта
        private void button3_Click(object sender, EventArgs e)
        {
            newProj = new newProject(Inve.InitInventor());
            newProj.calculation();

            seatClass = new Seat(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
            legClass = new leg(Inve.InitInventor(), newProj.oPartDoc(), newProj.oCompDef());
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
            double widthSeat = Convert.ToDouble(textBox1.Text); 
            seatClass.AddSeat(widthSeat);
           
        }
        //Постоение ножек
        private void button2_Click(object sender, EventArgs e)
        {
            legClass.AddLeg();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double widthSeat = Convert.ToDouble(textBox1.Text);
            //seatClass.Delete();
            legClass.Delete();
            //seatClass.Delete();
            //seatClass.AddSeat(widthSeat);
        }


    }

       
}