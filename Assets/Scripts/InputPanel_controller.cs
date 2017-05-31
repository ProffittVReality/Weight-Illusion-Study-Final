using UnityEngine;
using System.Collections;

public class InputPanel_controller : MonoBehaviour {

	public GameObject weightInput; 
	private bool isShowing;
	int cube;

	// Use this for initialization
	void Start () {
		isShowing = false; 
		cube = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			cube = 1; 
			isShowing = !isShowing;
			weightInput.SetActive (isShowing);
			Debug.Log ("I did 1");
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			cube = 2; 
			isShowing = !isShowing;
			weightInput.SetActive (isShowing);
			Debug.Log ("I did 2");
		}

		if (Input.GetKeyDown (KeyCode.Alpha0)) { 
			cube = 0;
			isShowing = !isShowing;
			weightInput.SetActive (isShowing);
			Debug.Log ("I did 3");
		}


	}


		
}
