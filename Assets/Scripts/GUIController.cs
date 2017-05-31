using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	public GameObject ResearchGUI;
	public GameObject InputPanel;

	private bool switchGUI;

	// Use this for initialization
	void Start () {
		switchGUI = true;
		ResearchGUI.SetActive (switchGUI);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			switchGUI = !switchGUI;
			ResearchGUI.SetActive (switchGUI);
			InputPanel.SetActive (!switchGUI);
		}	
	}
}
