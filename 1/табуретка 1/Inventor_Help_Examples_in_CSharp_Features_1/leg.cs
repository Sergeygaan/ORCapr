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

        PlanarSketch oSketch = default(PlanarSketch);
        Profile oProfile = default(Profile);
        ExtrudeDefinition oExtrudeDef = default(ExtrudeDefinition);
        EdgeCollection oEdges = null;
        FilletFeature oFillet = default(FilletFeature);
        ExtrudeFeature oExtrude = default(ExtrudeFeature);

        public leg(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }


        public void AddLeg()
        {
                oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);

                oSketch.SketchLines.AddAsTwoPointRectangle
                    (ThisApplication.TransientGeometry.CreatePoint2d(-4, -4),
                    ThisApplication.TransientGeometry.CreatePoint2d(-3, -3));
                
                oProfile = oSketch.Profiles.AddForSolid();

                oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
                    CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
                oExtrudeDef.SetDistanceExtent
                        (10, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);
 
                oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);

                oFillet = oCompDef.Features.FilletFeatures.AddSimple
                            (oEdges, 0.1, false, true, true, false, true, false);


        }

        public void Delete()
        {
            oExtrude.Delete();
            oFillet.Delete();
        }
    }
}