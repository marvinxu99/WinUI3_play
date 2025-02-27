﻿using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace MVVM_play.Services;

public interface INavigation
{
    NavigationViewItem GetCurrentNavigationViewItem();

    List<NavigationViewItem> GetNavigationViewItems();

    List<NavigationViewItem> GetNavigationViewItems(Type type);

    List<NavigationViewItem> GetNavigationViewItems(Type type, string title);

    void SetCurrentNavigationViewItem(NavigationViewItem item, NavigationView sender);
}
