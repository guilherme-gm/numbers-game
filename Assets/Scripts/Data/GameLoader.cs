using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameLoader
{
	public static Dictionary<Products, Product> LoadProducts()
	{
		Dictionary<Products, Product> prodList = new Dictionary<Products, Product> ();

		prodList.Add(Products.Prod1, new Prod1(1));
		prodList.Add(Products.Prod2, new Prod2(0));
		prodList.Add(Products.Prod3, new Prod3(0));
		prodList.Add(Products.Prod4, new Prod4(0));
		prodList.Add(Products.Prod5, new Prod5(0));
		prodList.Add(Products.Prod6, new Prod6(0));
		prodList.Add(Products.Prod7, new Prod7(0));
		prodList.Add(Products.Prod8, new Prod8(0));
		prodList.Add(Products.Prod9, new Prod9(0));
		prodList.Add(Products.Prod10, new Prod10(0));

		return prodList;
	}

	public static Dictionary<int, Upgrade> LoadUpgrades()
	{
		Dictionary<int, Upgrade> upgrdList = new Dictionary<int, Upgrade> ();

		upgrdList.Add (1, new MultiplierUpgrade (Products.Prod1, 10, "Upgrade1 Name", 1000));

		return upgrdList;
	}
}
