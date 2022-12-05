

namespace DO;

public class DalDoesNotExsist :Exception
{
	public DalDoesNotExsist(string? msg): base(msg) { }
	
}

public class DalAllredyExsis : Exception
{
    public DalAllredyExsis(string? msg) : base(msg) { }

}

