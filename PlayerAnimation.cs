using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerTrigger weaponlist;
    [SerializeField] AudioSource tonjok;
    [SerializeField] AudioSource tonjok2;
    [SerializeField] AudioSource run;
    [SerializeField] AudioSource die;
    [SerializeField] AudioSource yata;
    [SerializeField] AudioSource sword1;
    [SerializeField] AudioSource Levelup;
    [SerializeField] AudioSource rollsfx;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void rollsound()
    {
        rollsfx.enabled = true;
    }
    public void Sword1Sound()
    {
        sword1.enabled = true;
    }
    public void YataaSound()
    {
        yata.enabled = true;
    }
    public void TonjokSound()
    {
        tonjok.enabled = true;
    }
    public void Tonjok2Sound()
    {
        tonjok2.enabled = true;
    }
    public void DieSound()
    {
        die.enabled = true;
    }

    public void LevelupSound()
    {
        Levelup.enabled = true;
    }
    public void ResetSound()
    {
        tonjok.enabled = false;
        yata.enabled = false;
        sword1.enabled = false;
        rollsfx.enabled = false;
        Levelup.enabled = false;
    }

}
