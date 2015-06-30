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

	public Upgrade(UpgradeType type, Products target)
	{
		this.Type = type;
		this.Target = target;
	}

	public abstract void ApplyUpgrade ();
}

public class MultiplierUpgrade : Upgrade
{
	public int Multiplier { get; private set; }

	public MultiplierUpgrade(Products prod, int multiplier) : base(UpgradeType.Multiplier, prod)
	{
		this.Multiplier = multiplier;
	}

	public override void ApplyUpgrade ()
	{
		Product prod = GameController.Instance.ProdList [this.Target].AddMultiplier(Multiplier);
	}
}

public class CycleReduceUpgrade : Upgrade
{
	public float Factor { get; private set; }
	
	public CycleReduceUpgrade(Products prod, float factor) : base(UpgradeType.CycleReducer, prod)
	{
		this.Factor = factor;
	}

	public override void ApplyUpgrade ()
	{
		Product prod = GameController.Instance.ProdList [this.Target].AddCycleReduceFactor(this.Factor);
	}
}