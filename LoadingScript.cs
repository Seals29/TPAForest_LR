using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public SceneManager scenemanager;
    void Start()
    {
        StartCoroutine(Loading());
    }

    // Update is called once per frame
    IEnumerator Loading()
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(1);
        while (!scene.isDone)
        {
            float loadprogress = Mathf.Clamp01(scene.progress / 0.4f);
            slider.value = loadprogress;
            yield return null;// biar ga dalam 1 frame cuman manggil IEnumerator sekali
        }
    }
    void Update()
    {
        
    }
}
