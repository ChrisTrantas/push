using UnityEngine;
using System.Collections;

public class SpeedBoost : Item
{
    public SpeedBoost()
    {
        health = 0.0f;
        speed = 2.0f;
    }

	public void Start()
	{
		this.GetComponent<Item> ().speed = speed;
		this.GetComponent<Item> ().health = health;
	}
}
