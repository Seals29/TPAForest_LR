using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider sliderhp;
    [SerializeField]
    private Slider sliderxp;

    PlayerInfo playerinfo;
    [SerializeField]
    private PlayerAnimator playeranimator;

    [SerializeField] private PlayerAnimator enemy;
    [SerializeField]
    Text stattext;

    [SerializeField]
    Text STRtext;

    [SerializeField]
    Text AGItext;

    [SerializeField]
    Text POWtext;

    void Start()
    {
        
        playerinfo = GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        STRtext.text = "" + playerinfo.getSTR();
        AGItext.text = "" + playerinfo.getAGI() / 0.12f;
        POWtext.text = "" + playerinfo.getPOW();
        stattext.text = "" +playeranimator.lvlupcount;

        sliderhp.maxValue = playeranimator.maxHP + (playerinfo.getSTR() * 2f);
        sliderxp.maxValue = 10 + (playerinfo.getSTR());
        
        sliderhp.value = playeranimator.currhp + (playerinfo.getSTR() * 2f);
    }
}
