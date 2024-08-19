using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Stats stats;
    private Transform target;
    private float range = .2f;
    [SerializeField]
    private LayerMask whatIsPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckPlayer() == false){
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, stats.speed * Time.deltaTime);
        }
    }

    

    public bool CheckPlayer()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, whatIsPlayer);
        if (colliders.Length > 0) return true; 
        else return false; 
    }
}
