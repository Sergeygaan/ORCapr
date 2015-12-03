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
    class leg
    {
        private PartDocument oPartDoc = default(PartDocument);
        private PartComponentDefinition oCompDef = default(PartComponentDefinition);
        private Inventor.Application ThisApplication;

        private PlanarSketch oSketch = default(PlanarSketch);
        private double couplingLeg1;

        Сonstruction СonstructionClassLeg = new Сonstruction();

        public leg(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }


        public void AddLeg(double overhang, double lengthLeg, double thicknessLeg, double couplingLeg)
        {
            this.couplingLeg1 = couplingLeg;
            oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);
            
            for (int i = 0; i <= 1; i++)
                for (int j = 0; j <= 1; j++)
                {
                    oSketch.SketchLines.AddAsTwoPointRectangle
                        (ThisApplication.TransientGeometry.CreatePoint2d(System.Math.Pow(-1, i) * overhang, System.Math.Pow(-1, j) * overhang),
                        ThisApplication.TransientGeometry.CreatePoint2d(System.Math.Pow(-1, i) * overhang - System.Math.Pow(-1, i) * thicknessLeg, System.Math.Pow(-1, j) * overhang - System.Math.Pow(-1, j) * thicknessLeg));
                }
            СonstructionClassLeg.Const(oCompDef, oSketch, lengthLeg, couplingLeg);
         }

        public void Delete()
        {
            СonstructionClassLeg.oExtru().Delete();
            if (couplingLeg1 != 0)
                СonstructionClassLeg.oFill().Delete();
        }
    }
}