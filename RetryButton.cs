using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource click;
    float timeCounter2 = 0;
    private void Update()
    {
        if (click.enabled == true&&timeCounter2<=2)
        {
            timeCounter2 += Time.deltaTime;
        }
        else
        {
            timeCounter2 = 0;
            click.enabled = false;
        }
    }

    public void PlayGame()
    {
        click.enabled = true;
        new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
    
}
