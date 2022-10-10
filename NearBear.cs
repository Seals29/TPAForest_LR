using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NearBear : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider sliderhp;
    [SerializeField]
    private EnemyInfo bearinfo;
    public float bearhp = 50f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderhp.maxValue = bearhp;

        sliderhp.value = bearinfo.getHP();

    }
}
