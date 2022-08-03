using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    [SerializeField] AudioSource[] vfx;
    [SerializeField] AudioSource bgm;

    bool isBGMPlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        isBGMPlayed = false;
        GameEvents.instance.triggerSoundEffect += TriggerSoundEffect;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isBGMPlayed && GameEvents.isStart)
        {
            PlayBGM();
            isBGMPlayed = true;
        }
    }

    public void TriggerSoundEffect(int value)
    {
        if (!GameEvents.isStart)
            return;
        if(value < vfx.Length && value >= 0)
            vfx[value].Play();
    }

    public void PlayBGM()
    {
        bgm.Play();
    }

    private void OnDestroy()
    {
        GameEvents.instance.triggerSoundEffect -= TriggerSoundEffect;

    }

}
