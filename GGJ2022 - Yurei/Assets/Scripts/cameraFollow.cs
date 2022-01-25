using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float Xoffset, Yoffset;
    private float baseX, baseY, baseZ;

    void Start()
    {
        baseX = transform.position.x;
        baseY = transform.position.y;
        baseZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((player.position.x + Xoffset), (transform.position.y), transform.position.z);
    }
}
