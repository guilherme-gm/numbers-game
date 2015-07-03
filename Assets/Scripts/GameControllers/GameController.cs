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

		ProdList.Add (Products.Prod1, new Prod1(cont.ProdList[(int)Products.Prod1]));
		ProdList.Add (Products.Prod2, new Prod2(cont.ProdList[(int)Products.Prod2]));
		/*ProdList.Add (Products.Prod3, new Prod3(cont.ProdList[(int)Products.Prod3]));
		ProdList.Add (Products.Prod4, new Prod4(cont.ProdList[(int)Products.Prod4]));
		ProdList.Add (Products.Prod5, new Prod5(cont.ProdList[(int)Products.Prod5]));
		ProdList.Add (Products.Prod6, new Prod6(cont.ProdList[(int)Products.Prod6]));
		ProdList.Add (Products.Prod7, new Prod7(cont.ProdList[(int)Products.Prod7]));
		ProdList.Add (Products.Prod8, new Prod8(cont.ProdList[(int)Products.Prod8]));
		ProdList.Add (Products.Prod9, new Prod9(cont.ProdList[(int)Products.Prod9]));
		ProdList.Add (Products.Prod10, new Prod10(cont.ProdList[(int)Products.Prod10]));*/
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

		//Money = 0;

		Instance = this;
		if (Instance == null)
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
