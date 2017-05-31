using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Input_1_script : MonoBehaviour {

	public Text display;
	public string number;

	public void input() {
		int num;
		//if (display.text == "Small\nWeight Estimate" || display.text == "Large\nWeight Estimate" ) {
		if(!int.TryParse(display.text, out num) && display.text!= "DONE" ){
			display.text = "";
		}
		if (display.text.Length < 10) {
			display.text += number;
		}

	}
}