using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror3 : MonoBehaviour
{
    Image L3, L4, F1;
    

    private void Start()
    {
        L3 = GameObject.FindWithTag("L3").GetComponent<Image>();
        L4 = GameObject.FindWithTag("L4").GetComponent<Image>();
        F1 = GameObject.FindWithTag("F1").GetComponent<Image>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("L44") && L3.enabled)
        {
            L4.enabled = true;
            F1.color = Color.green;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("L44"))
        {
            L4.enabled = false;
            F1.color = Color.white;

        }
    }
}
