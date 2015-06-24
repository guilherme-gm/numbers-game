using System.Collections;

public enum Products {
	Prod1 = 1,
	Prod2 = 2,
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