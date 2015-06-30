using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	public Dictionary<Products, Product> ProdList { get; private set; }
	public BigInteger Money { get; private set; }
	public Text[] ProdButtons;
	public Text MoneyDisplay;
	public GameObject UpgradesPanel;

	// Use this for initialization
	void Start () {
		this.ProdList = new Dictionary<Products, Product> ();

		ProdList.Add (Products.Prod1, new Prod1(1));
		ProdList.Add (Products.Prod2, new Prod2(0));
		ProdList.Add (Products.Prod3, new Prod3(0));
		ProdList.Add (Products.Prod4, new Prod4(0));
		ProdList.Add (Products.Prod5, new Prod5(0));
		ProdList.Add (Products.Prod6, new Prod6(0));
		ProdList.Add (Products.Prod7, new Prod7(0));
		ProdList.Add (Products.Prod8, new Prod8(0));
		ProdList.Add (Products.Prod9, new Prod9(0));
		ProdList.Add (Products.Prod10, new Prod10(0));

		foreach (Products p in ProdList.Keys) {
			UpdateButtonDisplay(p);
		}

		Money = 0;

		Instance = this;
		if (Instance = null)
			Debug.LogError ("Failed to set Instance Of GameController");
	}

	/* *******************
	 *  Update Routines
	 * *******************/
	private void Update()
	{
		foreach(Product prod in ProdList.Values)
		{
			this.Money += prod.TimedUpdate (Time.deltaTime);
		}
		
		this.UpdateMoneyDisplay();
	}

	private void UpdateMoneyDisplay()
	{
		MoneyDisplay.text = "$ " + this.Money.ToString ();
	}
	
	private void UpdateButtonDisplay(Products type)
	{
		ProdButtons [(int)type].text = ProdList[type].Name + " (Lv " + ProdList[type].Level + ") - $" + ProdList [type].NextLevelPrice;
	}

	/* *******************
	 *  Click Routines
	 * *******************/

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
	
	/// <summary>
	/// Called whenever the upgrade button is clicked
	/// Calls the upgrades screen
	/// </summary>
	public void OnUpgradeClick()
	{
		ShowUpgradeScreen ();
	}

	/// <summary>
	/// Called whenever the close at upgrade screen is clicked
	/// Closes the upgrades screen.
	/// </summary>
	public void OnUpgradeCloseClick()
	{
		HideUpgradeScreen ();
	}

	/* *******************
	 *  Screen Callers
	 * *******************/
	private void ShowUpgradeScreen()
	{
		UpgradesPanel.SetActive (true);
	}

	private void HideUpgradeScreen()
	{
		UpgradesPanel.SetActive (false);
	}
}
