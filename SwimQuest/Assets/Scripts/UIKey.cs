using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKey : MonoBehaviour
{
    [SerializeField] private Sprite MissingKey;
    [SerializeField] private Sprite FoundKey;
    //[SerializeField] private Sprite MissingSprite;
    //[SerializeField] private Sprite FoundSprite;
    [SerializeField] private int KeyNumber;
    //private SpriteRenderer sr;
    private Image im;

    private void Awake()
    {
        im = GetComponent<Image>();
        im.sprite = MissingKey;
    }

    private void Update()
    {
        if(Player.Instance.KeysObtained == KeyNumber)
        {
            im.sprite = FoundKey;
        }
    }
}
