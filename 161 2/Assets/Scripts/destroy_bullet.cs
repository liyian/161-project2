using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bullet : MonoBehaviour
{   
    private space_ship s;
    public GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.FindGameObjectWithTag("player").transform.gameObject.GetComponent<space_ship>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other){
       
            Vector3 collide_position = other.contacts[0].point;
            Destroy(gameObject);
            s.count = 0; //The player cannot shoot again while a previously fired bullet is still traveling
            GameObject ex =Instantiate(explode,collide_position, Quaternion.identity);
            ex.transform.Translate(new Vector3(0,0,collide_position.z+0.5f));
            Animator anim = ex.GetComponent<Animator>();
            anim.Play("explode");
            Destroy(anim.gameObject,1.5f);
        
    }
}
