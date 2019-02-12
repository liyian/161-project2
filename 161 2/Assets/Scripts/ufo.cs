using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inheritance from enemy script
public class ufo : enemy
{
    public Transform left;
    public Transform right;
    public static bool exist;
    public float speed;
    private int direction;
    private List<float> scores = new List<float>();
    // Start is called before the first frame update
    void Awake()
    {   
        left = GameObject.FindGameObjectWithTag("leftspawn").transform;
        right = GameObject.FindGameObjectWithTag("rightspawn").transform;
        scoretext = GameObject.FindGameObjectWithTag("scoreUI").GetComponent<scoreUI>();
        scores.Add(100f);scores.Add(150f);scores.Add(200f);scores.Add(250f);scores.Add(300f);
        int index = Random.Range(0,scores.Count);
        score = scores[index];
        int a = Random.Range(1,3);
        if(a==1){
            direction = -1;
            this.transform.position = left.position;
        }
        if(a==2){
            direction = 1;
            this.transform.position = right.position;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.Translate(Vector2.right*direction*speed);
        if(direction==-1 &&transform.position.x<right.position.x){
         Destroy(gameObject);
         exist = false;
        }
        if(direction==1 &&transform.position.x>left.position.x){
         Destroy(gameObject);
         exist = false;
        }
    }
}
