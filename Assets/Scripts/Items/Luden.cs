using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Luden : MonoBehaviour
{
    
     
    private float lifeTime;
    
    public float damage;
   
   

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(lifeTime < 2f)
            lifeTime += Time.deltaTime;
        else
            Destroy(gameObject);

        

    }

    
}
