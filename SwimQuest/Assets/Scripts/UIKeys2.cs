using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeys2 : MonoBehaviour
{
    private Image im;
    [SerializeField] private Sprite Key0;
    [SerializeField] private Sprite Key1;
    [SerializeField] private Sprite Key2;
    [SerializeField] private Sprite Key3;
    private void Awake()
    {
        im = GetComponent<Image>();
        im.sprite = Key0;
    }
    void Update()
    {
        if (Player.Instance.KeysObtained ==1)
        {
            im.sprite = Key1;
        }
        if (Player.Instance.KeysObtained == 2)
        {
            im.sprite = Key2;
        }
        if (Player.Instance.KeysObtained == 3)
        {
            im.sprite = Key3;
        }
    }
}
