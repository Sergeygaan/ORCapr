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
            PartDocument oPartDoc = default(PartDocument);
            oPartDoc = (PartDocument)ThisApplication.ActiveDocument;

            // Set a reference to the component definition.
            PartComponentDefinition oCompDef = default(PartComponentDefinition);
            oCompDef = oPartDoc.ComponentDefinition;

            // Set a reference to the transient geometry object.
            TransientGeometry oTG = default(TransientGeometry);
            oTG = ThisApplication.TransientGeometry;
            WorkPoint[] oWPs = new WorkPoint[5];
            // построение модели
            oWPs[2] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(0, 0, -3));
            oWPs[3] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(0, 4, -3));
            oWPs[4] = oCompDef.WorkPoints.AddFixed(oTG.CreatePoint(4, 0, -3));

            // Create a work plane at the end of the 2D sketch.
            WorkPlane oWP = default(WorkPlane);
            oWP = oCompDef.WorkPlanes.AddByThreePoints(oWPs[2], oWPs[3], oWPs[4]);

            oSketch = oCompDef.Sketches.Add(oWP);

            oSketch.SketchLines.AddAsTwoPointRectangle
               (ThisApplication.TransientGeometry.CreatePoint2d(-6, -6),
               ThisApplication.TransientGeometry.CreatePoint2d(6, 6));
        }

    }
}
