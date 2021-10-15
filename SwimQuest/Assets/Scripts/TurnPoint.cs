using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("colision");
        if (collision.gameObject.CompareTag("Fish"))
        {
            //Debug.Log("choco");
            FishPatrol fp = collision.GetComponent<FishPatrol>();
            if (fp!=null)
            {
                //Debug.Log("ENTRO ACA");
                if (fp.goingToB == true && this.tag == "TurnPointB")
                {
                    fp.GoingA();
                }
                if (fp.goingToB == false && this.tag == "TurnPointA")
                {
                    fp.GoingB();
                }
            }
        }
    }
}
