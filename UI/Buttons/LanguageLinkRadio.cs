using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Buttons
{
    class LanguageLinkRadio: RadioButton
    {
        private String radioFor;
        private String language;

        public string RadioFor { get => radioFor; set => radioFor = value; }
        public string Language { get => language; set => language = value; }
    }
}
