using UnityEngine;
using System.Collections;

public class Character1Script : MonoBehaviour {

	//The acceleration for movement
	private Vector3 acceleration;
	//The velocity for movement
	public Vector3 velocity;

	// Update is called once per frame
	void Update () {
		//Getting player input and incrementing acceleration
		if(Input.GetKey(KeyCode.A)){
			acceleration +=(transform.right*-.001f);
		}
		if(Input.GetKey(KeyCode.D)){
			acceleration +=(transform.right*.001f);
		}
		if(Input.GetKey(KeyCode.S)){
			acceleration +=(transform.forward*-.001f);
		}
		if(Input.GetKey(KeyCode.W)){
			acceleration +=(transform.forward*.001f);
		}

		//Clamping the velocity so players can't go too fast
		Vector3.ClampMagnitude (velocity, 1);

		//Adding the acceleration from this update to the overall velocity.
		velocity += acceleration;

		//Zeroing the velocity for the next update
		acceleration = Vector3.zero;

		//Adding the velocity to the object's overall position
		transform.position+=velocity;
	}
	
	void OnCollisionEnter(Collision col){
		//If players are colliding then we mimic a somewhat inelastic collision by swapping their velocities and setting them to 80%
		if (col.gameObject.tag == "Player") {
			Vector3 otherVelo = col.gameObject.GetComponent<Character2Script> ().velocity;
			col.gameObject.GetComponent<Character2Script> ().velocity = (velocity*.8f);
			velocity= (otherVelo*.8f);
		}
	}
}
