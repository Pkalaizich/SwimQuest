using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenteredCamera : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
