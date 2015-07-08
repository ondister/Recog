using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Recog
{
    public class ApplicationInfo
    {
        public static string GetDirectory()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }
        
    }
}
