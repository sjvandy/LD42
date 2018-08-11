using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {
	
		float rotationY = 0F;
		public Camera cam;

		
		// Update is called once per frame
		void Update () {        
		if (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0) {
			float rotationX = gameObject.transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * 2f;

			rotationY += Input.GetAxis ("Mouse Y") * 5f;        
			gameObject.transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
			cam.transform.LookAt (cam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, cam.farClipPlane)));

		}
	}
}
