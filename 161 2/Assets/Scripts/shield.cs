using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet" || other.gameObject.tag == "enemybullet" || other.gameObject.tag =="enemy")
        {
            Destroy(gameObject);

        }
    }
}
