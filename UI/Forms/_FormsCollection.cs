using DiscoveryLight.UI.Forms.Main;
using DiscoveryLight.UI.Forms.SplachScreen;

namespace DiscoveryLight.UI.Forms
{
    static class FormsCollection
    {
        static private _Main _main;
        static private _SplachScreen _splachScreen;

        static public _Main Main { get => _main; set => _main = value; }
        static public _SplachScreen SplachScreen { get => _splachScreen; set => _splachScreen = value; }
    }
}
