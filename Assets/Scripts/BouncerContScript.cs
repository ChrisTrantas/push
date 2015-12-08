using UnityEngine;
using System.Collections;

public class BouncerContScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 80*Time.deltaTime, 0));
	}
}
