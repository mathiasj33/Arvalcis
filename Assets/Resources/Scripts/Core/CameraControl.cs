using UnityEngine;
using System.Collections;


public class CameraControl : MonoBehaviour
{
    public float height;
    [Range(0.0f, 90)]
    public float angle;
    public Transform player;

    public float zDistance;

    void Start()
    {
        transform.position = new Vector3(player.position.x, height, player.position.z);
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, height, player.position.z - zDistance);
    }

    void OnValidate()
    {
        transform.position = new Vector3(player.position.x, height, player.position.z - zDistance);
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}