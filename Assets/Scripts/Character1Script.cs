using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character1Script : MonoBehaviour
{

    //This number represents the number of the player to be used for control options
    public int PlayerNumber;
	
    private float friction = 1.01f;

    //The acceleration for movement
    private Vector3 acceleration;
    //The velocity for movement
    public Vector3 velocity;
    //This boolean checks if the velocity has already been swapped as a result of a collision,
    //and keeps us from swapping velocities twice in a collision
    private bool velocitySwapped = false;

    private float health;
    public float speed;
	private bool veloCut=false;
	private bool prevBoost;
	private float timerElapsed;
	private float timerFull =2.0f;

    private Stack<Item> itemStack = new Stack<Item>();

    public void ApplyItem(Item item)
    {
        itemStack.Push(item);
        StartCoroutine("ItemEffectTimer");
        health += item.health;
        speed *= item.speed;
		veloCut = item.veloCut;
    }

    IEnumerator ItemEffectTimer()
    {
		yield return new WaitForSeconds(3.0f);
        Item item = itemStack.Pop();
        health -= item.health;
        speed /= item.speed;
		veloCut = false;
		prevBoost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (PlayerNumber == 0)
        {
            //Getting player input and incrementing acceleration
            if (Input.GetKey(KeyCode.A))
            {
                acceleration += (Vector3.right * -.001f);
				transform.forward = new Vector3(-1,0,0);
            }
            if (Input.GetKey(KeyCode.D))
            {
				acceleration += (Vector3.right * .001f);
				transform.forward = new Vector3(1,0,0);
            }
            if (Input.GetKey(KeyCode.S))
            {
				acceleration += (Vector3.forward * -.001f);
				transform.forward = new Vector3(0,0,-1);
            }
            if (Input.GetKey(KeyCode.W))
            {
				acceleration += (Vector3.forward * .001f);
				transform.forward = new Vector3(0,0,1);
            }
			if (Input.GetKey(KeyCode.E) || Input.GetButton("P1Button"))
			{
				if(!prevBoost){
					Boost ();
					prevBoost=true;
				}
			}
			acceleration+= Vector3.forward *-Input.GetAxis("P1MoveY")* .001f;
			acceleration+= Vector3.right *Input.GetAxis("P1MoveX")* .001f;
			if(Input.GetAxis("P1MoveX")>.1 || Input.GetAxis("P1MoveY")>.1 || Input.GetAxis("P1MoveX")<-.1 || Input.GetAxis("P1MoveY")<-.1){
				transform.forward = new Vector3(Input.GetAxis("P1MoveX"),0,-Input.GetAxis("P1MoveY"));
			}

        }
        if (PlayerNumber == 1)
        {
            //Getting player input
            if (Input.GetKey(KeyCode.LeftArrow))
            {
				acceleration += (Vector3.right * -.001f);
				transform.forward = new Vector3(-1,0,0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
				acceleration += (Vector3.right * .001f);
				transform.forward = new Vector3(1,0,0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
				acceleration += (Vector3.forward * -.001f);
				transform.forward = new Vector3(0,0,-1);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
				acceleration += (Vector3.forward * .001f);
				transform.forward = new Vector3(0,0,1);
            }
			if (Input.GetKey(KeyCode.End) || Input.GetButton("P2Button"))
			{
				if(!prevBoost){
					Boost ();
					prevBoost=true;
				}
			}
			acceleration+= Vector3.forward *-Input.GetAxis("P2MoveY")* .001f;
			acceleration+= Vector3.right *Input.GetAxis("P2MoveX")* .001f;
			if(Input.GetAxis("P2MoveX")>.1 || Input.GetAxis("P2MoveY")>.1 || Input.GetAxis("P2MoveX")<-.1 || Input.GetAxis("P2MoveY")<-.1){
				transform.forward = new Vector3(Input.GetAxis("P2MoveX"),0,-Input.GetAxis("P2MoveY"));
			}
        }
        if (PlayerNumber == 2)
        {
            //Getting player input
            if (Input.GetKey(KeyCode.Keypad4))
            {
				acceleration += (Vector3.right * -.001f);
				transform.forward = new Vector3(-1,0,0);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
				acceleration += (Vector3.right * .001f);
				transform.forward = new Vector3(1,0,0);
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
				acceleration += (Vector3.forward * -.001f);
				transform.forward = new Vector3(0,0,-1);
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
				acceleration += (Vector3.forward * .001f);
				transform.forward = new Vector3(0,0,1);
            }
			if (Input.GetKey(KeyCode.Keypad9) || Input.GetButton("P3Button"))
			{
				if(!prevBoost){
					Boost ();
					prevBoost=true;
				}
			}
			acceleration+= Vector3.forward *-Input.GetAxis("P3MoveY")* .001f;
			acceleration+= Vector3.right *Input.GetAxis("P3MoveX")* .001f;
			if(Input.GetAxis("P2MoveX")>.1 || Input.GetAxis("P2MoveY")>.1 || Input.GetAxis("P2MoveX")<-.1 || Input.GetAxis("P2MoveY")<-.1){
				transform.forward = new Vector3(Input.GetAxis("P3MoveX"),0,-Input.GetAxis("P3MoveY"));
			}
        }
        if (PlayerNumber == 3)
        {
            //Getting player input
            if (Input.GetKey(KeyCode.J))
            {
				acceleration += (Vector3.right * -.001f);
				transform.forward = new Vector3(-1,0,0);
            }
            if (Input.GetKey(KeyCode.L))
            {
				acceleration += (Vector3.right * .001f);
				transform.forward = new Vector3(1,0,0);
            }
            if (Input.GetKey(KeyCode.K))
            {
				acceleration += (Vector3.forward * -.001f);
				transform.forward = new Vector3(0,0,-1);
            }
            if (Input.GetKey(KeyCode.I))
            {
				acceleration += (Vector3.forward * .001f);
				transform.forward = new Vector3(0,0,1);
            }
			if (Input.GetKey(KeyCode.O) || Input.GetButton("P4Button"))
			{
				if(!prevBoost){
					Boost ();
					prevBoost=true;
				}
			}
			acceleration+= Vector3.forward *-Input.GetAxis("P4MoveY")* .001f;
			acceleration+= Vector3.right *Input.GetAxis("P4MoveX")* .001f;
			if(Input.GetAxis("P4MoveX")>.1 || Input.GetAxis("P4MoveY")>.1 || Input.GetAxis("P4MoveX")<-.1 || Input.GetAxis("P4MoveY")<-.1){
				transform.forward = new Vector3(Input.GetAxis("P4MoveX"),0,-Input.GetAxis("P4MoveY"));
			}
        }

        //Clamping the velocity so players can't go too fast
        Vector3.ClampMagnitude(velocity, 1);
	
        //Adding the acceleration from this update to the overall velocity.
		velocity += acceleration * speed;


        //Zeroing the velocity for the next update
        acceleration = Vector3.zero;

		if (veloCut) {
			velocity = Vector3.zero;
		}
		//Adding the velocity to the object's overall position
		transform.position += velocity;

		if (prevBoost) {
			timerElapsed += Time.deltaTime;
			if(timerElapsed>timerFull){
				prevBoost=false;
				timerElapsed=0;
			}
		}

        velocity /= friction;
    }

    void ResolveBounce(Vector3 newVelo)
    {
        velocity = newVelo;
        velocitySwapped = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (!velocitySwapped)
        {
            //If players are colliding then we mimic a somewhat inelastic collision by swapping their velocities and setting them to 80%
            if (col.gameObject.tag == "Player")
            {
                Vector3 tempVec = col.gameObject.GetComponent<Character1Script>().velocity;
                col.gameObject.GetComponent<Character1Script>().ResolveBounce(((col.transform.position - transform.position).normalized) * velocity.magnitude * .8f);
                ResolveBounce(((transform.position - col.transform.position).normalized) * tempVec.magnitude * .8f);
            }
			if (col.gameObject.tag == "Bouncer")
			{
				Vector3 bounceForce = transform.position-col.transform.position;
				bounceForce = Vector3.Project(velocity, bounceForce);
				bounceForce *= -2f;
				bounceForce.y=0;
				velocity=bounceForce;
			}
        }
    }

	void OnCollisionExit(Collision col)
    {
		if (col.gameObject.tag == "Player")
		velocitySwapped = false;
    }

	public void SetAcceleration(Vector3 newAcceleration)
	{
		acceleration += newAcceleration;
	}

	private void Boost(){
		velocity += transform.forward *.15f;
	}
}
