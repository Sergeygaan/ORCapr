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
        private PlanarSketch _Sketch = default(PlanarSketch);
        private double _couplingLeg;

        Сonstruction СonstructionClassLeg = new Сonstruction();


        public void AddLeg(Data DataClass)
        {
            this._couplingLeg = DataClass.couplingLegForm(-1);
            _Sketch = DataClass.oCompDefForm().Sketches.Add(DataClass.oCompDefForm().WorkPlanes[3]);
            
            for (int i = 0; i <= 1; i++)
                for (int j = 0; j <= 1; j++)
                {
                    _Sketch.SketchLines.AddAsTwoPointRectangle
                        (DataClass.ThisApplicationForm().TransientGeometry.CreatePoint2d(System.Math.Pow(-1, i) * DataClass.overhangForm(-1), System.Math.Pow(-1, j) * DataClass.overhangForm(-1)),
                        DataClass.ThisApplicationForm().TransientGeometry.CreatePoint2d(System.Math.Pow(-1, i) * DataClass.overhangForm(-1) - System.Math.Pow(-1, i) * DataClass.thicknessLegForm(-1), System.Math.Pow(-1, j) * DataClass.overhangForm(-1) - System.Math.Pow(-1, j) * DataClass.thicknessLegForm(-1)));
                }
            СonstructionClassLeg.Const(DataClass.oCompDefForm(), _Sketch, DataClass.lengthLegForm(-1), _couplingLeg);
         }

        public void Delete()
        {
            СonstructionClassLeg.oExtru().Delete();
            if (_couplingLeg != 0)
                СonstructionClassLeg.oFill().Delete();
        }
    }
}