using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	#region Public Properties
	#endregion

	#region Private Properties
	private bool movingToPositiveX = true;
	private bool movingToPositiveZ = true;
	#endregion

	// Use this for initialization
	void Start () {
		float x = 0;
		float y = 0;
		float z = -10;
		this.transform.position = new Vector3(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
		float newX;
		float newZ;
		float newYRotation;
		float tempZ;
		float tempY1;
		float tempY2;
		Quaternion newRotation;

		if (movingToPositiveX) {
			if (this.transform.position.x < 10)
				newX = this.transform.position.x + 0.05f; //2*Time.deltaTime;
			else {
				movingToPositiveX = false;
				newX = this.transform.position.x - 0.05f; //2*Time.deltaTime;

			}
		}
		else {
			if (this.transform.position.x > -10)
				newX = this.transform.position.x - 0.05f; //2*Time.deltaTime;
			else {
				movingToPositiveX = true;
				newX = this.transform.position.x + 0.05f; //2*Time.deltaTime;
			
			}
		}

		if (newX > 10)
			newX = 10;
		if (newX < -10)
			newX = -10;

		if (newX <= 10 && newX >= -10)
			tempZ = Mathf.Sqrt((10*10) - (newX*newX));
		else
			tempZ = 0;

		if (movingToPositiveX)
			newZ = -tempZ;
		else
			newZ = tempZ;

		newYRotation = Mathf.Atan(newZ/(-1*newX));
		newYRotation = 180*(newYRotation/Mathf.PI);
		Debug.Log("Debug Begin: " + newYRotation);
		if (this.transform.position.x < 0)
			newYRotation += 90;
		else
			newYRotation -= 90;
		Debug.Log ("Debug End: " + newYRotation);

		if (newZ > 0 && newYRotation < 0 && newX <= 0)
			newYRotation += 180;
		else if (newZ < 0 && newYRotation > 0 && newX >= 0)
			newYRotation -= 180;


		/*tempY1 = this.transform.rotation.y + 1f;
		tempY2 = this.transform.rotation.y - 1f;
		if (tempY1 > 360)
			tempY1 -= 360f;
		if (tempY2 < 0)
			tempY2 += 360f;
		if (newYRotation < tempY1 || newYRotation > tempY2)
		*/	newRotation = Quaternion.Euler(0, newYRotation, 0);
		//else
		//	newRotation = Quaternion.Euler(0, newYRotation - 180, 0);

		this.transform.position = new Vector3(newX, this.transform.position.y, newZ);
		this.transform.rotation = newRotation;

	
	}
}
