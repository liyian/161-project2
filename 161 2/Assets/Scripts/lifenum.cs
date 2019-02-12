using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class lifenum : MonoBehaviour
{
	public int health;
    public GameObject life;
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
            SceneManager.LoadScene("gameoverscene");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "enemy" || other.gameObject.tag == "enemybullet")
		{
			health = health - 1;
			life.GetComponent<Text>().text = health.ToString("0");
            

		}
	}
}
