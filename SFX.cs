using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioClip AC;
    float Volume;
    int kill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayClip(AudioClip clip, float volume, int killTime)
    {
        AudioSource AS = new GameObject().AddComponent<AudioSource>();
        AS.clip = clip;
        AS.volume = volume;
        if (!AS.isPlaying)
        {
            AS.Play();
        }
        Destroy(AS.gameObject, killTime);
    }
}
