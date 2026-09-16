using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using Silox.UI.ViewModels;

namespace Silox.UI;

public class ViewLocator(IServiceProvider serviceProvider) : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null) return null;

        var viewName = param.GetType().Name.Replace("ViewModel", "View", StringComparison.Ordinal);

        var viewTypeName = $"Silox.UI.Views.{viewName.Replace("View", "")}.{viewName}";

        Console.WriteLine($"Looking for: {viewTypeName}");

        var viewType = Type.GetType(viewTypeName);

        Console.WriteLine($"Found type: {viewType}");

        if (viewType is null)
        {
            return new TextBlock
            {
                Text = $"Not Found: {viewTypeName}"
            };
        }

        return (Control)serviceProvider.GetRequiredService(viewType);
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}