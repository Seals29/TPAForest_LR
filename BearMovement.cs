using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class BearMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent aicontrol;
    public Transform Player;
    public float bearvision = 20;
    public float bearhp = 5f;
    public Slider slider;
    public Animator bearanimator;
    private float timeCounter = 0;
    private float timeCounter2 = 0;
    private EnemyInfo bear;
    [SerializeField] PlayerAnimator players;
    [SerializeField]
    private float atkspeed = 2f;
    public float beardmg = 1f;
    private float actTimeCounter = 15f;
    public BearObject bearObject;
    [SerializeField] Canvas canvas;
    bool check = false;
    public bool checkdeath = false;
    [SerializeField]
    private EnemyInfo bearinfo;
    [SerializeField]
    private EnemyInfo WolfInfo;
    Cinemachine.CinemachineFreeLook cinema;
    private float  startposition;
    private float currposition;
    [SerializeField]
    Slider sliderxp;
    public int lvlupcount =0 ;
    bool checkwalked;
    void Start()
    {
        sliderxp.value -= 1;
        aicontrol = GetComponent<NavMeshAgent>();
        startposition = transform.position.y;
    }

    public void DisplayPoolObject()
    {
        for (int i = 0; i < bearObject.bearpool.Count; i++)
        {
            if (!bearObject.bearpool[i].activeInHierarchy)
            {
                bearObject.bearpool[i].SetActive(true);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
       //bearObject.bearpool.
        Vector3 range= Player.position - transform.position; //jarak posisi player dan beruang
        if (slider.value <= 0)
        {
            Player.gameObject.GetComponentInChildren<EnemyTrigger>().deleteEnemies(gameObject);
            bearanimator.SetBool("Eat", false);
            bearanimator.SetBool("Death", true);
            
            if (timeCounter2 <= 9)
            {
                if (timeCounter2 >= 5f)
                {

                    sliderxp.value += GetComponentInParent<BearHPControl>().getXP();
                    checkdeath = false;
                    timeCounter2 = 0;
                    slider.value = GetComponentInParent<BearHPControl>().getHp();
                    bearanimator.SetBool("Death", false);
                    transform.parent.gameObject.SetActive(false);
                    

                }
                timeCounter2 += Time.deltaTime;
            }
            else
            {
                //this.transform.localPosition = new Vector3(0, -100f, 0);
                timeCounter2 = 0;
                if (checkdeath == true)
                {
                    checkdeath = false;

                    
                }
                

            }
        }
        else
        {
            
            



            if (range.magnitude <= bearvision )
            {
                checkwalked = true;
                bearanimator.SetBool("Eat", false);
                bearanimator.SetBool("Sleep", false);
                bearanimator.SetBool("Sit", false);

                canvas.enabled = true;
                slider.enabled = true;
                aicontrol.SetDestination(Player.transform.position);
                bearanimator.SetBool("WalkForward", true);

                if (range.magnitude <= 8f)
                {
                    bearanimator.SetBool("WalkForward", false);
                    if (timeCounter <= atkspeed)
                    {
                        timeCounter += Time.deltaTime;
                    }
                    else
                    {
                        timeCounter = 0f;
                        players.currhp -= 1;
                        bearanimator.SetTrigger("Attack1");
                        bearanimator.SetTrigger("Attack2");
                    }
                }
                else
                {
                    //bearanimator.SetBool("WalkForward", false);
                    canvas.enabled = false;
                }

            }
            else
            {
                bearanimator.SetBool("WalkForward", false);
                float rand = Random.Range(0, 2);
                if (actTimeCounter <= 15)
                {
                    actTimeCounter += Time.deltaTime;
                }
                else
                {
                    actTimeCounter = 0f;

                    bearanimator.SetBool("Sleep", true);
                  
                }
                
            }
        }
        
    }
}
