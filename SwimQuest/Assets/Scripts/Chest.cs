using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private int NecesaryKeys;
    [SerializeField] private Sprite ClosedChest;
    [SerializeField] private Sprite OpenedChest;
    [SerializeField] private Text ScreenText;
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Player.Instance.KeysObtained >= NecesaryKeys)
            {
                ScreenText.gameObject.SetActive(true);
                ScreenText.text = "PRESIONA E PARA ABRIR EL COFRE";
                if (Input.GetKey("e"))
                {
                    SoundController.Instance.ChestSound();
                    sr.sprite = OpenedChest;
                    Player.Instance.win = true;
                }
            }
            else
            {
                ScreenText.gameObject.SetActive(true);
                ScreenText.text = "LLAVES INSUFICIENTES";
            }
        }
        if (Player.Instance.win ==true)
        {
            ScreenText.text = "JUEGO COMPLETADO";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScreenText.gameObject.SetActive(false);
        }
    }


}
