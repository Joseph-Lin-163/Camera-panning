using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	#region Private Properties
	private float yTracker;
	#endregion

	// Use this for initialization
	void Start () {
		float rotX = 30;
		float rotY = 30;
		float rotZ = 30;
		yTracker = 30;
		Quaternion initRot;
		initRot = Quaternion.Euler(30, 30, 30);
		this.transform.rotation = initRot;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion updateRot;
		yTracker += 5f;
		updateRot = Quaternion.Euler(30, yTracker, 30);
		this.transform.rotation = updateRot;
	}
}
