using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator;

public class SimNotExsisExeption : Exception
{
    public SimNotExsisExeption(string? msg) : base(msg) { }

}


