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
    class newProject
    {
        PartDocument oPartDoc1 = default(PartDocument);
        PartComponentDefinition oCompDef1 = default(PartComponentDefinition);
        Inventor.Application ThisApplication;

        public newProject(Inventor.Application ThisApplication)
        {
            this.ThisApplication = ThisApplication;

        }
        public void calculation()
        {
            oPartDoc1 = (PartDocument)ThisApplication.Documents.Add(DocumentTypeEnum.kPartDocumentObject,
            ThisApplication.FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject));

            oCompDef1 = oPartDoc1.ComponentDefinition;
        }

        public PartDocument oPartDoc()
        {
            return oPartDoc1;
        }

        public PartComponentDefinition oCompDef()
        {
            return oCompDef1;
        }
    }
}
