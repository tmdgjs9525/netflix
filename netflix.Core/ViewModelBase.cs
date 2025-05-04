using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using netflix.AppAbstractions;
using netflix.Core.Models;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using System.Windows;
using System.Runtime.CompilerServices;

namespace netflix.Core
{
    public partial class ViewModelBase : ObservableObject, IViewModelBase
    {

        public ViewModelBase()
        {

        }
    }
}
