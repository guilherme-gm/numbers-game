using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	Dictionary<Products, Product> ProdList;

	// Use this for initialization
	void Start () {
		this.ProdList = new Dictionary<Products, Product> ();

		ProdList.Add (Products.Prod1, new Product (Products.Prod1, 1));
		ProdList.Add (Products.Prod2, new Product (Products.Prod2, 0));
	}

	/// <summary>
	/// Called whenever one of products buy button is clicked.
	/// </summary>
	/// <param name="buttonId">Button identifier.</param>
	public void OnBuyClick(int buttonId)
	{
		// Converts buttonId to enum
		Products p = (Products)buttonId;
	}
}
