using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimation : MonoBehaviour
{
    private PlayerTrigger weaponlist;
    [SerializeField] AudioSource bearhit;
    [SerializeField] AudioSource playergethit;
    [SerializeField] AudioSource die;
    [SerializeField] AudioSource bearrun;
    
    public BearObject bearObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bearDeathSound()
    {
        die.enabled = true;
    }
    public void bearhitSound()
    {
        bearhit.enabled = true;
    }
    public void playergethitSound()
    {
        playergethit.enabled = true;
    }

    public void ResetSound()
    {
        bearhit.enabled = false;
        playergethit.enabled = false;
        die.enabled = false;
    }
    public void DisplayPoolObject()
    {
        for (int i = 0; i < bearObject.bearpool.Count; i++)
        {
            if (!bearObject.bearpool[i].activeInHierarchy)
            {
                bearObject.bearpool[i].SetActive(false);
            }
        }
    }
}
