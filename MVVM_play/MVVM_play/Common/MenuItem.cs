using Microsoft.UI.Xaml.Controls;

namespace MVVM_play.Common
{

    public class MenuItemBase { }

    public class MenuItem : MenuItemBase
    {
        public string Name { get; set; } = null!;
        public string Tooltip { get; set; } = null!;
        public Symbol Glyph { get; set; }
        public string Tag { get; set; } = null!;
    }

    public class Separator : MenuItemBase { }

    public class Header : MenuItemBase
    {
        public string? Name { get; set; }
    }
}
