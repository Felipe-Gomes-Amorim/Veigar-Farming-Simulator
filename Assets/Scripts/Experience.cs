using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{

    
    private Transform target;
    private float speed = 4;
    private float range = .1f;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private float value;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckPlayer() == false){
            if(CheckArea())
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }else{
            target.gameObject.GetComponent<Stats>().Receive(value);
            Destroy(gameObject);
        }
    }

    

    public bool CheckPlayer()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, whatIsPlayer);
        if (colliders.Length > 0) return true; 
        else return false; 
    }

    public bool CheckArea()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range * 10, whatIsPlayer);
        if (colliders.Length > 0) return true; 
        else return false; 
    }
}
