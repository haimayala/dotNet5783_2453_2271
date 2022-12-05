
namespace BO;
public class BlUnCorrectID : Exception
{
	public BlUnCorrectID(string?message) : base(message) { }
}

public class BlNotEnoughInStock :Exception
{
	public BlNotEnoughInStock(string? massage) : base(massage) { }
}

public class BlNotExsist : Exception
{
    public BlNotExsist(string? massage) : base(massage) { }
}

