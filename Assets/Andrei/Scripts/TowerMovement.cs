using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
    [SerializeField] List<GameObject> towerSegments;
    [SerializeField] float rotationSpeed;

    [SerializeField] KeyCode turnLeft;
    [SerializeField] KeyCode turnRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(turnLeft))
        {
            Rotate(RotationDirection.Left);
        }
        if (Input.GetKey(turnRight))
        {
            Rotate(RotationDirection.Right);
        }
        
    }

    void Rotate(RotationDirection rotationDirection)
    {
        switch(rotationDirection)
        {
            case RotationDirection.Left:
                float rotationAmount = -rotationSpeed * Time.deltaTime;
                for(int i = 0;i < towerSegments.Count; i++)
                {
                    transform.Rotate(Vector3.up * rotationAmount);
                }
                
                break;

            case RotationDirection.Right:
                rotationAmount = rotationSpeed * Time.deltaTime;
               
                for (int i = 0; i < towerSegments.Count; i++)
                {
                    transform.Rotate(Vector3.up * rotationAmount);
                }

                break;
        }
    }
}

public enum RotationDirection
{
    Left, Right
}
