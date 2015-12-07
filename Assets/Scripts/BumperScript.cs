using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {
	void OnCollisionEnter(Collision col){
		this.GetComponent<Renderer> ().enabled = false;
		this.GetComponent<Collider> ().enabled = false;
	}

	public void Reset(){
		this.GetComponent<Renderer> ().enabled = true;
		this.GetComponent<Collider> ().enabled = true;
	}
}
