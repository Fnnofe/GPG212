using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Material> platformMaterials;
    [SerializeField] TextMeshProUGUI score;
    int scoreInt = 0;

    float yCoord;
    [SerializeField] float heightToScore;
    float InitialHeightToUpScore;


    [SerializeField] float heightToUpScore;
    [SerializeField] float floorSpeedIncrement;

    FloorMovement floor;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreInt;

        player = GameObject.Find("Player");
        floor = GameObject.Find("Floor").GetComponent<FloorMovement>();

        yCoord = player.transform.position.y;
        InitialHeightToUpScore= heightToUpScore;
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position.y - yCoord) > heightToScore)
        {
            scoreInt += 100;
            yCoord += heightToScore;
            score.text = "Score: " + scoreInt;
        }

        if(yCoord > heightToUpScore)
        {
            heightToUpScore += InitialHeightToUpScore;
            IncreaseFloorSpeed();

        }
    }

    void IncreaseFloorSpeed()
    {
        if(floor.verticalSpeed <= floor.maximumVerticalSpeed)
        {
            floor.verticalSpeed += floorSpeedIncrement;
        }
    }
}

public enum PlatformType
{
    Red,
    Blue
}
