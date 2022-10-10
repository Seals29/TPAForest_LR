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


    [SerializeField]
    private PlayerAnimator playeranimator;

    [SerializeField] private PlayerAnimator enemy;

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

        sliderhp.maxValue = playeranimator.maxHP;
        sliderxp.maxValue = 100;
        
        sliderhp.value = playeranimator.currhp;
    }
}
