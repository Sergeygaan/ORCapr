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
        private FilletFeature oFillet = default(FilletFeature);
        private EdgeCollection oEdges = null;

        public Progam(Inventor.Application ThisApplication, PartDocument oPartDoc, PartComponentDefinition oCompDef)
        {
            this.ThisApplication = ThisApplication;
            this.oPartDoc = oPartDoc;
            this.oCompDef = oCompDef;
        }

        public void AddProgam()
        {
            // построение модели
            oSketch = oCompDef.Sketches.Add(oCompDef.WorkPlanes[3]);

            oSketch.SketchLines.AddAsTwoPointRectangle
                (ThisApplication.TransientGeometry.CreatePoint2d(2, 2),
                ThisApplication.TransientGeometry.CreatePoint2d(2, 2));
     
            oProfile = oSketch.Profiles.AddForSolid();

            oExtrudeDef = oCompDef.Features.ExtrudeFeatures.
               CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
            oExtrudeDef.SetDistanceExtent
                    (5, PartFeatureExtentDirectionEnum.kSymmetricExtentDirection);
            oExtrude = oCompDef.Features.ExtrudeFeatures.Add(oExtrudeDef);

            // Фаска
            oFillet = oCompDef.Features.FilletFeatures.AddSimple
                        (oEdges, 0.1, false, true, true, false, true, false);
        }

    }
}
