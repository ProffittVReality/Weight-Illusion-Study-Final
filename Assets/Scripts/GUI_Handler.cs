using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class GUI_Handler : MonoBehaviour {

	public GameObject menu; //Assign canvas to this in inspector, make sure script is on EventHandler
	public string hideShow; //Set to the key you want to press to open and close the GUI
	public string FileName; //Title the file you want to export data to!  Will be saved in resources.

	private bool isShowing;
	public InputField raName, partic,exp,age,height,weight,other; 
	//TODO: Ask around to see if there's a more efficient and elegant method to get references to all of the input fields!
	public Toggle left, right;
	public Dropdown sex;
	public Button export;

	// Use this for initialization
	void Start () {
		isShowing = true;
		export.onClick.AddListener (exportData);
		if(hideShow.Equals(""))
			hideShow = "escape";
		if (FileName.Equals (""))
			FileName = "default";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (hideShow)) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);
		}
	}


	void exportData() {
		string path = @"Assets\Data\" + FileName + ".txt";
		string theTime = DateTime.Now.ToString ("hh:mm:ss");
		string theDate = DateTime.Now.ToString ("d");
		if (!File.Exists (path)) {
			string header = "Time\tName\tP #\tExp #\tAge\tHeight\tWeight\tGender\tHand\tOther\tWeight Estimate\r\n";
			File.WriteAllText (path, header);
		}
		string hand = "";
		if (left.isOn)
			hand = hand + "L";
		if (right.isOn)
			hand = hand + "R";
		string appendText = theTime+" "+theDate +"\t"+ raName.text +"\t"+ partic.text +"\t"+ exp.text +"\t"+ age.text +
			"\t"+ height.text +"\t"+ weight.text +"\t"+ sex.captionText.text +"\t"+ hand +"\t"+ other.text + "\r\n";
		File.AppendAllText (path, appendText);
	}


	/*
	public void exportData(string weightEstimate) {
		string path = @"Assets\Data\" + FileName + ".txt";
		string theTime = DateTime.Now.ToString ("hh:mm:ss");
		string theDate = DateTime.Now.ToString ("d");
		if (!File.Exists (path)) {
			string header = "Time\tName\tP #\tExp #\tAge\tHeight\tWeight\tGender\tHand\tOther\tWeight Estimate\r\n";
			File.WriteAllText (path, header);
		}
		string hand = "";
		if (left.isOn)
			hand = hand + "L";
		if (right.isOn)
			hand = hand + "R";
		string appendText = theTime+" "+theDate +"\t"+ raName.text +"\t"+ partic.text +"\t"+ exp.text +"\t"+ age.text +
			"\t"+ height.text +"\t"+ weight.text +"\t"+ sex.captionText.text +"\t"+ hand +"\t"+ other.text + "\t" + weightEstimate + "\r\n";
		File.AppendAllText (path, appendText);
	}
	*/

}
