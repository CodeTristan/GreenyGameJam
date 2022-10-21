using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Masa;
    public float speed;
    
    private Rigidbody2D rb;
    private Inventory Inventory;
    private Collider2D collider;
    private bool onMasa = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Inventory = gameObject.GetComponent<Inventory>();
        collider = gameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = false;
    }
    private void Update()
    {
        if(onMasa && Input.GetKeyDown(KeyCode.Space))
        {
            collider.enabled = false;
            Masa.SetActive(true);
            Inventory.onMasa = true;
        }

        if(Inventory.onMasa && Input.GetKeyDown(KeyCode.Escape))
        {
            collider.enabled = true;
            Masa.SetActive(false);
            Inventory.onMasa = false;
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if(!Inventory.onMasa)
            transform.position += new Vector3(horizontal, vertical,0);

    }

}
