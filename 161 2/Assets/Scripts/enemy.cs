using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject explode2;
    public float score; // score for individual enemy
    public static float direction=1;
    public static float difficulty=1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="bullet"||other.gameObject.tag =="player")
        {
           
            Destroy(gameObject);
            GameObject ex =Instantiate(explode2,this.transform.position, Quaternion.identity);
            ex.transform.Translate(new Vector3(0,0,this.transform.position.z+0.5f));
            Animator anim = ex.GetComponent<Animator>();
            anim.Play("explode2");
            Destroy(anim.gameObject,1.5f);
        }
        
        if(other.gameObject.tag =="leftwall"){
            Debug.Log("11");
            direction = -1;
            difficulty += 0.2f/5;
        }
        else if(other.gameObject.tag =="rightwall")
        {
            direction = 1;
            difficulty += 0.2f/5;
        }
    }
}
