using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private bool player;
    private Stats stats;
    private Stats playerStats;
    [SerializeField]
    private GameObject exp;
    [SerializeField]
    private LayerMask whatIsEnemy;
    private float range = .3f;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        stats = GetComponent<Stats>();
        playerStats = GameObject.Find("Player").GetComponent<Stats>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("e"))
            Take();
        if(stats.life <= 0.01){
            if(player == false){
                Instantiate(exp, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }


        //colisor de dano exclusivo do player pq era a unica forma de fazer isso
        Collider2D[] enemyFinder =  Physics2D.OverlapCircleAll(transform.position, range, whatIsEnemy);
        foreach (Collider2D col in enemyFinder){
            if (player){
                stats.life -= (col.gameObject.GetComponent<Stats>().attack) * Time.deltaTime; 
                Take();
            }
           
    

        }
        
    }

    private void Take(){
        sprite.color = new Color(1, 0, 0);
        StartCoroutine(Recover());
    }

    private IEnumerator Recover(){
        yield return new WaitForSeconds(1f);
        sprite.color = new Color(1, 1, 1);
    }

    public void OnTriggerStay2D(Collider2D other) {
        
        if(player){
            

        }else{
            if (other.gameObject.CompareTag("Projectile")){
                Projectiles proj = other.gameObject.GetComponent<Projectiles>();
                stats.life -= proj.damage * Time.deltaTime; 
                if(proj.GetTypes() == 1){
                        playerStats.attack++;
                        playerStats.UpdateUI();
                    }
                proj.life --;
                Take();
            }
        }

    }
   
    
    
   
    
}
