using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce=10f;

    [SerializeField]
    private float jumpForce=50f;

    private float movementX;
    private float movementZ;
    private Rigidbody myBody;
    private SpriteRenderer sr;
    private CharacterController controller;
    //Coin Pickup
    public int coinScore;
    public Text coinText;
    private Vector3 motion ;
    //public float speed=5f;
    
    
    private bool isGrounded;

    private string GROUND_TAG="Ground";


    private void Awake()
    {
        myBody=GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       
        PlayerMoveKeyboard();
        
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        
        //movementX =Input.GetAxisRaw("Horizontal");

        //movementZ =Input.GetAxisRaw("Vertical");
     
        //transform.position += new Vector3(movementX,0f,movementZ)* Time.deltaTime*moveForce;
        
        motion=new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        myBody.velocity=motion*moveForce;
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        
        {   isGrounded=false;
            myBody.AddForce(new Vector3(0f,jumpForce ,0f),ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded=true;

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag =="Coin")
        {
            coinScore++;  
            coinText.text= coinScore.ToString();
            Destroy(other.gameObject);
        }
    }
}