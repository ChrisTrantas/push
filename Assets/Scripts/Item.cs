using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public float health;
    public float speed;
	public bool veloCut;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Character1Script playerScript = col.gameObject.GetComponent<Character1Script>();
            playerScript.ApplyItem(this);

            //Character1Script player = col.gameObject.GetComponent<Character1Script>();
            //layer.ApplyItem(this);
			this.transform.position= new Vector3(-100000,10000,100000);
        }
    }
}
