using UnityEngine;
using System.Collections;

public class Character2Script : MonoBehaviour {

	private Vector3 acceleration;
	public Vector3 velocity;
	private Rigidbody contr;
	
	
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
		velocity += acceleration;
		
		//Zeroing the velocity for the next update
		acceleration = Vector3.zero;
		
		//Adding the velocity to the object's overall position
		transform.position+=velocity;
	}
}
