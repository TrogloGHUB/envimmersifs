using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// Peut �tre ajout� � un ImageTarget Vuforia pour d�clencher une animation sur Bouton Virtuel Pressed et Released.

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
        Debug.Log("Piton pes�");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        objetAni.Play("none"); // nom de l'animation
        Debug.Log("Piton rel�ch�");
    }
}
