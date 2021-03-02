using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public GameObject ForCloud1, ForCloud2,
        MidCloud1, MidCloud2, BackCloud1, BackCloud2;

    public float ForSpeed, MidSpeed, BackSpeed, EndPoint;

    private Vector3 StartPoint;
  
    // Update is called once per frame
    void Update()
    {
        MoveCloud(ForCloud1, ForSpeed);
        MoveCloud(ForCloud2, ForSpeed);
        MoveCloud(MidCloud1, MidSpeed);
        MoveCloud(MidCloud2, MidSpeed);
        MoveCloud(BackCloud1, BackSpeed);
        MoveCloud(BackCloud2, BackSpeed);
    }

 public void MoveCloud(GameObject cloud, float speed)
    {
        if(cloud.transform.position.x < EndPoint)
        {
            cloud.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
        else if(cloud.transform.position.x >= EndPoint)
        {
            StartPoint = new Vector3(-7, Random.Range(0, 7), 0);
            cloud.transform.position = StartPoint;
        }
    }
}
