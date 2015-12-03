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
    class Progam
    {
        private PlanarSketch _Sketch = default(PlanarSketch);

        WorkPlane _WP = default(WorkPlane);
        WorkPoint[] _WPs = new WorkPoint[3];

        Сonstruction СonstructionClassProd = new Сonstruction();

        public void AddProgam(Data DataClass, OptionsInventor OptionsInventorClass)
        {
            TransientGeometry _TG = default(TransientGeometry);
            _TG = OptionsInventorClass.ThisApplicationForm().TransientGeometry;

            _WPs[0] = OptionsInventorClass.oCompDefForm().WorkPoints.AddFixed(_TG.CreatePoint(0, 0, -DataClass.distanceProgamForm(-1)));
            _WPs[1] = OptionsInventorClass.oCompDefForm().WorkPoints.AddFixed(_TG.CreatePoint(0, 4, -DataClass.distanceProgamForm(-1)));
            _WPs[2] = OptionsInventorClass.oCompDefForm().WorkPoints.AddFixed(_TG.CreatePoint(4, 0, -DataClass.distanceProgamForm(-1)));

            for (int i = 0; i < _WPs.LongLength; i++)
                _WPs[i].Visible = false;

            _WP = OptionsInventorClass.oCompDefForm().WorkPlanes.AddByThreePoints(_WPs[0], _WPs[1], _WPs[2]);

            _WP.Visible = false;

            _Sketch = OptionsInventorClass.oCompDefForm().Sketches.Add(_WP);

            double[,] array =
            {
            {(DataClass.overhangForm(-1) - DataClass.thicknessLegForm(-1)), (DataClass.overhangForm(-1) - DataClass.thicknessLegForm(-1)) + 0.2 * DataClass.thicknessLegForm(-1), (-DataClass.overhangForm(-1) + DataClass.thicknessLegForm(-1)), (DataClass.overhangForm(-1)) - 0.2 * DataClass.thicknessLegForm(-1)},
            {(-DataClass.overhangForm(-1) + DataClass.thicknessLegForm(-1)) - 0.2 * DataClass.thicknessLegForm(-1), (DataClass.overhangForm(-1) - DataClass.thicknessLegForm(-1)), (-DataClass.overhangForm(-1)) + 0.2 * DataClass.thicknessLegForm(-1), (-DataClass.overhangForm(-1) + DataClass.thicknessLegForm(-1))},
            {-DataClass.overhangForm(-1) + DataClass.thicknessLegForm(-1), (-DataClass.overhangForm(-1) + DataClass.thicknessLegForm(-1)) - 0.2 * DataClass.thicknessLegForm(-1), DataClass.overhangForm(-1) - DataClass.thicknessLegForm(-1), (-DataClass.overhangForm(-1)) + 0.2 * DataClass.thicknessLegForm(-1)},
            {(DataClass.overhangForm(-1) - DataClass.thicknessLegForm(-1)) + 0.2 * DataClass.thicknessLegForm(-1), (-DataClass.overhangForm(-1) + DataClass.thicknessLegForm(-1)), DataClass.overhangForm(-1) - 0.2 * DataClass.thicknessLegForm(-1), (DataClass.overhangForm(-1) - DataClass.thicknessLegForm(-1)) },
            };

            for (int i = 0; i < 4; i++)
            {
                _Sketch.SketchLines.AddAsTwoPointRectangle
                (OptionsInventorClass.ThisApplicationForm().TransientGeometry.CreatePoint2d(array[i, 0], array[i, 1]),
                OptionsInventorClass.ThisApplicationForm().TransientGeometry.CreatePoint2d(array[i, 2], array[i, 3]));
            }

            СonstructionClassProd.Const(OptionsInventorClass.oCompDefForm(), _Sketch, DataClass.thicknessProgamForm(-1), 0);
        }

        public void Delete()
        {
            СonstructionClassProd.oExtru().Delete();
            _WP.Delete();
            for (int i = 0; i < _WPs.LongLength; i++)
                _WPs[i].Delete();
        }

    }
}
