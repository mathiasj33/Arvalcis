using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLineOutControl : MonoBehaviour {

    void Start() {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        LineRenderer laser = GetComponent<LineRenderer>();
        Light[] lights = GetComponentsInChildren<Light>();
        float time = 0;
        float alpha = 1;
        while (alpha > 0) {
            time += Time.deltaTime;
            alpha = 1 - time * 2;
            laser.startColor = new Color(laser.startColor.r, laser.startColor.g, laser.startColor.b, alpha);
            laser.endColor = new Color(laser.endColor.r, laser.endColor.g, laser.endColor.b, laser.endColor.a == 0 ? 0 : alpha);
            lights[0].intensity = alpha;
            if (lights.Length > 1)
                lights[1].intensity = alpha;
            yield return null;
        }
        Destroy(gameObject);
    }
}