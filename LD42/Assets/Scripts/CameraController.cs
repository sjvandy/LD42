using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public bool useOffsetValues;
	public float rotateSpeed;


	//float horizontal, vertical;
	//float desiredYAngle, desiredXAngle;

	public Transform pivot;

	// Use this for initialization
	void Start () {
		if (!useOffsetValues) {
			offset = target.position - transform.position;
		}

		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;

		//Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.Rotate (0, horizontal, 0);

		float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
		pivot.Rotate (-vertical, 0, 0);

		float desiredYAngle = target.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;

		Quaternion rotation = Quaternion.Euler (desiredXAngle, desiredYAngle, 0);
		transform.position = target.position - (rotation * offset);

		if (transform.position.y < target.position.y) {
			transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
		}


		transform.LookAt (target);
		 

	}
}
