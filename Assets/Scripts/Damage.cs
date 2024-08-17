using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private bool player;
    private Stats stats;
    [SerializeField]
    private GameObject exp;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        stats = GetComponent<Stats>();

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
            if (other.gameObject.CompareTag("Enemy")){
                stats.life -= (other.gameObject.GetComponent<Stats>().attack) * Time.deltaTime; 
                Take();
        }

        }else{
            if (other.gameObject.CompareTag("Projectile")){
                stats.life -= other.gameObject.GetComponent<Projectiles>().damage * Time.deltaTime; 
                
                other.gameObject.GetComponent<Projectiles>().life --;
                Take();
            }
        }

    }
   
    
}
