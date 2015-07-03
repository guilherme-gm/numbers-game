using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class GameLoader
{
	public class GameDataContainer
	{
		public BigInteger Money { get; set; }
		public int[] ProdList { get; set; }
		//public Dictionary<int, Upgrade> UpgradeList = new Dictionary<int, Upgrade>();

		// Initializes with new game data
		public GameDataContainer()
		{
			ProdList = new int[(int)Products.Max];
			ProdList[(int)Products.Prod1] = 1;

			Money = 0;
		}
	}

	public static Dictionary<Products, Product> LoadProducts(ref GameDataContainer cont)
	{
		Dictionary<Products, Product> prodList = new Dictionary<Products, Product> ();

		prodList.Add (Products.Prod1, new Prod1(cont.ProdList[(int)Products.Prod1]));
		prodList.Add (Products.Prod2, new Prod2(cont.ProdList[(int)Products.Prod2]));
		prodList.Add (Products.Prod3, new Prod3(cont.ProdList[(int)Products.Prod3]));
		prodList.Add (Products.Prod4, new Prod4(cont.ProdList[(int)Products.Prod4]));
		prodList.Add (Products.Prod5, new Prod5(cont.ProdList[(int)Products.Prod5]));
		prodList.Add (Products.Prod6, new Prod6(cont.ProdList[(int)Products.Prod6]));
		prodList.Add (Products.Prod7, new Prod7(cont.ProdList[(int)Products.Prod7]));
		prodList.Add (Products.Prod8, new Prod8(cont.ProdList[(int)Products.Prod8]));
		prodList.Add (Products.Prod9, new Prod9(cont.ProdList[(int)Products.Prod9]));
		prodList.Add (Products.Prod10, new Prod10(cont.ProdList[(int)Products.Prod10]));

		return prodList;
	}

	public static Dictionary<int, Upgrade> LoadUpgrades()
	{
		Dictionary<int, Upgrade> upgrdList = new Dictionary<int, Upgrade> ();

		upgrdList.Add (1, new MultiplierUpgrade (Products.Prod1, 10, "Upgrade1 Name", 1000));

		return upgrdList;
	}

	public static GameDataContainer LoadGameSave()
	{
		GameDataContainer data = new GameDataContainer ();

		// Ensure that the file exists, else returns 
		if (!File.Exists ("Data/SaveGame.dat"))
			return data;

		using (BinaryReader br = new BinaryReader(File.OpenRead("Data/SaveGame.dat")))
		{
			br.ReadBytes(10); // Header

			int moneyBytes = br.ReadInt32(); // sizeof (money)
			data.Money = new BigInteger(Encoding.ASCII.GetString(br.ReadBytes(moneyBytes))); // money

			// Loop for product data
			for (int i = 0; i < (int)Products.Max; i++)
			{
				int level;
				level = br.ReadInt32();

				data.ProdList[i] = level;
			}
		}

		return data;
	}

	public static bool SaveGame()
	{
		GameDataContainer data = new GameDataContainer ();

		data.Money = GameController.Instance.Money;
		for(int i = 0; i < (int)Products.Max; i++) {
			data.ProdList[i] = GameController.Instance.ProdList[(Products)i].Level;
		}


		using (BinaryWriter bw = new BinaryWriter(File.OpenWrite("Data/SaveGame.dat")))
		{
			bw.Write(new char[10]);
			byte[] money = Encoding.ASCII.GetBytes(data.Money.ToString());
			bw.Write(money.Length);
			bw.Write(money);
			for (int i = 0; i < (int)Products.Max; i++) {
				bw.Write(data.ProdList[i]);
			}
		}

		return true;
	}
}
