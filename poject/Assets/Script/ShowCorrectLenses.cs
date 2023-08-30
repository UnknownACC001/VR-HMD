using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowCorrectLenses : MonoBehaviour
{
    
    public XRSocketInteractor hmdInSocket;

    public XRSocketInteractor getLens;
    public List<GameObject> lenses = new List<GameObject>();
    

    private void Update()
    {
        if (hmdInSocket.selectTarget != null)
        {
            foreach (var lens in lenses)
            {
                if (lens.name == getLens.selectTarget.name)
                {
                    MeshRenderer meshRenderer = lens.GetComponent<MeshRenderer>();
                    if (meshRenderer != null)
                    {
                        meshRenderer.enabled = false;
                        // Rendering ausschalten
                    }
                }
                
            }
            
        }
       
    }
}
