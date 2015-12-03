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

        PartDocument oPartDoc = default(PartDocument);
        PartComponentDefinition oCompDef = default(PartComponentDefinition);
        Inventor.Application ThisApplication;

        PlanarSketch oSketch = default(PlanarSketch);
        Profile oProfile = default(Profile);
        ExtrudeDefinition oExtrudeDef = default(ExtrudeDefinition);
        ExtrudeFeature oExtrude = default(ExtrudeFeature);


        public Seat(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }


        public void AddSeat(double widthSeat)
        {

            oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);

            oSketch.SketchLines.AddAsTwoPointRectangle
                (ThisApplication.TransientGeometry.CreatePoint2d(-widthSeat, -widthSeat),
                ThisApplication.TransientGeometry.CreatePoint2d(widthSeat, widthSeat));

            oProfile = oSketch.Profiles.AddForSolid();

            oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
                CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
            oExtrudeDef.SetDistanceExtent
                    (1, PartFeatureExtentDirectionEnum.kSymmetricExtentDirection);
            oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);


            //EdgeCollection oEdges = null;

            //FilletFeature oFillet = default(FilletFeature);
            //oFillet = oCompDef.Features.FilletFeatures.AddSimple
            //            (oEdges, 0.4, false, true, true, false, true, false);
        }

    }
}
