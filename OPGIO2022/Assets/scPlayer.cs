using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPlayer : MonoBehaviour
{
    //Components
    private Rigidbody2D playerRB;

    //Player control variables
    private float movementSpeed = 5.0f;

    //Input Variables
    private float h_input;
    private float jump = 5.5f;


    private bool isJumping;


    void Awake()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        restartLevel();
    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(h_input * movementSpeed, playerRB.velocity.y);
    }

    void CheckInput()
    {
        h_input = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jump);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void restartLevel()
    {

        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(0); //or whatever number your scene is
    }

   

}
