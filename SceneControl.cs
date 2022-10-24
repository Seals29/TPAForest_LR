using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] AudioSource ClickSFX;
    float timeCounter= 0f;
    public void PlayGame()
    { 
        animator.SetTrigger("Fadeout");
        ClickSFX.Play();
        StartCoroutine(Clicks());
    }
    IEnumerator Clicks()
    {
        
        
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(3);
        
        
    }
}
