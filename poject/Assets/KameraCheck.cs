using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;



public class KameraCheck : MonoBehaviour
{
   
    public bool vollstaendig = false;
    public XRSocketInteractor activateOrDeactivate;
    public List<XRSocketInteractor> socketInteractors = new List<XRSocketInteractor>();
    
    public GameObject led;
    public Material green;
    public Material red;
    

    private void Update()
    {
        Renderer objectRenderer = led.GetComponent<Renderer>();
        vollstaendig = true;
        foreach (var interactor in socketInteractors)
        {
            if (!vollstaendig)
            {
                break;
            }
            if (interactor.selectTarget != null)
            {
                Debug.Log(interactor.name + " enthält ein Objekt!");
            }
            else
            {
                Debug.Log(interactor.name + " enthält kein Objekt.");
                vollstaendig = false;
            }
        }
        if (vollstaendig)
        {
            //textui.color= Color.green;
            activateOrDeactivate.socketActive = true;
            objectRenderer.material=green;
        }
        else
        {
            //textui.color = Color.red;
            activateOrDeactivate.socketActive = false;
            objectRenderer.material=red;
        }
    }

}

