using UnityEngine;
using System.Collections;


public class CameraControl : MonoBehaviour
{
    public float height;
    [Range(0.0f, 90)]
    public float angle;
    public float zDistance;

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        transform.position = new Vector3(player.position.x, height, player.position.z);
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, height, player.position.z - zDistance);
    }

    void OnValidate()
    {
        if(player == null) return;
        transform.position = new Vector3(player.position.x, height, player.position.z - zDistance);
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}