using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorControl : MonoBehaviour {

    public Color color;
    public GameObject pistol;
    public GameObject shot;

    void Start() {

    }

    void Update() {

    }

    void OnValidate() {
        var playerMat = transform.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
        playerMat.SetColor("_EmissionColor", color);
        var pistolMat = pistol.GetComponent<MeshRenderer>().sharedMaterial;
        pistolMat.SetColor("_EmissionColor", color);
        var lineRenderer = shot.GetComponent<LineRenderer>();
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        var lights = shot.GetComponentsInChildren<Light>();
        lights[0].color = color;
        lights[1].color = color;
    }
}