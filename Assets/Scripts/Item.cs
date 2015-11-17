using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public float health;
    public float speed;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Character1Script playerScript = col.gameObject.GetComponent<Character1Script>();
            playerScript.ApplyItem(this);

            Character1Script player = col.gameObject.GetComponent<Character1Script>();
            player.ApplyItem(this);
            Destroy(this.gameObject);
        }
    }
}
