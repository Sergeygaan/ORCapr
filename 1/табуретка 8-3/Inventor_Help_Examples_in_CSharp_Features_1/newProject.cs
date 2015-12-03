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
        private PartDocument _oPartDoc1 = default(PartDocument);
        private PartComponentDefinition _oCompDef1 = default(PartComponentDefinition);
        private  Inventor.Application _ThisApplication;

        public newProject(Inventor.Application _ThisApplication)
        {
            this._ThisApplication = _ThisApplication;

        }
        public void calculation()
        {
            _oPartDoc1 = (PartDocument)_ThisApplication.Documents.Add(DocumentTypeEnum.kPartDocumentObject,
            _ThisApplication.FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject));

            _oCompDef1 = _oPartDoc1.ComponentDefinition;
        }

        public PartDocument oPartDoc()
        {
            return _oPartDoc1;
        }

        public PartComponentDefinition oCompDef()
        {
            return _oCompDef1;
        }
    }
}
