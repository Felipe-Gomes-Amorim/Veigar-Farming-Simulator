using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField]
    private Sprite[] powerUpSprite;
    public int[] powerUps;
    [SerializeField]
    private Image[] powerUpIcon;
    private int slots;
    [SerializeField]
    private TMP_Text[] powerUpLevels;
    [SerializeField]
    private TMP_Text[] statsIndex;
    [SerializeField]
    private Slider[] cooldowns;
    [SerializeField]
    private int[] cooldownsIndex;
    private PlayerAttack pAttack;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shop = GetComponent<Shop>();
        expCap = 2;
        if(gameObject.CompareTag("Player")){
            GetPowerUp(1);
            pAttack = GetComponent<PlayerAttack>();
        }
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Player")){
            cooldowns[0].value = pAttack.timer[cooldownsIndex[0] -1];
            cooldowns[0].maxValue = pAttack.cooldown[cooldownsIndex[0] -1];
            cooldowns[1].value = pAttack.timer[cooldownsIndex[1]];
            cooldowns[1].maxValue = pAttack.cooldown[cooldownsIndex[1]];
            cooldowns[2].value = pAttack.timer[cooldownsIndex[2]];
            cooldowns[2].maxValue = pAttack.cooldown[cooldownsIndex[2]];
        }
        
        if(exp >= expCap) LevelUp();
        
        

    }
    public void GetPowerUp(int num){
        //esqueci totalmente como isso funciona B)
        int z = 0;
        if(powerUps[num] == 0){
            cooldownsIndex[slots] = num;
            powerUpIcon[slots].sprite = powerUpSprite[num];
            powerUps[num]++;
            powerUpLevels[slots].text = "" + powerUps[num];
            slots++;
        }
        else{
            powerUps[num]++;
            for (int i = 0; i < powerUps.Length; i++)
            {
                if(powerUpIcon[i].sprite == powerUpSprite[num])
                    powerUpLevels[z].text = "" + powerUps[num];
                z++;
            }
                


            
            
        }
        
        
        
    }

    public void Receive(float xp){
        exp += xp;

    }

    private void LevelUp(){
        exp = 0;
        expCap *= 1.2f;
        lvl++;
        UpdateUI();
        shop.Open();

    }

    public void UpdateUI(){
        if(gameObject.CompareTag("Player"))
        statsIndex[0].text = ""  + attack;

    }

   
}
