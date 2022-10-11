using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] audioSource;
    public static AudioManager I { get; private set; }

    AudioClip attackClip;
    AudioClip angerClip;
    AudioClip flashClip;
    AudioClip startWorkClip;
    AudioClip mainBGM;
    AudioClip titleBGM;

    public static AudioManager GetI()
    {
        if(I == null)
        {
            GameObject obj = new GameObject("AudioManager");
            I = obj.AddComponent<AudioManager>();
            
            I.gameObject.AddComponent<AudioSource>();
            I.gameObject.AddComponent<AudioSource>();

            DontDestroyOnLoad(obj);
        }
        return I;
    }

    private void Awake()
    {
        if(I == null)
        {
            I = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        attackClip = Resources.Load<AudioClip>("Sound/SE/Attack");
        angerClip = Resources.Load<AudioClip>("Sound/SE/Anger");
        flashClip = Resources.Load<AudioClip>("Sound/SE/Flash");
        startWorkClip = Resources.Load<AudioClip>("Sound/SE/Flash");

        mainBGM = Resources.Load<AudioClip>("Sound/Main");
        titleBGM = Resources.Load<AudioClip>("Sound/Title");
        

    }

    private void OnDestroy()
    {
        if(I == this)
        {
            I = null;
        }
    }

    private void Start()
    {
        audioSource = GetComponents<AudioSource>();
        
        audioSource[0].clip = mainBGM;
        audioSource[0].loop = true;
        audioSource[1].clip = titleBGM;
        
    }
    public void FlashSE()
    {
        audioSource[0].PlayOneShot(flashClip);
    }
    public void AttackSE()
    {
        audioSource[0].PlayOneShot(attackClip);
    }

    public void AngerSE()
    {
        audioSource[0].PlayOneShot(angerClip);
    }
    public void StartWorkSE()
    {
        audioSource[0].PlayOneShot(startWorkClip);
    }

    public void MainBGM()
    {
        audioSource[0].Play();
    }
    public void TitleBGM()
    {
        audioSource[1].Play();
    }

    public void StopBGM()
    {
        audioSource[1].Stop();
    }

    public void StopBGM_2()
    {
        audioSource[0].Stop();
    }
}
