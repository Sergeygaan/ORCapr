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
        private PartDocument oPartDoc = default(PartDocument);
        private PartComponentDefinition oCompDef = default(PartComponentDefinition);
        private Inventor.Application ThisApplication;

        private PlanarSketch oSketch = default(PlanarSketch);
        private Profile oProfile = default(Profile);
        private ExtrudeDefinition oExtrudeDef = default(ExtrudeDefinition);
        private EdgeCollection oEdges = null;
        private FilletFeature oFillet = default(FilletFeature);
        private ExtrudeFeature oExtrude = default(ExtrudeFeature);

        public leg(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;

            //TransientGeometry oTG = default(TransientGeometry);
            //oTG = ThisApplication.TransientGeometry;
            //oWPs[0] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(0, 0, 0));
            //oWPs[1] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(0, 0, -5));
        }


        public void AddLeg(double overhang, double lengthLeg, double thicknessLeg, double couplingLeg)
        {
                oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);

                for (int i = 0; i <= 1; i++)
                    for (int j = 0; j <= 1; j++)
                    {
                        oSketch.SketchLines.AddAsTwoPointRectangle
                            (ThisApplication.TransientGeometry.CreatePoint2d(System.Math.Pow(-1, i) * overhang, System.Math.Pow(-1, j) * overhang),
                             ThisApplication.TransientGeometry.CreatePoint2d(System.Math.Pow(-1, i) * overhang - System.Math.Pow(-1, i) * thicknessLeg, System.Math.Pow(-1, j) * overhang - System.Math.Pow(-1, j) * thicknessLeg));
                    }

                oProfile = oSketch.Profiles.AddForSolid();

                oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
                    CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
                oExtrudeDef.SetDistanceExtent
                        (lengthLeg, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);
 
                oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);

                oFillet = oCompDef.Features.FilletFeatures.AddSimple
                            (oEdges, couplingLeg, false, true, true, false, true, false);
            
        }

        public void Delete()
        {
            oExtrude.Delete();
            oFillet.Delete();
        }
    }
}