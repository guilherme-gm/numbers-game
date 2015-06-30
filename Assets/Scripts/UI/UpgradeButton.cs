using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class UpgradeBtnData {
	public int UpgradeId { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public BigInteger Price { get; set; }
}

public class UpgradeButton : MonoBehaviour {
	public UpgradeBtnData Data;

	public Text TitleText;
	public Text DescText;
	public Text PriceText;
	
	void Start()
	{
		this.UpdateDisplay ();
	}

	public void OnClickEvent()
	{
		UpgradeController.Instance.OnBuyUpgrade (this.Data.UpgradeId, this.gameObject);
	}

	public void UpdateDisplay()
	{
		this.TitleText.text = Data.Title;
		this.DescText.text = Data.Description;
		this.PriceText.text = "" + Data.Price;
	}
}
