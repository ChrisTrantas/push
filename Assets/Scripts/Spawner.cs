using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject ShockwaveBoost;
	public GameObject IceBoost;
	private float timer;
	
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
        if (timer > 4)
        {
            float randomSpawn = Random.Range(0.0f, 8.0f);
            if (randomSpawn < 2)
            {
                IceBoost.transform.position = transform.position + new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
                ShockwaveBoost.transform.position = new Vector3(-100000, 10000, 100000);
            }
            else
            {
                ShockwaveBoost.transform.position = transform.position + new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
                IceBoost.transform.position = new Vector3(-100000, 10000, 100000);
            }
            timer = 0;
        }
	}
}