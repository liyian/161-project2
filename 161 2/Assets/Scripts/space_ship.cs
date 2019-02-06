using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_ship : MonoBehaviour
{   

    public float bullet_speed;
    public float fireRate;
    public float fireTime;
    public float count=0;
    public float speed =200f;
    public GameObject bullet;
    public Transform fire_position;
    private Rigidbody2D rb;
    private Rigidbody2D bullet_rb;
    private float axis;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTime +=Time.deltaTime;
        if(Input.GetKeyDown("space")||Input.GetKey(KeyCode.Mouse0)){
            if(count ==0||(fireTime>fireRate&&count<1)){
                GameObject b = Instantiate(bullet, fire_position.position,Quaternion.identity);
                b.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bullet_speed,ForceMode2D.Impulse);
                count+=1;
                fireTime =Time.deltaTime;//reset time
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
