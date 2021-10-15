using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private static MenuSound instance;
    public static MenuSound Instance { get => instance; }
    FMOD.Studio.EventInstance MasterTrack;
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        MasterTrack = FMODUnity.RuntimeManager.CreateInstance("event:/background/main menu music");        
        MasterTrack.start();
    }
    public void Stop()
    {
        MasterTrack.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    public void SelectSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/menu select");
    }

    public void PassingSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/menu movement");
    }

}
