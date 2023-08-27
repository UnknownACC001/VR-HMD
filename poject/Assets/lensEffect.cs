using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class lensEffect : MonoBehaviour
{
    
    public XRSocketInteractor lens;
    public XRSocketInteractor hmdInSocket;
    public Material blurMaterial; // Das Material mit dem Blur-Effekt
    public float setSlurStrength = 0.5f; // Die Stärke des Blur-Effekts
    private float blurStrength = 0.0f;
    public float distortion = 0.2f; // Adjust this value to control the distortion
    public Camera cam;


    private void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;
    }

    private void Update()
    {
        
        if (hmdInSocket.selectTarget != null)
        {
            if(lens.selectTarget.name=="Linsen")
            {

                blurStrength = setSlurStrength;
                ApplyFisheyeEffect();
            }
            else
            {
                blurStrength = 0.0f;
            }
        }
        else
        {

            blurStrength = 0.0f;
        }
        
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (blurMaterial != null)
        {
            blurMaterial.SetFloat("_BlurStrength", blurStrength);
            Graphics.Blit(source, destination, blurMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
    void ApplyFisheyeEffect()
    {
       
        Matrix4x4 matrix = cam.projectionMatrix;

        matrix[0, 2] = distortion;
        matrix[1, 2] = distortion;

        cam.projectionMatrix = matrix;
    }

}

