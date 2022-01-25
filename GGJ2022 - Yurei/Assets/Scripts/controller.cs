using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask IsGround;
    [SerializeField] private Animator anim;
    private GameObject NPC;
    private Vector3 origin;
    private Rigidbody2D rigidBody;

    private bool isGrounded;
    private bool canMove;
    private bool nextToNPC;
    private bool hasTalked = false;

    private float speed = 2.5f;
    public float heightJump;

    private NPChandler script;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        origin = transform.position;
        canMove = true;
    }

    void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .2f, IsGround);

        for (int i = 0; i < colliders.Length; ++i) {
            if (colliders[i].gameObject != gameObject) {
                isGrounded = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("NPC")) {
            var script = coll.gameObject.GetComponent<NPChandler>();
            NPC = coll.gameObject;
            script.showKey(1);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("ending")) {
            Debug.Log("Switching to part 2");
            transform.position = new Vector3(-23, -2, 23);
        }
        if (coll.gameObject.CompareTag("NPC")) {
            nextToNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("NPC")) {
            var script = coll.gameObject.GetComponent<NPChandler>();
            script.showKey(0);
            nextToNPC = false;
        }
    }

    void Update()
    {
        float mH = Input.GetAxis ("Horizontal");

        if (mH > 0 && canMove) {
            rigidBody.velocity = new Vector2((speed), rigidBody.velocity.y);
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && canMove) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, heightJump);
        }
        if (Input.GetKeyDown(KeyCode.A) && nextToNPC) {
            script = NPC.GetComponent<NPChandler>();
            hasTalked = true;
            canMove = false;
            script.triggerDialog();
            canMove = true;
        }
        if (hasTalked) {
            if (script.isAvailable() == true) {
                canMove = false;
            } else {
                canMove = true;
            }
        }
    }

}
