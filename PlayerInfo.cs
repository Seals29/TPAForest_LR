using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private float hp;
    public float dmg = 1f;
    public float AGI;
    public float STR;

    public float getdmg()
    {
        return dmg;
    }
    public float getAGI()
    {
        return AGI;
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
  

}
