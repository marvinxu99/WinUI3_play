using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Common;
using MVVM_play.Services;
using MVVM_play.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MVVM_play;

public sealed partial class MainWindow : Window, INavigation
{
    private void NavigationView_Loaded(object sender, RoutedEventArgs e)
    {
        var item = GetNavigationViewItems().FirstOrDefault();

        if (item != null && item.Tag != null)
        {
            Type? pageType = Type.GetType(item.Tag.ToString());

            if (pageType != null)
            {
                ContentFrame.Navigate(pageType);
                ((NavigationView)sender).Header = item.Content;
            }
            else
            {
                // Log or handle the case where the Tag does not resolve to a valid Type
                Debug.WriteLine($"Failed to resolve page type from Tag: {item.Tag}");
            }
        }
        else
        {
            // Handle the case where there are no items or no valid Tag
            Debug.WriteLine("No NavigationViewItem found or Tag is null.");
        }
    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            ContentFrame.Navigate(typeof(MountainPage));   //TODO:
        }
        else
        {
            var selectedItem = (Category)args.SelectedItem;
            Type? pageType = Type.GetType(selectedItem.Tag.ToString());
            if (pageType != null)
            {
                ContentFrame.Navigate(pageType);
                sender.Header = selectedItem.Name; // Update the header
            }
            else
            {
                Debug.WriteLine($"Page not found: {selectedItem.Tag}");
            }
        }
    }


    public List<NavigationViewItem> GetNavigationViewItems()
    {
        List<NavigationViewItem> result = new();

        // If using MenuItemsSource (dynamic items)
        if (MainNavigationView.MenuItemsSource is IEnumerable<CategoryBase> categories)
        {
            foreach (var category in categories)
            {
                if (category is Category dynamicCategory)
                {
                    // Create a NavigationViewItem manually
                    var navigationItem = new NavigationViewItem
                    {
                        Content = dynamicCategory.Name,
                        Tag = dynamicCategory.Tag,
                        Icon = new SymbolIcon(dynamicCategory.Glyph)
                    };
                    result.Add(navigationItem);
                }
            }
        }
        else
        {
            var items = MainNavigationView.MenuItems.Select(i => (NavigationViewItem)i).ToList();
            //items.AddRange(MainNavigationView.FooterMenuItems.Select(i => (NavigationViewItem)i));
            result.AddRange(items);

            //foreach (NavigationViewItem mainItem in items)
            //{
            //    result.AddRange(mainItem.MenuItems.Select(i => (NavigationViewItem)i));
            //}

        }

        // Add FooterMenuItems if defined statically
        if (MainNavigationView.FooterMenuItems != null)
        {
            result.AddRange(MainNavigationView.FooterMenuItems.OfType<NavigationViewItem>());
        }


        return result;
    }

    public List<NavigationViewItem> GetNavigationViewItems(Type type)
    {
        return GetNavigationViewItems().Where(i => i.Tag.ToString() == type.FullName).ToList();
    }

    public List<NavigationViewItem> GetNavigationViewItems(Type type, string title)
    {
        return GetNavigationViewItems(type).Where(ni => ni.Content.ToString() == title).ToList();
    }

    public void SetCurrentNavigationViewItem(NavigationViewItem item)
    {
        if (item == null)
        {
            return;
        }

        if (item.Tag == null)
        {
            return;
        }

        ContentFrame.Navigate(Type.GetType(item.Tag.ToString()), item.Content);
        MainNavigationView.Header = item.Content;
        MainNavigationView.SelectedItem = item;
    }

    public NavigationViewItem GetCurrentNavigationViewItem()
    {
        return MainNavigationView.SelectedItem as NavigationViewItem;
    }
}
