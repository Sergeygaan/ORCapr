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
    class OptionsInventor
    {
        private PartComponentDefinition _CompDef = default(PartComponentDefinition);
        private Inventor.Application _ThisApplication;

        public OptionsInventor(Inventor.Application _ThisApplication,  PartComponentDefinition _CompDef)
         {
            this._ThisApplication = _ThisApplication;
            this._CompDef = _CompDef;
         }

        public PartComponentDefinition oCompDefForm()
        {
            return _CompDef;
        }

        public Inventor.Application ThisApplicationForm()
        {
            return _ThisApplication;
        }
    }
}
