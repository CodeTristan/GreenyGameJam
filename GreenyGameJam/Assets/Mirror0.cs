using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror0 : MonoBehaviour
{
    Image L1,L2, L3, L4;

    private void Start()
    {

        L1 = GameObject.FindWithTag("L1").GetComponent<Image>();
        L2 = GameObject.FindWithTag("L2").GetComponent<Image>();
        L3 = GameObject.FindWithTag("L3").GetComponent<Image>();
        L4 = GameObject.FindWithTag("L4").GetComponent<Image>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("L11"))
        {
            L1.enabled = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("L11"))
        {
            L1.enabled = false;
            L2.enabled = false;
            L3.enabled = false;
            L4.enabled = false;
        }
    }
}
