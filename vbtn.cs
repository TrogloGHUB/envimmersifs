using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbtn : MonoBehaviour
{
    public GameObject cube;
    public VirtualButtonBehaviour Vb;

    void Start()
    {
        Vb.RegisterOnButtonPressed(BoutonAppuie);
        Vb.RegisterOnButtonReleased(BoutonRelache);

        cube.SetActive(true);
    }

    public void BoutonAppuie(VirtualButtonBehaviour Vb)
    {
        cube.SetActive(false);
    }
    public void BoutonRelache(VirtualButtonBehaviour Vb)
    {
        cube.SetActive(true);
    }
}
