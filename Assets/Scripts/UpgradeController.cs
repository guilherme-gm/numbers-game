using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeController : MonoBehaviour {
	public static UpgradeController Instance;

	public Dictionary<int, Upgrade> UpgradeList;

	void Start()
	{
		UpgradeList = new Dictionary<int, Upgrade>();

		UpgradeList.Add (1, new MultiplierUpgrade (Products.Prod1, 5));
		UpgradeList.Add (2, new MultiplierUpgrade (Products.Prod1, 10));
		UpgradeList.Add (3, new MultiplierUpgrade (Products.Prod1, 15));
		UpgradeList.Add (4, new MultiplierUpgrade (Products.Prod1, 20));

		Instance = this;
		if (Instance == null)
			Debug.LogError ("Failed to set Instance Of UpgradeController");
	}

	public void OnBuyUpgrade(int upgradeId)
	{
		Product prod = GameController.Instance.ProdList[UpgradeList[upgradeId].Target];

		if (UpgradeList[upgradeId].Type == UpgradeType.Multiplier) {
			prod.AddMultiplier(((MultiplierUpgrade)UpgradeList[upgradeId]).Multiplier);
		}
	}
}
