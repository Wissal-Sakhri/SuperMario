using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovemnt3D : MonoBehaviour
{
    public float speed=20f;
    private Vector3 motion ; //vecteur3D 
    private Rigidbody rb ; // a property, which, when added to any object, allows it to interact with a lot of fundamental physics behaviour 
                           //can receive forces and torque to make your objects move in a realistic way
    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        motion=new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        rb.velocity=motion*speed; //The velocity vector of the rigidbody It represents the rate of change of Rigidbody position.
    }
}
