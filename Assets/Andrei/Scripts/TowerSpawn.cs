using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    TowerMovement towerMovement;
    [SerializeField] GameObject towerSegment;
    GameObject player;

    public float segmentSize;
    float spawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        towerMovement = GetComponent<TowerMovement>();
        //segmentSize = towerSegment.GetComponent<Renderer>().bounds.max.y;
        segmentSize = 2 * towerSegment.transform.localScale.y;

        spawnDistance= segmentSize * 3;
    }

    // Update is called once per frame
    void Update()
    {
        if( Mathf.Abs(player.transform.position.y - towerMovement.towerSegments[towerMovement.towerSegments.Count - 1].transform.position.y) < spawnDistance)
        {
            SpawnNewSegment();
        }
        
    }

    void SpawnNewSegment()
    {
        Vector3 spawnPosition = towerMovement.towerSegments[towerMovement.towerSegments.Count - 1].transform.position + new Vector3(0, segmentSize, 0);

        towerMovement.towerSegments.Add(Instantiate(towerSegment, spawnPosition, Quaternion.identity));

    }
}
