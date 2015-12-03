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
        private PartDocument _oPartDoc = default(PartDocument);
        private PartComponentDefinition _oCompDef = default(PartComponentDefinition);
        private Inventor.Application _ThisApplication;

        private PlanarSketch _oSketch = default(PlanarSketch);
        private double _couplingSeats1;

        Сonstruction СonstructionClassSeat = new Сonstruction();

        public Seat(Inventor.Application _ThisApplication, PartDocument _oPartDoc, PartComponentDefinition _oCompDef)
        {
            this._ThisApplication = _ThisApplication;
            this._oPartDoc = _oPartDoc;
            this._oCompDef = _oCompDef;
        }

        public void AddSeat(double _widthSeat, double _thicknessSeats, double _couplingSeats)
        {
            // построение модели
            this._couplingSeats1 = _couplingSeats;
            _oSketch = _oCompDef.Sketches.Add(_oCompDef.WorkPlanes[3]);

            _oSketch.SketchLines.AddAsTwoPointRectangle
                (_ThisApplication.TransientGeometry.CreatePoint2d(-_widthSeat, -_widthSeat),
                _ThisApplication.TransientGeometry.CreatePoint2d(_widthSeat, _widthSeat));

            СonstructionClassSeat.Const(_oCompDef, _oSketch, _thicknessSeats, _couplingSeats);

        }
        
        public void Delete()
        {
            СonstructionClassSeat.oExtru().Delete();
            if (_couplingSeats1 != 0)
                СonstructionClassSeat.oFill().Delete();
        }
    }
}
