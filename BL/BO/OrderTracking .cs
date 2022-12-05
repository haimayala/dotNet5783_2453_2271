namespace BO;
using static BO.Enums;

public class OrderTracking
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public List <Tuple<DateTime, string>>? Trecking{ get; set; }

    //public override string ToString() => $@"
    //ID:  {Id}
    //Status:   {Status} 
    //Trecking:{Trecking}";
    public override string ToString()
    {
        return this.ToStringProperty();
    }




}
