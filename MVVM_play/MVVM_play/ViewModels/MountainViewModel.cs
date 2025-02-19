﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_play.Models;
using System.Collections.ObjectModel;

namespace MVVM_play.ViewModels;

public partial class MountainViewModel : ObservableObject
{

    private ObservableCollection<Mountain> _mountains = null!;
    public ObservableCollection<Mountain> Mountains
    {
        get => _mountains;
        set => SetProperty(ref _mountains, value);
    }

    public MountainViewModel()
    {
        Mountains = new ObservableCollection<Mountain>
        {
            new() { Id = 1, Name = "Mount Everest", Height = 8848 },
            new() { Id = 2, Name = "K2", Height = 8611 }
        };
    }

    [RelayCommand]
    public void AddMountain()
    {
        Mountains.Add(new Mountain { Id = Mountains.Count + 1, Name = "New Mountain", Height = 5000 });
    }

}
