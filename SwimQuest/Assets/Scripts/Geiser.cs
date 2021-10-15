using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser : MonoBehaviour
{
    [SerializeField] private float timeActive;
    [SerializeField] private float timeInactive;
    [SerializeField] private bool isConstant =false;
    [SerializeField] private float timer;
    [SerializeField] private bool isActive = false;
    private Collider2D col;
    //private SpriteRenderer sr;
    [SerializeField] float Damage;
    private ParticleSystem ps;

    private void Awake()
    {
        if (isActive == false)
            timer = timeInactive;
        else
            timer = timeActive;
        col = GetComponent<Collider2D>();
        //sr = GetComponent<SpriteRenderer>();
        ps = GetComponent<ParticleSystem>();
        if (isActive == false)
        {
            col.enabled = false;
            ps.Stop();
            //sr.enabled = false;
        }
    }
    void Update()
    {
        if (isConstant == false)
        {
            //Debug.Log("ENTRA EN EL BUCLE");
            timer -= Time.deltaTime;
            if (isActive == false && timer<0.2f)
            {
                ps.Play();
            }
            if (isActive == true && timer < 0.5f)
            {
                ps.Stop();
            }
            if (timer<=0)
            {
                if (isActive == false)
                {
                    col.enabled =true;
                    //sr.enabled = true;
                    timer = timeActive;
                    isActive = true;
                }
                else
                {
                    ps.Stop();
                    col.enabled =false;
                    //sr.enabled = false;
                    timer = timeInactive;
                    isActive = false;
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Player.Instance.ProtectionTimer <= 0)
        {
            Player.Instance.Damage(Damage);
        }
    }
}
