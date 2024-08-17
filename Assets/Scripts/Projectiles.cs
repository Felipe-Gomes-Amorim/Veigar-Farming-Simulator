using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    
    private float speed = 20; 
    private float defaultSpeedMultiplier = 30;   
    [HideInInspector]
    public Transform target; 
    private float lifeTime;
    [SerializeField]
    private float lifeTotal;
    private Rigidbody2D rb;
    public float damage;
    public int life;
    [SerializeField]
    private int type;
    public bool luden;

    [SerializeField]
    private GameObject ludenObj;
    [SerializeField]
    private LayerMask whatIsEnemy;
    private Stats stats;

    
   

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<Stats>();
        damage += stats.powerUps[type] * 10;
        rb = GetComponent<Rigidbody2D>();
        if(type == 1 || type == 2)    
            transform.right = target.position - transform.position;
        transform.localScale = new Vector3((stats.powerUps[type] / 5) + 1, (stats.powerUps[type] / 5) + 1, (stats.powerUps[type] / 5) + 1);
    }

    // Update is called once per frame
    void Update()
    {
    
        if(lifeTime < lifeTotal)
            lifeTime += Time.deltaTime;
        else
            Destroy(gameObject);

        if(life <=0 && type == 1)
            Destroy(gameObject);

        
            
           
        
    }

    private void FixedUpdate() {
        if(type == 1)   
        rb.velocity = (transform.right * (speed * defaultSpeedMultiplier)) * Time.deltaTime;
        else{
            rb.velocity = transform.right * 0f;
        }
    }

    
    
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")){
            if(luden)
                Instantiate(ludenObj, transform.position, Quaternion.identity);
            stats.attack++;

        }
    }
}
