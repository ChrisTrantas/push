using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character2Script : MonoBehaviour {

	private Vector3 acceleration;
	public Vector3 velocity;
	private Rigidbody contr;

    private float health;
    private float speed = 1.0f;

    private Stack<Item> itemStack = new Stack<Item>();

    public void ApplyItem(Item item)
    {
        itemStack.Push(item);
        StartCoroutine("ItemEffectTimer");
        health += item.health;
        speed *= item.speed;
    }

    IEnumerator ItemEffectTimer()
    {
        Item item = itemStack.Pop();
        health -= item.health;
        speed /= item.speed;
        yield return new WaitForSeconds(0.5f);
    }

	// Use this for initialization
	void Start () {
		contr = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Getting player input
		if(Input.GetKey(KeyCode.LeftArrow)){
			acceleration +=(transform.right*-.001f);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			acceleration +=(transform.right*.001f);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			acceleration +=(transform.forward*-.001f);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			acceleration +=(transform.forward*.001f);
		}
		
		//Clamping the velocity so players can't go too fast
		Vector3.ClampMagnitude (velocity, 1);
		
		//Adding the acceleration from this update to the overall velocity.
		velocity += acceleration * speed;
		
		//Zeroing the velocity for the next update
		acceleration = Vector3.zero;
		
		//Adding the velocity to the object's overall position
		transform.position+=velocity;
	}

	void OnCollisionEnter(Collision col){
		//If players are colliding then we mimic a somewhat inelastic collision by swapping their velocities and setting them to 80%
		if (col.gameObject.tag == "Player") {
			Vector3 otherPos = col.transform.position;
			col.gameObject.GetComponent<Character1Script> ().velocity = ((transform.position-otherPos).normalized)*velocity.magnitude*-.8f;
		}
	}
}
