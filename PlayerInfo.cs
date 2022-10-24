using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private float hp;
    public float dmg = 1f;
    [SerializeField]
    private float AGI;
    [SerializeField]
    private float STR;
    [SerializeField]
    private float POW;

    public float getPOW()
    {
        return POW;
    }
    public float getdmg()
    {
        return dmg;
    }
    public float getAGI()
    {
        return AGI*0.12f;
    }
    public float getSTR()
    {
        return STR;
    }
    
    public void setAGI(float AGI)
    {
        this.AGI = AGI;
    }
    public void setSTR(float STR)
    {
        this.STR = STR;
    }
    public void setPOW(float POW)
    {
        this.POW = POW;
    }
  

}
