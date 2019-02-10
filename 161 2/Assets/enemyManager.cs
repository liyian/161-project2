using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabList;
    public int offsetx=3;
    public int offsety=4;
    public int Column=11;//width
    public int Row=5; //height
    
    public float direction;
    public float old_direction;
    public float difficulty;
    public float fireRate;
    public float fireTime;
    public GameObject enemybullet;
    public float bullet_speed =20f;
    private Transform fire_position;
    private int rowcount=0;
    private int x2;
    private int y2;
    private List<List<enemy>> enemyGrid = new List<List<enemy>>();
    private List<enemy> AttackEnemy = new List<enemy>();
    
    void Awake(){
        old_direction  =direction= 1f;
    }
    void Start()
    {
        for(int x=0; x<Column; x++){ //horizontal width
            enemyGrid.Add(new List<enemy>());
            y2=0;
            rowcount=0;
            x2+=offsetx; //horizontal space between
            for(int y=0; y<Row; y++){   //vertical height
                
                if(rowcount<=1){ //y=0~1
                set_enemy(10,x,x2,y2,enemyPrefabList[0]);
                
                }
                else if(rowcount>1&&rowcount<=3){
                set_enemy(20,x,x2,y2,enemyPrefabList[0]);
                }
                else if(rowcount>=4){
                set_enemy(40,x,x2,y2,enemyPrefabList[0]);
                }
            rowcount++;
            y2+=offsety; //vertical space between
            }
        }
    }
    
    private void set_enemy(int Score,int x, int x2, int y2, GameObject enemyPrefab){
        Vector2 spawnPosition = new Vector2(x2-17f,y2);
        GameObject newenemy = Instantiate(enemyPrefab, this.transform);
        enemy enemyScript = newenemy.GetComponent<enemy>();
        enemyScript.score =Score;
        newenemy.transform.localPosition = spawnPosition;
        enemyGrid[x].Add(enemyScript);
    }
    // Update is called once per frame
    void Update()
    {
        direction = enemy.direction;
        difficulty = enemy.difficulty;
        StartCoroutine("Move");
        for(int x=0; x<Column; x++){
            for(int y=0; y<Row; y++){
                if(enemyGrid[x][y]!=null){
                
                Debug.Log((x,y));
                
                 AttackEnemy.Add(enemyGrid[x][y]);
                 break;
                }
            }
        }
        fireRate = Random.Range(1f,5f);
        fireTime +=Time.deltaTime;
        if(fireTime>fireRate){
            int index = Random.Range(1,AttackEnemy.Count);
            fire_position =AttackEnemy[index].transform.GetChild(0);
            GameObject b = Instantiate(enemybullet,fire_position.position,Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(Vector2.down*bullet_speed,ForceMode2D.Impulse);
            fireTime =Time.deltaTime;//reset time
            }
    }
    
    IEnumerator Move(){
        direction = enemy.direction;
        difficulty = enemy.difficulty;
        transform.Translate(Vector2.right*difficulty*Time.deltaTime*direction);
        if(transform.childCount<=0){
            StopCoroutine("Move");
            //TODO  win  enemy all dead
            yield break;
        }
        if(old_direction != direction){
            old_direction = direction;
            transform.Translate(Vector2.down*1f);
        }
        
        yield return new WaitForSeconds(2f);
        
        
    }
}
