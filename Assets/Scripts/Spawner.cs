using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject SpeedBoost;
	public GameObject IceBoost;
	private float timer;
	
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 7) {
			IceBoost.transform.position = new Vector3(transform.position.x + Random.Range(0,10), transform.position.y, transform.position.z + Random.Range(0,10));
			timer=0;
		}
	}
}