using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPatrol : MonoBehaviour
{
    [SerializeField] private float Speed=3f;
    [SerializeField] private Transform TurningPointA;
    [SerializeField] private Transform TurningPointB;
    private Vector2 MoveDriection;
    private SpriteRenderer sr;
    [SerializeField] private float Damage;
    public bool goingToB = true;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        MoveDriection = new Vector2(TurningPointB.position.x - TurningPointA.position.x, TurningPointB.position.y - TurningPointA.position.y);
        MoveDriection = MoveDriection.normalized;
        Debug.Log(MoveDriection.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        sr.flipX = MoveDriection.x >= 0;
        transform.Translate(MoveDriection * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Player.Instance.ProtectionTimer <= 0)
        {
            Player.Instance.Damage(Damage);            
        }        
    }

    public void GoingB()
    {
        MoveDriection = new Vector2(TurningPointB.position.x - TurningPointA.position.x, TurningPointB.position.y - TurningPointA.position.y);
        MoveDriection = MoveDriection.normalized;
        //Debug.Log("GOING B");
        goingToB = true;
    }

    public void GoingA()
    {
        MoveDriection = new Vector2(TurningPointA.position.x - TurningPointB.position.x, TurningPointA.position.y - TurningPointB.position.y);
        MoveDriection = MoveDriection.normalized;
        goingToB = false;
        //Debug.Log("GOING A");
    }
}
