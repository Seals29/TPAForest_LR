using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearObject : MonoBehaviour
{
    public static BearObject instance;
    public List<GameObject> bearpool = new List<GameObject>();
    private int maxBear = 3;
    [SerializeField]
    private GameObject Bear;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxBear; i++)
        {
            GameObject eachbear = Instantiate(Bear);
            eachbear.SetActive(true);
            bearpool.Add(eachbear);
            //Rigidbody rigid = eachbear.GetComponent<Rigidbody>();
            //rigid.useGravity = true;
            //rigid.isKinematic = false;
            //eachbear.GetComponent<MeshCollider>().enabled = true;
            //eachbear.transform.localPosition = Vector3.zero;
        }
    }

    // Update is called once per frame
    public void DisplayPoolObject()
    {
        for (int i = 0; i < bearpool.Count; i++)
        {
            if (!bearpool[i].activeInHierarchy)
            {
                bearpool[i].SetActive(true);
            }
        }
    }
    public void setBear()
    {
        gameObject.SetActive(false);
    }
}
