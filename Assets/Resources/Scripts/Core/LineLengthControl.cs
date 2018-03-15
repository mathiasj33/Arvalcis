using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLengthControl : MonoBehaviour {

    private LineRenderer lineRenderer;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        Transform lineTransform = lineRenderer.transform;
        RaycastHit hit;
        Ray ray = new Ray(lineTransform.position, lineTransform.forward);
        if (Physics.Raycast(ray, out hit)) {
            float length = (hit.point - lineTransform.position).magnitude;
            lineRenderer.SetPosition(1, new Vector3(0, 0, length * 9));
        } else {
            lineRenderer.SetPosition(1, new Vector3(0, 0, 80));
        }
    }
}