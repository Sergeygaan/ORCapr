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
        PartDocument oPartDoc = default(PartDocument);
        PartComponentDefinition oCompDef = default(PartComponentDefinition);
        Inventor.Application ThisApplication;

        public leg(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }


        public void AddLeg()
        {
            int[,] array =
                {
                {-4, -4, -3, -3 },
                {-4,  4, -3,  3 },
                {4,   4,  3,  3 },
                {4,  -4,  3, -3 },
                };
            for (int i = 0; i < 4; i++)
            {
                PlanarSketch oSketch = default(PlanarSketch);

                oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);


                oSketch.SketchLines.AddAsTwoPointRectangle
                    (ThisApplication.TransientGeometry.CreatePoint2d(array[i, 0], array[i, 1]),
                    ThisApplication.TransientGeometry.CreatePoint2d(array[i, 2], array[i, 3]));

                Profile oProfile = default(Profile);
                oProfile = oSketch.Profiles.AddForSolid();


                ExtrudeDefinition oExtrudeDef = default(ExtrudeDefinition);
                oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
                    CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
                oExtrudeDef.SetDistanceExtent
                        (10, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);
                ExtrudeFeature oExtrude = default(ExtrudeFeature);
                oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);


                EdgeCollection oEdges = null;


                FilletFeature oFillet = default(FilletFeature);
                oFillet = oCompDef.Features.FilletFeatures.AddSimple
                            (oEdges, 0.1, false, true, true, false, true, false);
            }
        }
    }
}