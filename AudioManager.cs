using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip hit;
    public AudioClip enemyHit;
    public AudioClip win;
    public AudioClip GUI;

    private AudioSource audioSource;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playsound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void playJump() { playsound(jump); }
    public void playCoin() { playsound(coin); }
    public void playHit() { playsound(hit); }
    public void playenemyHit() { playsound(enemyHit); }
    public void playWin() { playsound(win); }
    public void playGUI() { playsound(GUI); }
}
