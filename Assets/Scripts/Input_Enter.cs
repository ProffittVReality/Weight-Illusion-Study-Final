using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class Input_Enter : MonoBehaviour {

	public string FileName;
	public Text display;
	public Text trialDisplay;
	public Text particNumDisplay;
	private int check = 0;
	private int trialNumber;
	private int partNum;

	public Rigidbody testCubeXS;
	public Rigidbody testCubeXL;
	public Transform cubeXS;
	public Transform cubeXL;
	private int cubeWeight;
	//public int weightDistr;
	public int numSets;
	private int same;
	public Renderer rend;

	private ArrayList possibleWeights = new ArrayList();
	private ArrayList possibleWeights2 = new ArrayList();
	private System.Random rndm = new System.Random();

	public Quaternion originalRotationXS;
	public Quaternion originalRotationXL;
	public Vector3 originalPositionXS;
	public Vector3 originalPositionXL;

	void Start() {
		trialNumber = 1; 
		System.Random rndm = new System.Random();
		for (int a = 0; a < numSets; a++){
			possibleWeights.Add (rndm.Next (20,  96));
			possibleWeights.Add (rndm.Next (96,  172));
			possibleWeights.Add (rndm.Next (172,  248));
			possibleWeights.Add (rndm.Next (248,  324));
			possibleWeights.Add (rndm.Next (324,  400+1));
			possibleWeights2.Add (rndm.Next (20,  96));
			possibleWeights2.Add (rndm.Next (96,  172));
			possibleWeights2.Add (rndm.Next (172,  248));
			possibleWeights2.Add (rndm.Next (248,  324));
			possibleWeights2.Add (rndm.Next (324,  400+1));
			rend = GetComponent<Renderer> ();
		}

		print (possibleWeights.ToString());
		changeWeight ();
		partNum = getPartNum ();
		particNumDisplay.text = "Partic.\nNumber:\n" + partNum.ToString();

		originalRotationXS = cubeXS.rotation;
		originalRotationXL = cubeXL.rotation;
		originalPositionXS = cubeXS.position;
		originalPositionXL = cubeXL.position;
	}

	public void enter() { 
		int num=0;
		//if (display.text != "" && display.text != "Small\nWeight Estimate" && display.text != "Large\nWeight Estimate" && display.text != "DONE" && display.text != "Experiment/nComplete") {
		if(int.TryParse(display.text, out num) && display.text != "" ) {
			if (check == 1) {
				exportData ();
				display.text = "DONE";
			} else if (check > 1) {
				display.text = "DONE";
			} else {
				exportData ();
				display.text = "Large\nWeight Estimate";
			}
			check++;
		}
	}

	void exportData() {
		string path = @"Assets\Data\" + FileName + ".txt";
			string theTime = DateTime.Now.ToString ("hh:mm:ss");
			string theDate = DateTime.Now.ToString ("d");
			if (!File.Exists (path)) {
				string header = "Participant Number\tTime\tDate\tTrial Number\tWeight Estimate\tSmall Weight\tLarge Weight\tSmall Box Size\tLarge Box Size\r\n";
				File.WriteAllText (path, header);
			}
		string appendText = partNum.ToString() + "\t" + theTime+" "+theDate +"\t"+ trialNumber.ToString() + "\t" + display.text + "\t" + testCubeXS.mass + "\t" + testCubeXL.mass + "\t" +testCubeXS.transform.localScale + "\t" + testCubeXL.transform.localScale + "\r\n";
		File.AppendAllText (path, appendText);
	}

	void Update() {
		//commented for testing, remember to uncomment
		if (Input.GetKeyDown (KeyCode.Return) && trialNumber < 11 && check > 1 && trialNumber < numSets * 5 + 1) {
		//if(Input.GetKeyDown(KeyCode.Return)) {
			trialNumber++;
			nextTrial (trialNumber);
		} else if (trialNumber > numSets * 5)
			display.text = "Experiment\nComplete";
	}

	void nextTrial (int trialNumber) {
		check = 0;
		display.text = "Small\nWeight Estimate";
		trialDisplay.text = "Trial\nNumber:\n" + trialNumber.ToString();
		changeWeight ();
		changeSize ();
	}

	void changeWeight () {
		int temp = rndm.Next (0, possibleWeights.Count - 1);
		cubeWeight = (int)possibleWeights[temp];

		if (same == 2) {
			int temp2 = rndm.Next (0, possibleWeights.Count - 1);
			int cubeWeight2 = (int)possibleWeights[temp2];
			testCubeXS.mass = cubeWeight2; 
			testCubeXL.mass = cubeWeight;
			same = 0;

		}
		else {
			testCubeXL.mass = cubeWeight;
			testCubeXS.mass = cubeWeight;
		}
		Debug.Log(same+ " " + testCubeXL.mass + " " + testCubeXS.mass);
		possibleWeights.RemoveAt (temp);
		same++;
	}

	void moveHandle (string handleName, string cubeName, float scale, Quaternion initRotation, Vector3 initPosition) {
		GameObject cube = GameObject.Find(cubeName);
		Vector3 cubePosition = cube.transform.localPosition; //use localPosition to change cube relative to parent sphere
		cubePosition.y = -scale/2 - .48f; //0.48 is arbitrary offset for handle (0.5 is sphere sitting on top of cube)
		cube.transform.localPosition = cubePosition;


		GameObject handle = GameObject.Find(handleName);
		Vector3 handlePosition = handle.transform.position;
		handlePosition.y = (scale*0.1f) + 0.05f;
		handlePosition.x = initPosition.x;
		handlePosition.z = initPosition.z;
		handle.transform.position = handlePosition;

		handle.transform.rotation = initRotation;
	}



	void changeSize () { 
		float smallScale = (float)rndm.Next (1, 3)*2 + (float)rndm.NextDouble();
		Debug.Log (smallScale);
		Vector3 scale = cubeXS.localScale;
		scale.x = smallScale;
		scale.y = smallScale;
		scale.z = smallScale;
		cubeXS.transform.localScale = scale;

		float largeScale = (float)rndm.Next (3, 5)*2 + (float)rndm.NextDouble();
		Debug.Log (largeScale);
		Vector3 scale2 = cubeXL.localScale;
		scale2.x = largeScale;
		scale2.y = largeScale;
		scale2.z = largeScale;
		cubeXL.transform.localScale = scale2;
		if (smallScale > 2) {
			Debug.Log ("changed");
			//rend.material.mainTextureScale = new Vector2 (2.0f, 2.0f);
		}

		moveHandle("SphereXS", "Cube_XS", smallScale, originalRotationXS, originalPositionXS);
		moveHandle("SphereXL", "Cube_XL", largeScale, originalRotationXL, originalPositionXL);
	}

	int getPartNum() {
		String line;  

		string path = @"Assets\Data\ParticNum.txt";
		if (!File.Exists (path)) {
			File.WriteAllText (path, "0");
		}
		string text = File.ReadAllText(path);
		int m = 0;
		try
		{
			m = Int32.Parse(text);
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		m++;
		text = text.Replace(text, m.ToString());
		File.WriteAllText(path, text);
		text = File.ReadAllText(path);
		return m--;
		
	}
}


