
namespace BO;
public class BlUnCorrectIDExeption : Exception
{
	public BlUnCorrectIDExeption(string?message) : base(message) { }
}

public class BlNotEnoughInStockExeption : Exception
{
	public BlNotEnoughInStockExeption(string? massage) : base(massage) { }
}

public class BlNotExsistExeption : Exception
{
    public BlNotExsistExeption(string? massage) : base(massage) { }
}

public class BlUncorrectDetailsExeption : Exception
{
	public BlUncorrectDetailsExeption(string? massage) : base(massage) { }
	
}

public class BlUncorrectEmailExeption : Exception
{
    public BlUncorrectEmailExeption(string? massage) : base(massage) { }

}

public class BlUncorrectName : Exception
{
    public BlUncorrectName(string? massage) : base(massage) { }

}
public class BlUncorrectAddres : Exception
{
    public BlUncorrectAddres(string? massage) : base(massage) { }

}
public class BlUncorrectPrice : Exception
{
    public BlUncorrectPrice(string? massage) : base(massage) { }

}

public class BlOrderAlredyShiped : Exception
{
    public BlOrderAlredyShiped(string? massage) : base(massage) { }

}

public class BlOrderAlredyDelivered : Exception
{
    public BlOrderAlredyDelivered(string? massage) : base(massage) { }

}
