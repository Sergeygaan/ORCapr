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
    class Data
    {
        private double _widthSeat;
        private double _couplingSeats;
        private double _thicknessSeats;
        private double _overhang;
        private double _lengthLeg;
        private double _thicknessLeg;
        private double _couplingLeg;
        private double _distanceProgam;
        private double _thicknessProgam;
        private double _distanceSideBar;
        private double _thicknessSideBar;


        private PartDocument _PartDoc = default(PartDocument);
        private PartComponentDefinition _CompDef = default(PartComponentDefinition);
        private Inventor.Application ThisApplication;

         public Data(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
         {
            this.ThisApplication = ThisApplication;
            this._PartDoc = oPartDoc;
            this._CompDef = oCompDef;
         }
        // Сидушки
         public double widthSeatForm(double _widthSeat1)
         {
             if (_widthSeat1  >= 0)
             {
                 this._widthSeat = _widthSeat1;
             }
             return _widthSeat;
         }

         public double couplingSeatsForm(double _couplingSeats1)
         {
             if (_couplingSeats1 >= 0)
             this._couplingSeats = _couplingSeats1;

             return _couplingSeats;
         }

         public double thicknessSeatsForm(double _thicknessSeats1)
         {
             if (_thicknessSeats1 >= 0)
             this._thicknessSeats = _thicknessSeats1;

             return _thicknessSeats;
         }

         public double overhangForm(double _overhang1)
         {
             if (_overhang1 >= 0)
             this._overhang = _overhang1;

             return _overhang;
         }
        // Ножки
         public double lengthLegForm(double _lengthLegt1)
         {
             if (_lengthLegt1 != -1)
             this._lengthLeg = _lengthLegt1;

             return _lengthLeg;
         }

         public double thicknessLegForm(double _thicknessLeg1)
         {
             if (_thicknessLeg1 != -1)
             this._thicknessLeg = _thicknessLeg1;

             return _thicknessLeg;
         }

         public double couplingLegForm(double _couplingLeg1)
         {
             if (_couplingLeg1 != -1)
             this._couplingLeg = _couplingLeg1;

             return _couplingLeg;
         }
        //Проножка
         public double distanceProgamForm(double _distanceProgam1)
         {
             if (_distanceProgam1 != -1)
             this._distanceProgam = _distanceProgam1;

             return _distanceProgam;
         }

         public double thicknessProgamForm(double _thicknessProgam1)
         {
             if (_thicknessProgam1 != -1)
             this._thicknessProgam = _thicknessProgam1;

             return _thicknessProgam;
         }
        //Царга
         public double distanceSideBarForm(double _distanceSideBar1)
         {
             if (_distanceSideBar1 != -1)
             this._distanceSideBar = _distanceSideBar1;

             return _distanceSideBar;
         }

         public double thicknessSideBarForm(double _thicknessSideBar1)
         {
             if (_thicknessSideBar1 != -1)
             this._thicknessSideBar = _thicknessSideBar1;

             return _thicknessSideBar;
         }

        //Параметры инвентора
         public PartDocument oPartDocForm()
         {
             return _PartDoc;
         }

         public PartComponentDefinition oCompDefForm()
         {
             return _CompDef;
         }

         public  Inventor.Application ThisApplicationForm()
         {
             return ThisApplication;
         }

    }
}
