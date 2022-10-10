using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public List<GameObject> nearweapon = new List<GameObject>();
    public void addWeapon(GameObject weapon)
    {
        nearweapon.Add(weapon);
    }
    public void deleteweapon(GameObject weapon)
    {
        nearweapon.Remove(weapon);
    }
}
