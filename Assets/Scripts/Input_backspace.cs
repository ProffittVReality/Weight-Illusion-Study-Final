using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Input_backspace : MonoBehaviour {

	public Text display;

	public void backspace() {
		if (display.text == "Weight Estimate") {
			display.text = "";
		}
		display.text = display.text.Substring(0, display.text.Length-1);
	}
}
