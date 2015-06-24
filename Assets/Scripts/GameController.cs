using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Dictionary<Products, Product> ProdList { get; private set; }
	public BigInteger Money { get; private set; }
	public Text[] ProdButtons;
	public Text MoneyDisplay;

	private float NextUpdate = 0.0f;

	// Use this for initialization
	void Start () {
		this.ProdList = new Dictionary<Products, Product> ();

		ProdList.Add (Products.Prod1, new Prod1(1));
		ProdList.Add (Products.Prod2, new Prod2(0));

		foreach (Products p in ProdList.Keys) {
			UpdateButtonDisplay(p);
		}

		Money = 0;
		NextUpdate = Time.time;
	}

	/// <summary>
	/// Called whenever one of products buy button is clicked.
	/// </summary>
	/// <param name="buttonId">Button identifier.</param>
	public void OnBuyClick(int buttonId)
	{
		// Converts buttonId to enum
		Products p = (Products)buttonId;

		// Ensures that this Id exists
		if (!ProdList.ContainsKey (p)) {
			// TODO : Error handling.
			return;
		}

		if (this.Money >= ProdList [p].NextLevelPrice) {
			Money -= ProdList[p].NextLevelPrice;
			UpdateMoneyDisplay();
			ProdList [p].Upgrade ();
			UpdateButtonDisplay(p);
		}
	}

	private void Update()
	{
		if (Time.time > this.NextUpdate) {
			foreach(Product prod in ProdList.Values)
			{
				Money +=  prod.Income;
			}

			this.UpdateMoneyDisplay();
			this.NextUpdate += 1.0f;
		}
	}

	private void UpdateMoneyDisplay()
	{
		MoneyDisplay.text = this.Money.ToString ();
	}

	private void UpdateButtonDisplay(Products type)
	{
		ProdButtons [(int)type].text = "Lv " + ProdList[type].Level + " - " + ProdList [type].NextLevelPrice;
	}
}
