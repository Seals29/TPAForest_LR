using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAreaWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTrigger trigger;
    [SerializeField] private EnemyTrigger trigger2;
    [SerializeField] private TerrainTrigger trigger3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            trigger3.addTerrain(other.gameObject);
        }
        if (other.gameObject.CompareTag("Weapon"))
        {
            
            trigger.addWeapon(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            trigger2.addEnemies(other.gameObject);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            trigger3.deleteTerrain(other.gameObject);
        }
        if (other.gameObject.CompareTag("Weapon"))
        {
            //
            trigger.deleteweapon(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //
            trigger2.deleteEnemies(other.gameObject);
        }
    }
}
