using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour
{
    
    public float maxLife;
    public float life;
    public float speed;
    public float attack;
    public int projectileLife;

    public float exp;
    public int lvl;
    public float expCap;

    public float timer;

    private Shop shop;

    public int[] powerUps;
    
    // Start is called before the first frame update
    void Start()
    {
        shop = GetComponent<Shop>();
        expCap = 2;
        
    }

    // Update is called once per frame
    void Update()
    {

        
       if(exp >= expCap) LevelUp();
       

    }

    public void Receive(float xp){
        exp += xp;

    }

    private void LevelUp(){
        exp = 0;
        expCap *= 1.2f;
        lvl++;
        shop.Open();
    }
}
