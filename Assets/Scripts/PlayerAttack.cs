using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsEnemy;
    private float range = 4f;
    [SerializeField]
    private float[] cooldown;
    [SerializeField]
    private float[] timer;
    [SerializeField]
    private GameObject[] projectiles;
    private Stats stats;

    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {

       
        Collider2D[] enemyFinder =  Physics2D.OverlapCircleAll(transform.position, range, whatIsEnemy);
        foreach (Collider2D col in enemyFinder){
           
           
        //você está vendo a maior maracutaia de todas na sua frente
        if(stats.powerUps[0] >= 0){
            if(timer[0] <= cooldown[0])timer[0] += Time.deltaTime;
            else StartCoroutine(Attack(col.transform, 0));
        }
        if(stats.powerUps[2] > 0){
            if(timer[2] <= cooldown[2])timer[2] += Time.deltaTime;
            else StartCoroutine(Attack(col.transform, 2));
        }





        }
        
        
        


    }

    private IEnumerator Attack(Transform targeting, int types){
        timer[types] = 0;
        
            GameObject shooting = Instantiate(projectiles[types], transform.position, Quaternion.identity);
            //escolhe o alvo 
            shooting.GetComponent<Projectiles>().target = targeting;
            //calcula o dano (o resto do calculo ta no Projectiles pq precisava de uma ref la n sei oq)
            shooting.GetComponent<Projectiles>().damage += stats.attack;
            //quanto de vida tem o projetil(quantos ele tem que bater pra sumir)
            shooting.GetComponent<Projectiles>().life = stats.projectileLife + stats.powerUps[1];
            //checa se tem luden
            if(stats.powerUps[0] > 0 && types == 0)
                shooting.GetComponent<Projectiles>().luden = true;
        
        yield return new WaitForSeconds(cooldown[types]);
        
    }
}
