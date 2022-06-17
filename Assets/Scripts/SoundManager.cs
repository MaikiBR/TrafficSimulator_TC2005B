using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip buttonHitSound, gameOver, polarState, newLion, traffic;
    static AudioSource audioSrc; 

    // Start is called before the first frame update
    void Start()
    {
        buttonHitSound = Resources.Load<AudioClip>("Clic"); 
        traffic = Resources.Load<AudioClip>("TRAFFIC");
        gameOver = Resources.Load<AudioClip>("Over");
        newLion = Resources.Load<AudioClip>("");
        traffic = Resources.Load<AudioClip>("");

        audioSrc = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Clic":
                //audioSrc.Stop(); 
                audioSrc.PlayOneShot(buttonHitSound);
                break;
            case "Traffic":
                //audioSrc.Stop();
                //audioSrc.clip = traffic;
                audioSrc.PlayOneShot(buttonHitSound);
                audioSrc.loop = true;
                break;
            //case "Over":
            //    audioSrc.Stop();
            //    audioSrc.PlayOneShot(gameOver);
            //    break;
                //case "":
                //    audioSrc.loop = true;
                //    audioSrc.Play();
                //    break;
                //case "":
                //    audioSrc.loop = true;
                //    audioSrc.Play();
                //    break;
        }
    }
}
