using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BearHPControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Slider sliderhp;
    [SerializeField]
    public EnemyInfo bearinfo;
    public float bearhp = 4f;
    public float bearatk = 1f;

    public float  getHp()
    {
        return bearhp;
    }
    public float bearAtk()
    {
        return bearatk;
    }
    public void setHp(float bearhp)
    {
        this.bearhp = bearhp;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderhp.maxValue = bearhp;

        //sliderhp.value = bearinfo.getHP();

    }
}
