using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockText : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float time;

    // Update is called once per frame
    private void OnEnable()
    {
        time = timer;
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time<=0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
