using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Masa;
    public GameObject Drawer;
    public GameObject Alchemy;
    public float speed;
    public DialogueStarter firstDialog;

    private Rigidbody2D rb;
    private Inventory Inventory;
    private Collider2D collider;
    private Animator animator;

    private bool canmove = true;
    private bool onMasa = false;
    private bool onDrawer = false;
    private bool onAlchemy = false;
    private bool DrawerOpened = false;
    private bool AlchemyOpened = false;

    private bool inBeginning = true;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Inventory = gameObject.GetComponent<Inventory>();
        collider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();

        canmove = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = true;
        else if (collision.tag == "Drawer")
            onDrawer = true;
        else if (collision.tag == "Alchemy")
            onAlchemy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = false;
        else if (collision.tag == "Drawer")
            onDrawer = false;
        else if (collision.tag == "Alchemy")
            onAlchemy = false;
    }
    private void Update()
    {
        if (inBeginning && Mathf.Abs(transform.position.x - new Vector2(3, 0).x) > 1)
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        else if (inBeginning && Mathf.Abs(transform.position.x - new Vector2(3, 0).x) <= 1)
        {
            inBeginning = false;
            firstDialog.TriggerDialog();
            canmove = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
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
            if (onAlchemy)
            {
                collider.enabled = false;
                Alchemy.SetActive(true);
                canmove = false;
                AlchemyOpened = true;
                Inventory.onMasa = true;
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
            if (AlchemyOpened)
            {
                collider.enabled = true;
                Alchemy.SetActive(false);
                canmove = true;
                AlchemyOpened = false;
                Inventory.onMasa = false;
            }


        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (horizontal < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (canmove)
        {
            transform.position += new Vector3(horizontal, 0,0);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }

    }

}
