using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;
    private Rigidbody rb;
    public int count;

    //holds movement x and y
    private float movementX;
    private float movementY;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        count = 0; //set to 0
        SetCountText();
        rb = GetComponent<Rigidbody>();  //sets rigidbody componet to rb
        winText.gameObject.SetActive(false);
    } 


    void OnMove(InputValue movementValue)
    {
        //create a vector 2 variable and store the x and y movement values in it
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        //set the movement to the x and z variables (keep y at 0)
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            
            //add 1 to the score
            count = count + 1;

            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
        }
    }
}   