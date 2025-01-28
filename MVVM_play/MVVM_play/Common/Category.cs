using Microsoft.UI.Xaml.Controls;

namespace MVVM_play.Common
{

    public class CategoryBase { }

    public class Category : CategoryBase
    {
        public string Name { get; set; } = null!;
        public string Tooltip { get; set; } = null!;
        public Symbol Glyph { get; set; }
        public string Tag { get; set; } = null!;
    }

    public class Separator : CategoryBase { }

    public class Header : CategoryBase
    {
        public string? Name { get; set; }
    }
}
