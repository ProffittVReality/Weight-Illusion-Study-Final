using UnityEngine;
using System.Collections;

public class AttachTogether : MonoBehaviour {

	public Transform cube;

	// Use this for initialization
	void Start () {
		cube.SetParent (this.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
