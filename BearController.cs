using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BearController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public EnemyInfo enemy;
    public Animator animator;
    void Start()
    {
        enemy = GetComponent<EnemyInfo>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
