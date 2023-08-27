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

}

