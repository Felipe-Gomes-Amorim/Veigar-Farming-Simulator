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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= cooldown){
        type = Random.Range(0,2);
        Instantiate(enemy[type], transform.position, Quaternion.identity);
        timer = 0;
        } else timer += Time.deltaTime;
    }
}
