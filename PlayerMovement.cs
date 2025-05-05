using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Scene scene; // scene manager stuff

    public int health = 100;
    public TMP_Text healthText;

    //Sound effects
    public AudioClip jump;
    public AudioClip land;
    public AudioSource movementSource;

    public AudioSource sandbox;
    public AudioSource carCrash;


    //Movement
    public float moveSpeed;

    public float groundDrag;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplyer;
    public bool readyToJump;

    //Keybinds
    public KeyCode jumpKey = KeyCode.Space;

    //Ground Check
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    Rigidbody rb;

    public pickUP pick;
    public MoveChild mc;


    public string death;

   

    // Start is called before the first frame update
    void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        movementSource = GetComponent<AudioSource>();

        scene = SceneManager.GetActiveScene(); //get current scene
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        healthText.text = "Health: " + health;

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        if (health <= 0)
        { 
            SceneManager.LoadScene("Lose");
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        
    }

    void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //in air
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplyer, ForceMode.Force);
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        movementSource.clip = jump;
        movementSource.Play();
    }

    void ResetJump()
    {
        movementSource.clip = land;
        readyToJump = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sand Box")
        {
            
            death = "sandbox";
            sandbox.Play(); // play sandbox collision sound
            Invoke("GameOver",0.5f);
            Debug.Log("Switch to gameOver");
        }

        if (other.gameObject.tag == "collector")
        {
            if (pick.item != null)
            {
                pick.item.transform.position = new Vector3(-38.49f, -24.26f, -48.54f);
                //Destroy(pick.item);
                //mc.agent.enabled = true;
                pick.kidsCollected += 1;
                pick.item = null;



                // increment number of kids collected by 1
            }
            
        }
    }
    
    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Lose");
        
    }

}
