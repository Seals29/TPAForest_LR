using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    public void PlayGame()
    {
        animator.SetTrigger("Fadeout");
        SceneManager.LoadScene(3);
    }
}
