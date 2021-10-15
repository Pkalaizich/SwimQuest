using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public void Innecesario()
    {
        SoundController.Instance.StopUnderWater();
        SoundController.Instance.SelectSound();
        GameController.Instance.RestartLevel();
    }

    public void PassingSound()
    {
        SoundController.Instance.PassingSound();
    }
}
