using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShip : MonoBehaviour
{
    private Vector3 rotation;
    [SerializeField] private float Speed;
    public float Intensidad;
    private void Awake()
    {
        rotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation.z + Mathf.Sin(Time.time*Speed)*Intensidad);
    }
}
