using UnityEngine;
using System.Collections;

public class ShockwaveItem : Item
{
    public float force;
    public float range;
	public ShockwaveItem()
	{
		health = 0.0f;
		speed = 1.0f;
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject playerObject in players)
            {
                Vector3 push = Vector3.zero;
                if (playerObject.GetComponent<Character1Script>().PlayerNumber != col.gameObject.GetComponent<Character1Script>().PlayerNumber)
                {
                    push = (playerObject.transform.position - col.transform.position);
                    if (Vector3.Distance(playerObject.transform.position, col.transform.position) < range)
                    {
                        push *= (force / Vector3.Distance(playerObject.transform.position, col.transform.position));
                        playerObject.GetComponent<Character1Script>().SetAcceleration(push);
                    }
                }
            }
        }
    }
}
