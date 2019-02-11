using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUI : MonoBehaviour
{
    public float addscore;
    private float currentscore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UpdateScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator UpdateScore(){
        while(true){
        //make socre raise one by one
            if(addscore >0){
            addscore -=1;
            currentscore +=1;
            this.GetComponent<Text>().text = currentscore.ToString("000");
            yield return null;
            }
            else{
            yield return new WaitForSeconds(0.2f);
            }
        }
        
    }
}
