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
        try
        {
            var item = GetNavigationViewItems().FirstOrDefault();
            if (item != null)
            {
                SetCurrentNavigationViewItem(item, (NavigationView)sender);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in NavigationView_Loaded: {ex.Message}");
        }
    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            ContentFrame.Navigate(typeof(SettingsPage));
            sender.Header = "Settings"; // Update the header
        }
        else
        {
            if (args.SelectedItem is MenuItem category)
            {
                if (!string.IsNullOrEmpty(category.Tag))
                {
                    Type? pageType = Type.GetType(category.Tag);
                    if (pageType != null)
                    {
                        ContentFrame.Navigate(pageType);    // Pages must have a parameterless constructor for Navigate() to work.
                                                            // Without it, the XAML system couldn't instantiate DataGridMergedDataPage,
                                                            // leading to the null reference issue

                        sender.Header = category.Name;      // Update the header
                    }
                    else
                    {
                        Debug.WriteLine($"Page not found for Tag: {category.Tag}");
                    }
                }
            }
        }
    }


    public List<NavigationViewItem> GetNavigationViewItems()
    {
        List<NavigationViewItem> result = [];

        // If using MenuItemsSource (dynamic items)
        if (MainNavigationView.MenuItemsSource is IEnumerable<MenuItemBase> categories)
        {
            foreach (var category in categories)
            {
                if (category is MenuItem dynamicCategory)
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

    public void SetCurrentNavigationViewItem(NavigationViewItem item, NavigationView sender)
    {
        if (item?.Tag is string tag && !string.IsNullOrEmpty(tag))
        {
            Type? pageType = Type.GetType(tag);

            if (pageType != null)
            {
                ContentFrame.Navigate(pageType);
                sender.Header = item.Content;
            }
            else
            {
                // Log or handle the case where the Tag does not resolve to a valid Type
                Debug.WriteLine($"Failed to resolve page type from Tag: {tag}");
            }
        }
        else
        {
            // Handle the case where there are no items or no valid Tag
            Debug.WriteLine("No NavigationViewItem found or Tag is null.");
        }

    }

    public NavigationViewItem GetCurrentNavigationViewItem()
    {
        //return MainNavigationView.SelectedItem as NavigationViewItem;
        var selectedItem = MainNavigationView.SelectedItem as NavigationViewItem;

        return selectedItem ?? throw new InvalidOperationException("No NavigationViewItem is currently selected.");
    }
}
