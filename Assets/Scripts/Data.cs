using System.Collections;

public enum Products {
	Prod1 = 1,
	Prod2 = 2,
	Prod3,
	Prod4,
	Prod5,
	Prod6,
	Prod7,
	Prod8,
	Prod9,
	Prod10 = 10
}

public abstract class Product
{
	public int Level { get; private set; }

	public BigInteger NextLevelPrice { get; private set; }
	public BigInteger Income { get; private set; }

	public Product(int level = 0)
	{
		this.Level = level;
		this.UpdateIncome ();
		this.UpdateLevelPrice ();
	}

	public void Upgrade()
	{
		this.Level++;
		this.UpdateIncome ();
		this.UpdateLevelPrice ();
	}

	public abstract void UpdateIncome ();
	public abstract void UpdateLevelPrice ();

	public void UpdateIncome(BigInteger val) {
		this.Income = val;
	}

	public void UpdateLevelPrice(BigInteger val) {
		this.NextLevelPrice = val;
	}
}

public class Prod1 : Product
{
	public Prod1 (int level) : base(level){}

	public override void UpdateIncome ()
	{
		base.UpdateIncome (10 * base.Level);
	}

	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (10 + 20 * base.Level);
	}

}

public class Prod2 : Product
{
	public Prod2 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod3 : Product
{
	public Prod3 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod4 : Product
{
	public Prod4 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod5 : Product
{
	public Prod5 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod6 : Product
{
	public Prod6 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod7 : Product
{
	public Prod7 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod8 : Product
{
	public Prod8 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod9 : Product
{
	public Prod9 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}

public class Prod10 : Product
{
	public Prod10 (int level) : base(level){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
}