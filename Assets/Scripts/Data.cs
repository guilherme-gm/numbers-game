using System.Collections;

public enum Products {
	Prod1,
	Prod2
}

public class Product
{
	public BigInteger NextLevelPrice;
	public int Level;

	public Product(Products type, int level = 0)
	{
		switch (type)
		{

		case Products.Prod1:
			// Price formula
			NextLevelPrice = 10 + 10*level;
			break;

		case Products.Prod2:
			NextLevelPrice = 50 + 50*level;
			break;

		}
	}


}