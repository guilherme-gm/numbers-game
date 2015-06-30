using System.Collections;
using UnityEngine;

public enum Products {
	Prod1 = 1,
	Prod2,
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
	public int Multiplier { get; private set; }

	public string Name { get; private set; }

	public BigInteger NextLevelPrice { get; private set; }
	public BigInteger Income { get; private set; }

	public float CycleTime { get; private set; }
	public float CurrentCycle { get; private set; }
	public float CycleReduceFactor { get; private set; }

	public Product(int level = 0, string name = "Prod")
	{
		// Dummy Values
		this.CycleTime = 1f;
		this.CurrentCycle = 1f;
		this.Multiplier = 1;
		this.CycleReduceFactor = 1f;

		// Initialize object data
		this.Name = name;
		this.Level = level;
		this.Update ();
	}

	public void Upgrade()
	{
		this.Level++;
		this.Update ();
	}

	public void Update()
	{
		this.UpdateIncome ();
		this.UpdateLevelPrice ();
		this.UpdateCycleTime ();
	}

	public BigInteger TimedUpdate(float deltaTime)
	{
		BigInteger income = 0;

		while ((this.CurrentCycle - deltaTime) <= 0) {
			income += this.Income * this.Multiplier;
			deltaTime -= this.CurrentCycle;
			this.CurrentCycle = this.CycleTime;
		}

		this.CurrentCycle -= deltaTime;

		return income;
	}

	public abstract void UpdateIncome ();
	public abstract void UpdateLevelPrice ();
	public abstract void UpdateCycleTime ();

	public void UpdateIncome(BigInteger val) {
		this.Income = val;
	}

	public void UpdateLevelPrice(BigInteger val) {
		this.NextLevelPrice = val;
	}

	public void UpdateCycleTime(float newTime) {
		this.CycleTime = newTime;
	}

	public void AddMultiplier(int val)
	{
		this.Multiplier += val;
	}

	public void AddCycleReduceFactor(float val)
	{
		this.CycleReduceFactor *= (1f - val);
	}
}

public class Prod1 : Product
{
	public Prod1 (int level) : base(level, "Mel"){}

	public override void UpdateIncome ()
	{
		base.UpdateIncome (10 * base.Level);
	}

	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (10 + 20 * base.Level);
	}

	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (1f);
	}

}

public class Prod2 : Product
{
	public Prod2 (int level) : base(level, "Larvas"){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}

	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
	}

}

public class Prod3 : Product
{
	public Prod3 (int level) : base(level, "Favos"){}
	
	public override void UpdateIncome ()
	{
		base.UpdateIncome (50 * base.Level);
	}
	
	public override void UpdateLevelPrice ()
	{
		base.UpdateLevelPrice (50 + 100 * base.Level);
	}
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
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
	
	public override void UpdateCycleTime ()
	{
		base.UpdateCycleTime (10f);
	}
}