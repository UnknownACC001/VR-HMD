using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class lensEffect : MonoBehaviour
{
    
    public XRSocketInteractor lens;
    public XRSocketInteractor hmdInSocket;
    
    public PostProcessVolume postProcessingVolume1; // Drag your Post Processing Volume here
    public PostProcessVolume postProcessingVolume2;



    private void Update()
    {
        
        if (hmdInSocket.selectTarget != null)
        {
            if(lens.selectTarget.name == "Linsen 2")
            {
                postProcessingVolume1.enabled = true;


            }
            else if (lens.selectTarget.name == "Linsen 3")
            {
                postProcessingVolume2.enabled = true;

            }
            else
            {
                postProcessingVolume1.enabled = false;
                postProcessingVolume2.enabled = false;
            }
        }
        else
        {
            postProcessingVolume1.enabled = false;
            postProcessingVolume2.enabled = false;
        }
        
        
    }

}

