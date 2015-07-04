using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeController : MonoBehaviour {
	public static UpgradeController Instance;

	public Dictionary<int, Upgrade> UpgradeList;
	public List<int> AcquiredUps;

	public GameObject UpgradePanel;
	public GameObject UpgradeBtn;


	void Start()
	{
		UpgradeList = GameLoader.LoadUpgrades ();
		AcquiredUps = new List<int> ();

		//UpgradeList.Add (1, new MultiplierUpgrade (Products.Prod1, 5));
		//UpgradeList.Add (2, new MultiplierUpgrade (Products.Prod1, 10));
		//UpgradeList.Add (3, new MultiplierUpgrade (Products.Prod1, 15));
		//UpgradeList.Add (4, new MultiplierUpgrade (Products.Prod1, 20));
		//UpgradeList.Add (5, new CycleReduceUpgrade (Products.Prod1, 0.5f));

		//UpdateUpgrdList ();

		Instance = this;
		if (Instance == null)
			Debug.LogError ("Failed to set Instance Of UpgradeController");
	}

	public void OnLoadGame(ref GameLoader.GameDataContainer data)
	{
		for (int i = 0; i < data.AcquiredUpgrades.Count; i++)
		{
			this.UpgradeList[data.AcquiredUpgrades[i]].ApplyUpgrade();
			this.UpgradeList.Remove(data.AcquiredUpgrades[i]);
			this.AcquiredUps.Add(data.AcquiredUpgrades[i]);
		}
		UpdateUpgrdList ();
	}

	public void OnBuyUpgrade(int upgradeId, GameObject button)
	{
		this.UpgradeList [upgradeId].ApplyUpgrade ();
		this.AcquiredUps.Add (upgradeId);
		GameObject.Destroy (button);
	}

	//
	private void UpdateUpgrdList()
	{
		// TODO : Maybe this can be improved
		//		 to not require a list clean-up

		// Clears the upgrade List
		foreach (Transform oldUpgrd in UpgradePanel.transform) {
			GameObject.Destroy(oldUpgrd.gameObject);
		}

		// Generate a new list
		foreach (int id in this.UpgradeList.Keys) {
			GameObject upgrdBtn = Instantiate(this.UpgradeBtn) as GameObject;
			UpgradeButton btnData = upgrdBtn.GetComponent<UpgradeButton>();
			if (this.UpgradeList[id].Type == UpgradeType.Multiplier)
			{
				btnData.Data = new UpgradeBtnData()
				{
					Title = UpgradeList[id].Name,
					Description = "Multiplies the income of " + GameController.Instance.ProdList[UpgradeList[id].Target].Name,
					UpgradeId = id,
					Price = UpgradeList[id].Price
				};
			}
			btnData.UpdateDisplay();
			upgrdBtn.transform.SetParent(UpgradePanel.transform);
		}
	}
}
