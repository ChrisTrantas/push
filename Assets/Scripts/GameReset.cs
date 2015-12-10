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
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log("AHFEIJF");
			deathCount++;
		}
	}
}
