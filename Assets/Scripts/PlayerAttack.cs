using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsEnemy;
    private float range = 4f;
    public float[] cooldown;
    public float[] timer;
    [SerializeField]
    private GameObject[] projectiles;
    private Stats stats;
    private Vector2 lastDirection;
    private int lastHorizontal;
    private int lastVertical;
    private bool mobile;
    [SerializeField]
    private Camera mainCamera;
    private Vector2 screenPos;
    private Vector2 worldPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {

        timer[0] += Time.deltaTime;
        timer[2] += Time.deltaTime;
        Collider2D[] enemyFinder =  Physics2D.OverlapCircleAll(transform.position, range, whatIsEnemy);
        foreach (Collider2D col in enemyFinder){
           
           
        //você está vendo a maior maracutaia de todas na sua frente
        if(stats.powerUps[0] >= 0 && timer[0] > cooldown[0]){
            StartCoroutine(Attack(col.transform, 0));
            timer[0] = 0;
        }
        if(stats.powerUps[2] > 0 && timer[2] > cooldown[0]){
            StartCoroutine(Attack(col.transform, 2));
            timer[2] = 0;
        }

        }
        //vamo la com mais uma maracutaia, seguinte:
        //aqui fica a versão da mira pra mobile e controle, que ele mira pra onde tu ta olhando
        if(mobile){
            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){} 
            else{   lastHorizontal = (int) Input.GetAxisRaw("Horizontal");
                    lastVertical =(int) Input.GetAxisRaw("Vertical");
            }
            lastDirection = new Vector2(transform.position.x + lastHorizontal, transform.position.y + lastVertical);
        }
        //aqui é na versão pc, pra mirar no mouse, que assim nao fica durasso ne :P
        else{
           screenPos =  Input.mousePosition;
           worldPosition = Camera.main.ScreenToWorldPoint(screenPos);
           lastDirection = worldPosition;
        }
        
    }
    

    private IEnumerator Attack(Transform targeting, int types){
        timer[types] = 0;
        
            GameObject shooting = Instantiate(projectiles[types], transform.position, Quaternion.identity);
            //escolhe o alvo 
            if(types == 0)
                shooting.GetComponent<Projectiles>().target = lastDirection;
            else
                shooting.GetComponent<Projectiles>().target = targeting.position;
            //calcula o dano (o resto do calculo ta no Projectiles pq precisava de uma ref la n sei oq)
            shooting.GetComponent<Projectiles>().damage += stats.attack;
            //quanto de vida tem o projetil(quantos ele tem que bater pra sumir)
            shooting.GetComponent<Projectiles>().life = stats.projectileLife + (stats.powerUps[1] - 1);
            //checa se tem luden
            if(stats.powerUps[0] > 0 && types == 0)
                shooting.GetComponent<Projectiles>().luden = true;
        
        yield return new WaitForSeconds(cooldown[types]);
        
    }
    public void ChangeMode(){
        mobile = !mobile;

    }
}
