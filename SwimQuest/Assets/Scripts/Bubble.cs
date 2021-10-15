using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Sprite smallSprite;
    [SerializeField] private Sprite mediumSprite;
    [SerializeField] private Sprite largeSprite;
    private SpriteRenderer sr;
    public float timer;
    [SerializeField] private float timeToGrow;
    [SerializeField] private float OxygenGained;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = timeToGrow;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {            
            if (sr.sprite != largeSprite)
            {                
                if (sr.sprite == smallSprite)
                {
                    sr.sprite = mediumSprite;
                    timer = timeToGrow;
                    //Debug.Log("paso a mediana");
                }
                else
                {
                    if (sr.sprite == mediumSprite)
                    {
                        sr.sprite = largeSprite;
                        timer = timeToGrow;
                        //Debug.Log("paso a grande");
                    }
                }
                
            }           
            
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& sr.sprite == largeSprite)
        {
            Player.Instance.Oxygen += OxygenGained;
            SoundController.Instance.BubbleSound();
            //Debug.Log("Burbuja agarrada");
            sr.sprite = smallSprite;
            timer = timeToGrow;
        }        
    }
}
