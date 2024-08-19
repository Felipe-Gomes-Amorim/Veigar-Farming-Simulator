using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float timer;
    private float cooldown = 1;
    [SerializeField]
    private GameObject[] enemy;
    private int type;
    private Life life;

    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.Find("Player").GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life.GetTimeElapsed() > 60)
            cooldown = .7f;
        if(life.GetTimeElapsed() > 120)
            cooldown = .5f;   
        if(life.GetTimeElapsed() > 180)
            cooldown = .3f;   



        if(timer >= cooldown){
        type = Random.Range(0,enemy.Length);
        Instantiate(enemy[type], transform.position, Quaternion.identity);
        timer = 0;
        } else timer += Time.deltaTime;
    }
}
