using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Masa;
    public GameObject Drawer;
    public float speed;
    
    private Rigidbody2D rb;
    private Inventory Inventory;
    private Collider2D collider;

    private bool canmove = true;
    private bool onMasa = false;
    private bool onDrawer = false;
    private bool DrawerOpened = false;


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
        else if (collision.tag == "Drawer")
            onDrawer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = false;
        else if (collision.tag == "Drawer")
            onDrawer = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(onMasa)
            {
                collider.enabled = false;
                Masa.SetActive(true);
                Inventory.onMasa = true;
                canmove = false;
            }
            if (onDrawer)
            {
                collider.enabled = false;
                Drawer.SetActive(true);
                canmove = false;
                DrawerOpened = true;
            }

        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Inventory.onMasa)
            {
                collider.enabled = true;
                Masa.SetActive(false);
                canmove = true;
            }
            if (DrawerOpened)
            {
                collider.enabled = true;
                Drawer.SetActive(false);
                canmove = true;
                DrawerOpened = false;
            }
        

        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(canmove)
            transform.position += new Vector3(horizontal, 0,0);

    }

}
