using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class getInfoLinks : MonoBehaviour
{
    public Text textui;
    private XRBaseInteractor interactor;
    
    

    private void Start()
    {
        interactor = GetComponent<XRBaseInteractor>();
        Debug.Log("interactor object: " + interactor);
        
        

    }

    private void Update()
    {
        if (interactor is XRDirectInteractor directInteractor && directInteractor.selectTarget)
        {
            XRGrabInteractable grabInteractable = interactor.selectTarget.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                string objectName = grabInteractable.gameObject.name;
                textui.text = objectName;
                Debug.Log("Grabbed object: " + objectName);


            }
        }


    }
}
