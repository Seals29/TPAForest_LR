using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFootStep : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public List<GameObject> CurrTerrain = new List<GameObject>();
    public void addTerrain(GameObject curr)
    {
        CurrTerrain.Add(curr);
    }
    public void deleteTerrain(GameObject curr)
    {
        CurrTerrain.Remove(curr);
    }
}
