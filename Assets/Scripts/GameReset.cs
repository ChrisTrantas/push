using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;

	int deathCount;

	void Start () {
		deathCount = 0;
	}

	// Update is called once per frame
	void Update () {
		if (deathCount >= 3) {
			Player1.GetComponent<Character1Script>().velocity = Vector3.zero;
			Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
			Player1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			Player1.transform.position= new Vector3(-6f,-2.72f,0f);
			Player2.GetComponent<Character1Script>().velocity = Vector3.zero;
			Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
			Player2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			Player2.transform.position= new Vector3(6f,-2.72f,0f);
			Player3.GetComponent<Character1Script>().velocity = Vector3.zero;
			Player3.GetComponent<Rigidbody>().velocity = Vector3.zero;
			Player3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			Player3.transform.position= new Vector3(0f,-2.72f,-6f);
			Player4.GetComponent<Character1Script>().velocity = Vector3.zero;
			Player4.GetComponent<Rigidbody>().velocity = Vector3.zero;
			Player4.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			Player4.transform.position= new Vector3(0f,-2.72f,6f);
			deathCount=0;

			GameObject[] bouncers = GameObject.FindGameObjectsWithTag("Bouncer");
			for(int i =0;i<bouncers.Length;i++){
				bouncers[i].GetComponent<BumperScript>().Reset();
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log("AHFEIJF");
			deathCount++;
		}
	}
}
