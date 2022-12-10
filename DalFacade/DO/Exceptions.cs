

namespace DO;

public class DalDoesNotExsistExeption : Exception
{
	public DalDoesNotExsistExeption(string? msg): base(msg) { }
	
}

public class DalAllredyExsisExeption : Exception
{
    public DalAllredyExsisExeption(string? msg) : base(msg) { }

}

