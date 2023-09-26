using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class CubeJumping : MonoBehaviour
{

    [SerializeField] float jumpTimer;
    [SerializeField] float jumpStrength;
    float timerCount;
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

         timerCount = jumpTimer;

    }

    // Update is called once per frame
    void Update()
    {
        timerCount = timerCount-- * Time.deltaTime;
        print(timerCount);

            if (Input.GetKeyDown(KeyCode.Space) && timerCount<= 0)
        {
            JumpPlayer(1);
            timerCount = jumpTimer;



        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (timerCount >= jumpTimer) { 

            JumpPlayer(-1);
                timerCount = 2;
            }

        }


    }


    void JumpPlayer(int number)
    {

        rb.AddForce(transform.up * number * jumpStrength , ForceMode.VelocityChange);



    }

}
