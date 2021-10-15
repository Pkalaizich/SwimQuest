using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   public void StartPlaying()
    {
        MenuSound.Instance.SelectSound();
        MenuSound.Instance.Stop();
        SceneManager.LoadScene("SampleScene");
    }
    public void PassingSound()
    {
        MenuSound.Instance.PassingSound();
    }
}
