using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// Peut être ajouté à un ImageTarget Vuforia pour déclencher une animation sur Bouton Virtuel Pressed et Released.

public class vbutton : MonoBehaviour
{
    public GameObject vbBtnObj;
    public Animator objetAni;

    void Start()
    {
        vbBtnObj = GameObject.Find("BoutonVirtuel");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

        objetAni.GetComponent<Animator>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        objetAni.Play("Victory"); // nom de l'animation
        Debug.Log("Piton pesé");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        objetAni.Play("none"); // nom de l'animation
        Debug.Log("Piton relâché");
    }
}
