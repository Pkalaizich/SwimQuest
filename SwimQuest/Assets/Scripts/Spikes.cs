using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Player.Instance.ProtectionTimer <= 0)
        {
            Player.Instance.Damage(Damage);
        }
    }
}
