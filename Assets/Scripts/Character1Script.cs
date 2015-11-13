using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character1Script : MonoBehaviour
{

    //This number represents the number of the player to be used for control options
    public int PlayerNumber;
    //The acceleration for movement
    private Vector3 acceleration;
    //The velocity for movement
    public Vector3 velocity;
    //This boolean checks if the velocity has already been swapped as a result of a collision,
    //and keeps us from swapping velocities twice in a collision
    private bool velocitySwapped = false;

    private float health;
    private float speed = 1.0f;

    private Stack<Item> itemStack;

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

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (PlayerNumber == 0)
        {
            //Getting player input and incrementing acceleration
            if (Input.GetKey(KeyCode.A))
            {
                acceleration += (transform.right * -.001f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                acceleration += (transform.right * .001f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                acceleration += (transform.forward * -.001f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                acceleration += (transform.forward * .001f);
            }
        }
        if (PlayerNumber == 1)
        {
            //Getting player input
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                acceleration += (transform.right * -.001f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                acceleration += (transform.right * .001f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                acceleration += (transform.forward * -.001f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                acceleration += (transform.forward * .001f);
            }
        }
        if (PlayerNumber == 2)
        {
            //Getting player input
            if (Input.GetKey(KeyCode.F))
            {
                acceleration += (transform.right * -.001f);
            }
            if (Input.GetKey(KeyCode.H))
            {
                acceleration += (transform.right * .001f);
            }
            if (Input.GetKey(KeyCode.G))
            {
                acceleration += (transform.forward * -.001f);
            }
            if (Input.GetKey(KeyCode.T))
            {
                acceleration += (transform.forward * .001f);
            }
        }
        if (PlayerNumber == 3)
        {
            //Getting player input
            if (Input.GetKey(KeyCode.J))
            {
                acceleration += (transform.right * -.001f);
            }
            if (Input.GetKey(KeyCode.L))
            {
                acceleration += (transform.right * .001f);
            }
            if (Input.GetKey(KeyCode.K))
            {
                acceleration += (transform.forward * -.001f);
            }
            if (Input.GetKey(KeyCode.I))
            {
                acceleration += (transform.forward * .001f);
            }
        }

        /*if (PlayerNumber == 0) {
            Debug.Log ("Player 0 Velo: " + velocity.magnitude);
        }
        if (PlayerNumber == 1) {
            Debug.Log ("Player 1 Velo: " + velocity.magnitude);
        }*/

        //Clamping the velocity so players can't go too fast
        Vector3.ClampMagnitude(velocity, 1);

        //Adding the acceleration from this update to the overall velocity.
        velocity += acceleration * speed;

        //Zeroing the velocity for the next update
        acceleration = Vector3.zero;

        //Adding the velocity to the object's overall position
        transform.position += velocity;
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
        }
    }

    void OnCollisionExit()
    {
        velocitySwapped = false;
    }
}
