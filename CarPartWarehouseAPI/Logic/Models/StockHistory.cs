// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Logic.Models;

public class StockHistory
{
    public int ID { get; set; }
    public DateTime StockChangeDate { get; set; }
    public int StockWas {  get; set; }
    public int StockNow {  get; set; }

    public virtual Product Product { get; set; }
}