using UnityEngine;
using System.Collections;

public enum UpgradeType
{
	Multiplier = 1,
	CycleReducer,
}

public abstract class Upgrade
{
	public UpgradeType Type { get; private set; }
	public Products Target { get; private set; }

	public string Name { get; private set; }

	public BigInteger Price { get; private set; }

	public Upgrade(UpgradeType type, Products target, string name, BigInteger price)
	{
		this.Type = type;
		this.Target = target;
		this.Name = name;
		this.Price = price;
	}

	public abstract void ApplyUpgrade ();
}

public class MultiplierUpgrade : Upgrade
{
	public int Multiplier { get; private set; }

	public MultiplierUpgrade(Products prod, int multiplier, string name, BigInteger price) : base(UpgradeType.Multiplier, prod, name, price)
	{
		this.Multiplier = multiplier;
	}

	public override void ApplyUpgrade ()
	{
		GameController.Instance.ProdList [this.Target].AddMultiplier(Multiplier);
	}
}

public class CycleReduceUpgrade : Upgrade
{
	public float Factor { get; private set; }
	
	public CycleReduceUpgrade(Products prod, float factor, string name, BigInteger price) : base(UpgradeType.CycleReducer, prod, name, price)
	{
		this.Factor = factor;
	}

	public override void ApplyUpgrade ()
	{
		GameController.Instance.ProdList [this.Target].AddCycleReduceFactor(this.Factor);
	}
}