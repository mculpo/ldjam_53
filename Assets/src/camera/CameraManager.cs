using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraManager : Singleton<CameraManager>
{
    public Material material;
    private Material standart;
    public float magnitude = 0.05f;
    public float speed = 1.0f;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material == null)
        {
            Graphics.Blit(source, destination);
            return;
        }
        Graphics.Blit(source, destination, material);
    }

    private void OnValidate()
    {
        material.SetFloat("_Magnitude", magnitude);
        material.SetFloat("_Speed", speed);
    }
}
