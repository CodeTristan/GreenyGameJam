using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Masa;
    public GameObject Masa2;
    public GameObject Drawer;
    public GameObject Alchemy;
    public GameObject DeneyMasasi;
    public GameObject fadeOut;
    public float speed;
    public DialogueStarter firstDialog;
    public Animator doorAnimator;

    private Rigidbody2D rb;
    private Inventory Inventory;
    public Collider2D collider;
    private Animator animator;
    private RoomManager roomManager;


    public bool canmove = true;
    private bool startedMoving = false;

    private bool onMasa = false;
    private bool onMasa2 = false;
    private bool onDrawer = false;
    private bool onAlchemy = false;
    private bool onDeney = false;

    public bool DrawerOpened = false;
    private bool AlchemyOpened = false;
    private bool DeneyOpened = false;

    public bool inBeginning = true;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Inventory = gameObject.GetComponent<Inventory>();
        collider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        roomManager = FindObjectOfType<RoomManager>();

        FindObjectOfType<SoundManager>().StopPlaying("MainMusic");
        FindObjectOfType<SoundManager>().Play("GerilimMüziği");
        FindObjectOfType<SoundManager>().Play("Silah");
        if (inBeginning)
            canmove = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Door" && roomManager.room1Finished)
        {
            roomManager.ChangeRoom();
            FindObjectOfType<SoundManager>().Play("Teleport");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = true;
        else if (collision.tag == "Drawer")
            onDrawer = true;
        else if (collision.tag == "Alchemy")
            onAlchemy = true;
        else if (collision.tag == "Door" && roomManager.room1Finished)
            doorAnimator.SetTrigger("openDoor");
        else if (collision.tag == "Masa2")
            onMasa2 = true;
        else if (collision.tag == "DeneyMasası")
            onDeney = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Masa")
            onMasa = false;
        else if (collision.tag == "Drawer")
            onDrawer = false;
        else if (collision.tag == "Alchemy")
            onAlchemy = false;
        else if (collision.tag == "Masa2")
            onMasa2 = false;
        else if (collision.tag == "DeneyMasası")
            onDeney = false;
    }
    private void Update()
    {
        if (inBeginning && Mathf.Abs(transform.position.x - new Vector2(3, 0).x) > 1.5f)
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            animator.SetFloat("Speed", Mathf.Abs(speed));
        }
        else if (inBeginning && Mathf.Abs(transform.position.x - new Vector2(3, 0).x) <= 1.5f)
        {
            animator.SetFloat("Speed", Mathf.Abs(0));
            inBeginning = false;
            fadeOut.SetActive(false);
            firstDialog.TriggerDialog();
            canmove = true;
        }
        

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Inventory.onMasa)
            {
                collider.enabled = true;
                Masa.SetActive(false);
                Masa2.SetActive(false);
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
            if (DeneyOpened)
            {
                collider.enabled = true;
                DeneyMasasi.SetActive(false);
                canmove = true;
                DeneyOpened = false;
                Inventory.onMasa = false;
            }


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onMasa)
            {
                collider.enabled = false;
                Masa.SetActive(true);
                Inventory.onMasa = true;
                canmove = false;
            }
            if (onMasa2)
            {
                collider.enabled = false;
                Masa2.SetActive(true);
                Inventory.onMasa = true;
                canmove = false;
            }
            if (onDrawer)
            {
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
            if (onDeney)
            {
                collider.enabled = false;
                DeneyMasasi.SetActive(true);
                canmove = false;
                DeneyOpened = true;
                Inventory.onMasa = true;
            }
        }
    }
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if(Mathf.Abs(horizontal) > 0 && startedMoving)
        {
            startedMoving = false;
            FindObjectOfType<SoundManager>().Play("Yürüme");

        }
        if(horizontal == 0)
        {
            startedMoving = true;
            FindObjectOfType<SoundManager>().StopPlaying("Yürüme");
        }
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
