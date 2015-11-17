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
			Debug.Log ("Spawn");
			if(Random.Range(0,2)==0){
				SpeedBoost.transform.position = transform.position;
				IceBoost.transform.position= new Vector3(-100000,10000,100000);
			}else{
				IceBoost.transform.position = transform.position;
				SpeedBoost.transform.position= new Vector3(-100000,10000,100000);
			}
			timer=0;
		}
	}
}