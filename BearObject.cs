using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BearObject : MonoBehaviour
{
    public static BearObject instance;
    public List<GameObject> bearpool = new List<GameObject>();
    public int maxBear = 3;
    [SerializeField]
    private GameObject Bear;
    [SerializeField]
    Text text;
    private int lvl = 1;
    
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
        lvl = 1;
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
    private void Update()
    {
        GameObject temp = instance.ObjectPooling();
        if (temp != null)
        {
            StartCoroutine(waitting());
        }
    }
    IEnumerator waitting()
    {
        
        GameObject temp = instance.ObjectPooling();
        
        yield return new WaitForSeconds(10f);

        
        temp.SetActive(true);

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
    public GameObject ObjectPooling()
    {
        for (int i = 0; i < bearpool.Count; i++)
        {
            if (!bearpool[i].activeInHierarchy)
            {
                return bearpool[i];
            }
        }
        return null;
    }
    public void setBear()
    {
        gameObject.SetActive(false);
    }
}
