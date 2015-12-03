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
    class Seat
    {
        private PartDocument oPartDoc = default(PartDocument);
        private PartComponentDefinition oCompDef = default(PartComponentDefinition);
        private Inventor.Application ThisApplication;

        private PlanarSketch oSketch = default(PlanarSketch);
        private double couplingSeats1;

        Сonstruction СonstructionClassSeat = new Сonstruction();

        public Seat(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }

        public void AddSeat(double widthSeat, double thicknessSeats, double couplingSeats)
        {
            // построение модели
            this.couplingSeats1 = couplingSeats;
            oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);

            oSketch.SketchLines.AddAsTwoPointRectangle
                (ThisApplication.TransientGeometry.CreatePoint2d(-widthSeat, -widthSeat),
                ThisApplication.TransientGeometry.CreatePoint2d(widthSeat, widthSeat));

            СonstructionClassSeat.Const(oCompDef, oSketch, thicknessSeats, couplingSeats);

        }
        
        public void Delete()
        {
            СonstructionClassSeat.oExtru().Delete();
            if (couplingSeats1 != 0)
                СonstructionClassSeat.oFill().Delete();
        }
    }
}
