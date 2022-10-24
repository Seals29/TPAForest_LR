using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Slider slider;
    [SerializeField]
    Animator animators;
    [SerializeField]
    RawImage rawimage;  
    // Update is called once per frame
    void Update()
    {

        if (slider.value <= 0)
        {
            
            animators.SetTrigger("Fadeout");
            StartCoroutine(tempasd());
        }
    }
    IEnumerator tempasd()
    {
        yield return new WaitForSeconds(4f);
        AsyncOperation scene = SceneManager.LoadSceneAsync(2);
    }
}
