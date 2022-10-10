using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHP(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

    }
    public void SetHP(int hp)
    {
        slider.value = hp;
        
    }
    // Start is called before the first frame update
    
}
