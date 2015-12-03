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
        private PartDocument oPartDoc = default(PartDocument);
        private PartComponentDefinition oCompDef = default(PartComponentDefinition);
        private Inventor.Application ThisApplication;

        private PlanarSketch oSketch = default(PlanarSketch);
        private Profile oProfile = default(Profile);
        private ExtrudeDefinition oExtrudeDef = default(ExtrudeDefinition);
        private ExtrudeFeature oExtrude = default(ExtrudeFeature);

        WorkPlane oWP = default(WorkPlane);
        WorkPoint[] oWPs = new WorkPoint[3];

        public Progam(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }

        public void AddProgam(double overhang, double thicknessLeg, double distance, double thickness)
        {
            TransientGeometry oTG = default(TransientGeometry);
            oTG = ThisApplication.TransientGeometry;

            oWPs[0] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(0, 0, -distance));
            oWPs[1] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(0, 4, -distance));
            oWPs[2] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(4, 0, -distance));

            for (int i = 0; i < oWPs.LongLength; i++)
                oWPs[i].Visible = false;

            oWP = oCompDef.WorkPlanes.AddByThreePoints(oWPs[0], oWPs[1], oWPs[2]);

            oWP.Visible = false;
            
            oSketch = oCompDef.Sketches.Add(oWP);

            double[,] array =
            {
            {(overhang - thicknessLeg), (overhang - thicknessLeg) + 0.2 * thicknessLeg, (-overhang + thicknessLeg), (overhang) - 0.2 * thicknessLeg},
            {(-overhang + thicknessLeg) - 0.2 * thicknessLeg, (overhang - thicknessLeg), (-overhang) + 0.2 * thicknessLeg, (-overhang + thicknessLeg)},
            {-overhang + thicknessLeg, (-overhang + thicknessLeg) - 0.2 * thicknessLeg, overhang - thicknessLeg, (-overhang) + 0.2 * thicknessLeg},
            {(overhang - thicknessLeg) + 0.2 * thicknessLeg, (-overhang + thicknessLeg), overhang - 0.2 * thicknessLeg, (overhang - thicknessLeg) },
            };

            for (int i = 0; i < 4; i++)
            {
            oSketch.SketchLines.AddAsTwoPointRectangle
                (ThisApplication.TransientGeometry.CreatePoint2d(array[i, 0], array[i, 1]),
                ThisApplication.TransientGeometry.CreatePoint2d(array[i, 2], array[i, 3]));
            }

            oProfile = oSketch.Profiles.AddForSolid();

            oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
                CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
            oExtrudeDef.SetDistanceExtent
                (thickness, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

            oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);

            
        }

        public void Delete()
        {
            oExtrude.Delete();
            oWP.Delete();
            for (int i = 0; i < oWPs.LongLength; i++) 
                oWPs[i].Delete();
        }

    }
}
