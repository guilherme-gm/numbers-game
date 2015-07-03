using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static GameController Instance = null;

	public Dictionary<Products, Product> ProdList { get; private set; }
	public BigInteger Money; //{ get; private set; }
	public Text[] ProdButtons;
	public Text MoneyDisplay;
	public GameObject UpgradesPanel;

	// Use this for initialization
	void Start () {
		this.ProdList = new Dictionary<Products, Product> ();

		GameLoader.GameDataContainer cont = GameLoader.LoadGameSave ();

		this.Money = cont.Money;
		UpdateMoneyDisplay ();

		this.ProdList = GameLoader.LoadProducts (ref cont);

		foreach (Products p in ProdList.Keys) {
			UpdateButtonDisplay(p);
		}

		Instance = this;
		if (Instance == null)
			Debug.LogError ("Failed to set Instance Of GameController");

	}

	private void OnApplicationQuit()
	{
		GameLoader.SaveGame ();
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
