using UnityEngine;
using System.Collections;

public class SaveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameLoader.GameDataContainer cont = GameLoader.LoadGameSave ();

		GameController.Instance.OnLoadGame (ref cont);
		UpgradeController.Instance.OnLoadGame (ref cont);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
