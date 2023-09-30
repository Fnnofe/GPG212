using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] float delayBeforeMoving;
    public float verticalSpeed;
    public float maximumVerticalSpeed;

    bool startMoving = false;

    TowerMovement towerMovement;

    // Start is called before the first frame update
    void Start()
    {
        towerMovement = GameObject.Find("Tower").GetComponent<TowerMovement>();
        StartCoroutine(Wait(delayBeforeMoving));
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            transform.position += new Vector3(0f, verticalSpeed, 0f) * Time.deltaTime;
        }
       
    }

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        startMoving= true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            print("GameOver");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TowerSegment")
        {
            towerMovement.towerSegments.RemoveAt(0);
            Destroy(other.gameObject);
            print("GameOver");
        }

    }
}
