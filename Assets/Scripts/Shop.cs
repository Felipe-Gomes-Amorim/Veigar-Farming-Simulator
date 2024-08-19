using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    
    public string[] items;
    [SerializeField]
    private int[] selected;
    public Sprite[] itemSprites;
    public TMP_Text[] itemsText;
    public Image[] itemsIcons;
    private GameObject shops;

    private Stats stats;
    [SerializeField]
    private int[] oldRand;
    
    
    // Start is called before the first frame update
    void Start()
    {
        oldRand[0] = 10;
        stats = GetComponent<Stats>();
        shops = GameObject.Find("ExpTable");
        //Consertei o erro q ta aqui me agradeça dps B)
        shops.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open(){
        Time.timeScale = 0;
        shops.SetActive(true);
        //isso aquivai setar as abas como items aleatorios nengue
        for (int i = 0; i < items.Length; i++)
        {
            //isso aqui ta funcionando na maior maracutaia do mundo
            int rand = Random.Range(0,3); 
            Debug.Log("rand:" + rand + "/ oldRand:" + oldRand);
            while(oldRand[0] == rand || oldRand[1] == rand )
                rand = Random.Range(0,3); 
            selected[i] = rand;
            itemsIcons[i].sprite = itemSprites[rand];
            itemsText[i].text = items[rand]; 
            oldRand[i] = rand;
            
        }

    }

    public void Close(int click){
        //eu mexi noq vc mandou nao mexer, agora sofra pq eu consertei o problema
        stats.GetPowerUp(selected[click]);
        shops.SetActive(false);
        Time.timeScale = 1;

    }

    
}
