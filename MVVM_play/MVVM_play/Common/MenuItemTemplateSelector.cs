using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;

namespace MVVM_play.Common
{

    [ContentProperty(Name = "ItemTemplate")]
    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? ItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return GetTemplate(item);
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return GetTemplate(item);
        }

        private DataTemplate GetTemplate(object item)
        {
            //return item is Separator ? SeparatorTemplate : item is Header ? HeaderTemplate : ItemTemplate;
            if (item is Separator)
            {
                return SeparatorTemplate;
            }
            else if (item is Header)
            {
                return HeaderTemplate;
            }
            return ItemTemplate ?? new DataTemplate();
        }

        public DataTemplate HeaderTemplate { get; } = (DataTemplate)XamlReader.Load(@"
            <DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                <NavigationViewItemHeader Content='{Binding Name}' />
            </DataTemplate>");

        public DataTemplate SeparatorTemplate { get; } = (DataTemplate)XamlReader.Load(@"
            <DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                <NavigationViewItemSeparator />
            </DataTemplate>");

    }
}
