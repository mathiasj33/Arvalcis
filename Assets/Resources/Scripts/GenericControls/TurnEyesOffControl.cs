using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEyesOffControl : MonoBehaviour {
    private float value = 1;
    private Material material;

    void Start() {
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }

    void Update() {
        value -= Time.deltaTime;
        if (value <= 0) Destroy(this);
        material.SetColor("_EmissionColor", new Color(value, value, value, 1));
    }
}