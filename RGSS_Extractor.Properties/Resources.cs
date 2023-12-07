using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace RGSS_Extractor.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode,
 CompilerGenerated]
internal class Resources
{
    private static ResourceManager _resourceMan;
    private static CultureInfo _resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager => _resourceMan ??=
        new ResourceManager("RGSS_Extractor.Properties.Resources", typeof(Resources).Assembly);

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
        get => _resourceCulture;
        set => _resourceCulture = value;
    }

    internal Resources()
    {
    }
}