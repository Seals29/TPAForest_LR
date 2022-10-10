using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordArea : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;
    [SerializeField]Transform Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 range = Player.position - transform.position;
        if (range.magnitude <= 35)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
