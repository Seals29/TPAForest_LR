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
    public float enemyXP;

    public float  getHp()
    {
        return bearhp;
    }
    public float getXP()
    {
        return enemyXP;
    }
    public float bearAtk()
    {
        return bearatk;
    }
    public void setHp(float bearhp)
    {
        this.bearhp = bearhp;
    }
    public void Setslider()
    {
        sliderhp.value = bearhp;
    }
    void Start()
    {
        sliderhp.maxValue = bearhp;
        sliderhp.value = bearhp;
    }

    // Update is called once per frame
    void Update()
    {
        

        //sliderhp.value = bearhp;

    }
}
