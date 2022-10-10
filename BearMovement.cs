using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class BearMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent aicontrol;
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

    public BearObject bearObject;
    [SerializeField] Canvas canvas;
    bool check = false;

    public bool checkdeath = false;
    
    void Start()
    {
        
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
            
            bearanimator.SetBool("Death", true);
            
            if(timeCounter2 <= 9)
            {
                timeCounter2 += Time.deltaTime;
            }
            else
            {
                if (checkdeath == true)
                {
                    checkdeath = false;
                    slider.value = 5;
                }
                bearanimator.SetBool("Death", false);
              
                DisplayPoolObject();
            }
        }
        else
        { 
            if (range.magnitude <= bearvision )
            {
                
                                
                canvas.enabled = true;
                slider.enabled = true;
                aicontrol.SetDestination(Player.transform.position);
                bearanimator.SetBool("WalkForward", true);

                if (range.magnitude <= 2f)
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
        }
        
    }
}
