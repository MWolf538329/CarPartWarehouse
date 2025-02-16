﻿// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Logic.Models;

public class Product
{
    public int ID { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int CurrentStock { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }

    public virtual Subcategory? Subcategory { get; set; }
    //public virtual List<ProductLink> Links { get; set; } = [];
}