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
        private PlanarSketch _Sketch = default(PlanarSketch);
        private double _couplingSeats;

        Сonstruction СonstructionClassSeat = new Сonstruction();

        public void AddSeat(Data DataClass, OptionsInventor OptionsInventorClass)
        {
            // построение модели 
            this._couplingSeats = DataClass.couplingSeatsForm(-1);
            _Sketch = OptionsInventorClass.oCompDefForm().Sketches.Add(OptionsInventorClass.oCompDefForm().WorkPlanes[3]);

            _Sketch.SketchLines.AddAsTwoPointRectangle
                (OptionsInventorClass.ThisApplicationForm().TransientGeometry.CreatePoint2d(-DataClass.widthSeatForm(-1), -DataClass.widthSeatForm(-1)),
                OptionsInventorClass.ThisApplicationForm().TransientGeometry.CreatePoint2d(DataClass.widthSeatForm(-1), DataClass.widthSeatForm(-1)));

            СonstructionClassSeat.Const(OptionsInventorClass.oCompDefForm(), _Sketch, DataClass.thicknessSeatsForm(-1), _couplingSeats);

        }
        
        public void Delete()
        {
            СonstructionClassSeat.oExtru().Delete();
            if (_couplingSeats != 0)
                СonstructionClassSeat.oFill().Delete();
        }
    }
}
