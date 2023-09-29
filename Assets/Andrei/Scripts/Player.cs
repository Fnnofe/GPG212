using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlatformType playerType;
    public PlayerState playerState;
    GameManager gameManager;

    [SerializeField] float jumpMagnitude;
    [SerializeField] List<GameObject> towerSegments;
    [SerializeField] float rotationSpeed;

    Rigidbody rb;


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up* jumpMagnitude, ForceMode.Impulse);
        }
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
}

public enum PlayerState
{
    OutsidePlatform,
    InsidePlatform
}
