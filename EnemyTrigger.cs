using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> nearenemies = new List<GameObject>();
    public void addEnemies(GameObject enemy)
    {
        nearenemies.Add(enemy);
    }
    public void deleteEnemies(GameObject enemy)
    {
        nearenemies.Remove(enemy);
    }
}
