using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    private int hp;
    private int maxhp;
    private float atk = 0.1f;

    public int getHP()
    {
        return hp;
    }
    public void setHP(int hp)
    {
        this.hp = hp;
    }
    public float getAtk()
    {
        return atk;
    }

}
