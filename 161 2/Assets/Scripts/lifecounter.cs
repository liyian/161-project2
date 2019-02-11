using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                 
public class lifecounter : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "bullet" || other.gameObject.tag == "player")
		{
			health = health - 1;
            this.GetComponent<Text>().text = health.ToString("3");
		}
	}
}
