using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlatformType playerType;
    public PlayerState playerState;
    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


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
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerState == PlayerState.OutsidePlatform)
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        switch (playerType)
        {
            case PlatformType.Blue:
                this.gameObject.GetComponent<Renderer>().material = gameManager.platformMaterials[1];
                playerType = PlatformType.Red;
                break;
            case PlatformType.Red:
                this.gameObject.GetComponent<Renderer>().material = gameManager.platformMaterials[0];
                playerType = PlatformType.Blue;
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
