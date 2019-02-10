using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float offset=2f;
    public int Column=11;//width
    public int Row=5; //height
    private List<List<enemy>> enemyGrid = new List<List<enemy>>();
    void Start()
    {
        for(int x=0; x<Column; x++){ //horizontal width
            enemyGrid.Add(new List<enemy>());
            for(int y=0; y<Row; y++){   //vertical height
                if(y<=2){
                set_enemy(10,x,y,enemyPrefab);
            
                }
                else if(y>2&&y<=4){
                set_enemy(20,x,y,enemyPrefab);
                }
                else{
                set_enemy(30,x,y,enemyPrefab);
                }
            
            }
        }
    }
    
    private void set_enemy(int Score, int x, int y, GameObject enemyPrefab){
        Vector2 spawnPosition = new Vector2(x,y);
        GameObject newenemy = Instantiate(enemyPrefab, this.transform);
        enemy enemyScript = newenemy.GetComponent<enemy>();
        enemyScript.score =Score;
        newenemy.transform.localPosition = spawnPosition;
        enemyGrid[x].Add(enemyScript);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
