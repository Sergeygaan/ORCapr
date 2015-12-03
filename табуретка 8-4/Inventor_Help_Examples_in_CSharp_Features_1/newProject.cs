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

        private Seat seatClass;
        private leg legClass;
        private Progam progClass;
        private Progam sideBarClass;

        private bool _Init; 
        public newProject(Inventor.Application _ThisApplication)
        {
            this._ThisApplication = _ThisApplication;
            _Init = false;
        }
        public void calculation()
        {
            _oPartDoc1 = (PartDocument)_ThisApplication.Documents.Add(DocumentTypeEnum.kPartDocumentObject,
            _ThisApplication.FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject));

            _oCompDef1 = _oPartDoc1.ComponentDefinition;

            seatClass = new Seat();
            legClass = new leg();
            progClass = new Progam();
            sideBarClass = new Progam();

        }

        public void DataProgram(Data DataClass)
        {
            if (_Init != false)
            {
                progClass.Delete();
                sideBarClass.Delete();
                legClass.Delete();
                seatClass.Delete();
            }

            seatClass.AddSeat(DataClass);
            legClass.AddLeg(DataClass);
            progClass.AddProgam(DataClass);

            DataClass.distanceProgamForm(DataClass.distanceSideBarForm(-1));
            DataClass.thicknessProgamForm(DataClass.thicknessSideBarForm(-1));
            sideBarClass.AddProgam(DataClass);

            _Init = true;
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
