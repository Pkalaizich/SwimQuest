using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathablearea : MonoBehaviour
{
    // Start is called before the first frame update
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.CurrentRate = Player.Instance.OxygenGainRate;
            //Debug.Log("RESPIRA");
            SoundController.Instance.ChangeParameter2();
            SoundController.Instance.StopUnderWater();
        }
        //Debug.Log("NO PASO NADA");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.CurrentRate = Player.Instance.OxygenLossRate;
            //Debug.Log("SALIENDO");
            SoundController.Instance.ChangeParameter1();
            SoundController.Instance.StartUnderWater();
        }
    }
}
