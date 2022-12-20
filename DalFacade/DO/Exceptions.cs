

namespace DO;

public class DalDoesNotExsistExeption : Exception
{
	public DalDoesNotExsistExeption(string? msg): base(msg) { }
	
}

public class DalAllredyExsisExeption : Exception
{
    public DalAllredyExsisExeption(string? msg) : base(msg) { }

}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}


