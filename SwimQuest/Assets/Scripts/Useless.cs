using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useless : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject text1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turntexton()
    {
        text1.gameObject.SetActive(true);
        MenuSound.Instance.SelectSound();
    }

    public void PassingSound()
    {
        MenuSound.Instance.PassingSound();
    }
}
