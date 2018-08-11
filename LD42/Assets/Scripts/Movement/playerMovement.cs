using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	float hz, vt;
	public float speed = 5, grav_multiplier = 2;
	Rigidbody rb;
	public bool DJump_Enabled = true;	//Double jump
	bool isGrounded = true, dJump = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		hz = Input.GetAxis ("Horizontal");
		vt = Input.GetAxis ("Vertical");

		Vector3 targetDirection = new Vector3 (hz, 0f, vt);
		targetDirection = Camera.main.transform.TransformDirection (targetDirection);
		targetDirection.y = 0.0f;

		gameObject.transform.Translate (targetDirection.normalized * Time.deltaTime * speed, Space.World);

		if (targetDirection != Vector3.zero) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (targetDirection), Time.deltaTime * 60);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isGrounded || (dJump && DJump_Enabled)) {
				rb.AddForce (-Physics.gravity * grav_multiplier, ForceMode.Acceleration);
				if (dJump && DJump_Enabled) {
					dJump = false;
				}
			}
		}
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isGrounded = true;
			if (DJump_Enabled) {
				dJump = false;
			}
			Debug.Log ("True");
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isGrounded = false;
			if (DJump_Enabled) {
				dJump = true;
			}
			Debug.Log ("False");
		}
	}
}
