using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class lifenum : MonoBehaviour
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
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
