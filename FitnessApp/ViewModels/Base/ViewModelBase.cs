﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FitnessApp.ViewModels.Base;

public class ViewModelBase
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void PropertyChangeMethod<T>(out T field, T value, [CallerMemberName] string propName = "")
    {
        field = value;

        if (this.PropertyChanged != null)
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
