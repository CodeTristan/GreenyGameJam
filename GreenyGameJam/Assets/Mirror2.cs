using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror2 : MonoBehaviour
{
    Image L2, L3, L4;

    private void Start()
    {
        L2 = GameObject.FindWithTag("L2").GetComponent<Image>();
        L3 = GameObject.FindWithTag("L3").GetComponent<Image>();
        L4 = GameObject.FindWithTag("L4").GetComponent<Image>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("L33") && L2.enabled)
        {
            L3.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("L33"))
        {
            L3.enabled = false;
            L4.enabled = false;
        }
    }
}
