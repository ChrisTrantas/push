using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {
	void OnCollisionEnter(Collision col){
		this.GetComponent<Renderer> ().enabled = false;
		this.GetComponent<Collider> ().enabled = false;
	}
}
