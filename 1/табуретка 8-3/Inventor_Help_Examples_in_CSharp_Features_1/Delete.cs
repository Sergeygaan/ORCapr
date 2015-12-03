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
    class Delete
    {
        Inventor.Application ThisApplication1;

        public Delete(Inventor.Application ThisApplication)
        {
            this.ThisApplication1 = ThisApplication;
        }

        public void copiSeat()
        {


                //ThisApplication1.SilentOperation = true;

                //Document oDoc = default(Document);

                //oDoc = ThisApplication1.ActiveDocument;

                //bool bSaveDoc = false;
                //bSaveDoc = false;

                //ReferencedOLEFileDescriptor oRefOleFileDesc = default(ReferencedOLEFileDescriptor);


                //if (oDoc.ReferencedOLEFileDescriptors.Count > 0) {
                //foreach(oRefOleFileDesc in oDoc.ReferencedOLEFileDescriptors) {
                ////Debug.Print oRefOleFileDesc.ReferenceStatus

                //if (oRefOleFileDesc.ReferenceStatus == ReferenceStatusEnum.kMissingReference) {
                //// Debug.Print oRefOleFileDesc.DisplayName 
                //oRefOleFileDesc.Delete();
                //oDoc.Dirty = true;
                //bSaveDoc = true;
                //}
                //}

                //if (bSaveDoc == true) {
                //oDoc.Save();
                //bSaveDoc = false;
                //}
                //}
                //// Be sure to set this back to False 
                //ThisApplication1.SilentOperation = false;
        }
    }
}
