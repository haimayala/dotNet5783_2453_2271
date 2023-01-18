using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;


namespace DO;

public struct User
{
    public string userName { get; set; }
    public int password { get; set; }
    public Status Status { get; set; }
    public override string ToString() => this.ToStringProperty();
}

