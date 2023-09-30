using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlatformType playerType;
    public PlayerState playerState;
    GameManager gameManager;

    [SerializeField] float jumpMagnitude;
  

    Rigidbody rb;

    bool canJump = false;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();


        switch (playerType)
        {
            case PlatformType.Blue:
                this.gameObject.GetComponent<Renderer>().material = gameManager.platformMaterials[0];
                break;
            case PlatformType.Red:
                this.gameObject.GetComponent<Renderer>().material = gameManager.platformMaterials[1];
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //Calls the method for changing the color
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerState == PlayerState.OutsidePlatform)
        {
            ChangeColor();
        }

        // Simple jump for testing purposes
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump= false;
            Jump();
           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Set the color of the raycast line.
        Vector3 raycastOrigin = transform.position + Vector3.down * transform.localScale.y * 0.5f;
        Gizmos.DrawRay(raycastOrigin, Vector3.down * 2f);
    }

    void ChangeColor()
    {
        switch (playerType)
        {
            case PlatformType.Blue:
                this.gameObject.GetComponent<Renderer>().material = gameManager.platformMaterials[1];
                playerType = PlatformType.Red;
                gameObject.layer = 6;
                break;
            case PlatformType.Red:
                this.gameObject.GetComponent<Renderer>().material = gameManager.platformMaterials[0];
                playerType = PlatformType.Blue;
                gameObject.layer = 7;
                break;
        }
    }

    public void ChangeState()
    {
        switch (playerState)
        {
            case PlayerState.OutsidePlatform:
                playerState = PlayerState.InsidePlatform;
                break;
            case PlayerState.InsidePlatform:
                playerState = PlayerState.OutsidePlatform;
                break;
        }
    }

   private void OnCollisionEnter(Collision collision)
   {
       Vector3 raycastOrigin = transform.position + Vector3.down * transform.localScale.y;
       RaycastHit hit;
        print("attempting Raycast");
       if (Physics.Raycast(raycastOrigin, Vector3.down, out hit))
       {
           canJump= true;
       }
   }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpMagnitude, ForceMode.VelocityChange);
    }


}

public enum PlayerState
{
    OutsidePlatform,
    InsidePlatform
}
