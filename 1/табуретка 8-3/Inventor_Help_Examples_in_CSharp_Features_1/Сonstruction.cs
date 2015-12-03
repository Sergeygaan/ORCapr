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
        private Profile oProfile = default(Profile);
        private ExtrudeDefinition oExtrudeDef = default(ExtrudeDefinition);
        private ExtrudeFeature oExtrude = default(ExtrudeFeature);
        private FilletFeature oFillet = default(FilletFeature);
        private EdgeCollection oEdges = null;

        public void Const(PartComponentDefinition oCompDef, PlanarSketch oSketch, double thicknessSeats, double couplingSeats)
        {
            oProfile = oSketch.Profiles.AddForSolid();

            oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
                CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);

            oExtrudeDef.SetDistanceExtent
                (thicknessSeats, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

            oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);

            if (couplingSeats != 0)
                oFillet = oCompDef.Features.FilletFeatures.AddSimple
                    (oEdges, couplingSeats, false, true, true, false, true, false);
        }

        public ExtrudeFeature oExtru()
        {
            return oExtrude;
        }

        public FilletFeature oFill()
        {
            return oFillet;
        }

    }
}
