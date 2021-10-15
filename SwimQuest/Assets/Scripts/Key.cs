using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("HUBO COLISION");
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.KeysObtained +=1;
            SoundController.Instance.KeySound();
            this.gameObject.SetActive(false);
        }
    }
}
