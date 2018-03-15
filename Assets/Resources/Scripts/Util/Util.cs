using UnityEngine;

public static class Util {
    public static void DrawRay(Ray ray, float length) {
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * length, Color.red, 100);
    }
}