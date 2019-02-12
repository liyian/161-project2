using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : destroy_bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    //overide, do not want reset count for player bullet
   private void OnCollisionEnter2D(Collision2D other){
            
        if (other.gameObject.tag != "bullet")
        {
            Vector3 collide_position = other.contacts[0].point;
            Destroy(gameObject);
            GameObject ex =Instantiate(explode,collide_position, Quaternion.identity);
            ex.transform.Translate(new Vector3(0,0,collide_position.z+0.5f));
            Animator anim = ex.GetComponent<Animator>();
            anim.Play("explode");
            Destroy(anim.gameObject,1.5f);
        }
        else{
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
