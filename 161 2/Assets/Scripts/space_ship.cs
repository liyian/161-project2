using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_ship : MonoBehaviour
{
    public int health;
    public float bullet_speed;
    public float count;
    public float speed =200f;
    public GameObject bullet;
    public Transform fire_position;
    private Rigidbody2D rb;
    private Rigidbody2D bullet_rb;
    private float axis;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")||Input.GetKey(KeyCode.Mouse0)){
            if(count ==0){
                GameObject b = Instantiate(bullet, fire_position.position,Quaternion.identity);
                b.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bullet_speed,ForceMode2D.Impulse);
                count+=1;
                
            }
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="enemy")
        {
            //Destroy(gameObject);
            //Animator anim =Instantiate(die_animation,other.contacts[0].point, Quaternion.identity).GetComponent<Animator>();
            //anim.Play(die_animation);
            //Destroy(anim.gameObject,1.5f);
        }
    }
    void FixedUpdate()
    {
        
        axis = Input.GetAxisRaw("Horizontal");// 0,1,-1
        rb.velocity = -Vector2.right*axis*speed*Time.deltaTime;
    }
}
