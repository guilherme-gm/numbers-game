using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeController : MonoBehaviour {
	public static UpgradeController Instance;

	public Dictionary<int, Upgrade> UpgradeList;

	public GameObject UpgradePanel;
	public GameObject UpgradeBtn;


	void Start()
	{
		UpgradeList = new Dictionary<int, Upgrade>();

		UpgradeList.Add (1, new MultiplierUpgrade (Products.Prod1, 5));
		UpgradeList.Add (2, new MultiplierUpgrade (Products.Prod1, 10));
		UpgradeList.Add (3, new MultiplierUpgrade (Products.Prod1, 15));
		UpgradeList.Add (4, new MultiplierUpgrade (Products.Prod1, 20));

		UpdateUpgrdList ();

		Instance = this;
		if (Instance == null)
			Debug.LogError ("Failed to set Instance Of UpgradeController");
	}

	public void OnBuyUpgrade(int upgradeId, GameObject button)
	{
		Product prod = GameController.Instance.ProdList [UpgradeList[upgradeId].Target];

		if (UpgradeList[upgradeId].Type == UpgradeType.Multiplier) {
			prod.AddMultiplier(((MultiplierUpgrade)UpgradeList[upgradeId]).Multiplier);
		}
		GameObject.Destroy (button);
	}

	//
	public void UpdateUpgrdList()
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
			btnData.Data = new UpgradeBtnData()
			{
				Title = "Bla"+id,
				Description = "Ha"+id,
				UpgradeId = id,
				Price = 100
			};
			btnData.UpdateDisplay();
			upgrdBtn.transform.SetParent(UpgradePanel.transform);
		}
	}
}
