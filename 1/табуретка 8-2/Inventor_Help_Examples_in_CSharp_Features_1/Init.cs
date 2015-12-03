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
    class Init
    {
            public Inventor.Application InitInventor()
            {
             Inventor.Application ThisApplication = null;
                   try
                   {
                        ThisApplication = (Inventor.Application)
                        System.Runtime.InteropServices.Marshal.
                        GetActiveObject("Inventor.Application"); 
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Need to start an Inventor session - Exiting");

                    }
                return  ThisApplication;
            }

        }
}

