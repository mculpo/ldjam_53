using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
[ExecuteInEditMode]
public class CameraManager : Singleton<CameraManager>
{
    public Material scanlineMaterial;


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (scanlineMaterial == null)
        {
            Graphics.Blit(source, destination);
            return;
        }
        applyPostProcessingScanline(source, destination);
    }

    private void applyPostProcessingScanline(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, scanlineMaterial);
    }

}
