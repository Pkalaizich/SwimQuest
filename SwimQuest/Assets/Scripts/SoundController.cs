using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get => instance; }
    FMOD.Studio.EventInstance MasterTrack;
    FMOD.Studio.EventInstance UnderWater;
    private float cooldownChest =0;
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        MasterTrack = FMODUnity.RuntimeManager.CreateInstance("event:/background/music");
        UnderWater = FMODUnity.RuntimeManager.CreateInstance("event:/background/underwater");
        MasterTrack.start();
    }

    private void Update()
    {
        cooldownChest -= Time.deltaTime;
}

    public void ChangeParameter1()
    {
        MasterTrack.setParameterByName("underwater", 1f, true);
    }
    public void ChangeParameter2()
    {
        MasterTrack.setParameterByName("underwater", 0f, true);
    }

    public void KeySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/kyes");
    }
    public void ChestSound()
    {
        if (cooldownChest <=0)
        {
            cooldownChest = 1f;
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/chest");
        }
        
    }
    public void BubbleSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/bubble");
    }

    public void HurtSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/damage");
    }

    public void Stop()
    {
        MasterTrack.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);    
    }
    public void StartUnderWater()
    {
        UnderWater.start();
    }
    public void StopUnderWater()
    {
        UnderWater.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    public void SelectSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/menu select");
    }

    public void PassingSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/menu movement");
    }

    public void GameOverSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/background/game over");
    }
}
