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
    class Сonstruction
    {
        private Profile _Profile = default(Profile);
        private ExtrudeDefinition _ExtrudeDef = default(ExtrudeDefinition);
        private ExtrudeFeature _Extrude = default(ExtrudeFeature);
        private FilletFeature _Fillet = default(FilletFeature);
        private EdgeCollection _Edges = null;

        public void Const(PartComponentDefinition _CompDef, PlanarSketch _Sketch, double _thicknessSeats, double _couplingSeats)
        {
            _Profile = _Sketch.Profiles.AddForSolid();

            _ExtrudeDef = _CompDef.Features.ExtrudeFeatures.
                CreateExtrudeDefinition(_Profile, PartFeatureOperationEnum.kJoinOperation);

            _ExtrudeDef.SetDistanceExtent
                (_thicknessSeats, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

            _Extrude = _CompDef.Features.ExtrudeFeatures.Add(_ExtrudeDef);

            if (_couplingSeats != 0)
                _Fillet = _CompDef.Features.FilletFeatures.AddSimple
                    (_Edges, _couplingSeats, false, true, true, false, true, false);
        }

        public ExtrudeFeature oExtru()
        {
            return _Extrude;
        }

        public FilletFeature oFill()
        {
            return _Fillet;
        }

    }
}
