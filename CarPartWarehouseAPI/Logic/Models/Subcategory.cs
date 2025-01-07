// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Logic.Models;

public class Subcategory
{
    public int ID { get; init; }
    public string Name { get; set; } = string.Empty;

    public virtual Category Category { get; init; }

    public virtual List<Product>? Products { get; init; }
}