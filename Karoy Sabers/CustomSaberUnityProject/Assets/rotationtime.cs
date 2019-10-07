using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationtime : MonoBehaviour {
	public float speed;

	void Update () {
		transform.Rotate (0,-speed*Time.deltaTime,0); //rotates 50 degrees per second around z axis
	}
}
