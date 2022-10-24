using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STRbutton : MonoBehaviour
{
    [SerializeField]
    PlayerInfo playerinfo;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource ClickSFX;
    [SerializeField] PlayerAnimator playerAnimator;
    float timeCounter = 0f;
   public void STRClick()
    {
        Debug.Log("ASD");
        playerinfo.setSTR(playerinfo.getSTR() + 1);
        playerAnimator.lvlupcount -= 1;
    }
    public void AGIClick()
    {
        playerinfo.setAGI((playerinfo.getAGI() / 0.12f) + 1);
        playerAnimator.lvlupcount -= 1;
    }
    public void POWClick()
    {
        playerinfo.setPOW(playerinfo.getPOW() + 1);
        playerAnimator.lvlupcount -= 1;
    }
    
   
    
}
