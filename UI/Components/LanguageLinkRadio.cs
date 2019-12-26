using System;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Components

{
    /// <summary>
    /// Extend base radio button with new custom fields
    /// </summary>
    class LanguageLinkRadio : RadioButton
    {
        private String radioFor;    // string to indefy the purpose for this radio language button
        private String language;    // to identify the language linked a this radio button

        public string RadioFor { get => radioFor; set => radioFor = value; }
        public string Language { get => language; set => language = value; }
    }
}
