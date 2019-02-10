using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject explode2;
    public float score; // score for individual enemy
    
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
    }
}
