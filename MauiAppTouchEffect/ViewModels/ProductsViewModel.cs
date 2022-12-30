﻿using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;

namespace MauiAppTouchEffect.ViewModels;

public class ProductsViewModel
{
    public ObservableCollection<Product> Products { get; } = new();

    public ProductsViewModel()
    {
        Products = Enumerable
            .Range(1, 3)
            .Select(x => new Product
            {
                Id = x,
                Description = $"Product {x}"
            })
            .ToObservableCollection();
    }
}