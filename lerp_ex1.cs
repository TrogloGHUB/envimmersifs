using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp_ex1 : MonoBehaviour
{

    // pour le déplacement
    private Vector3 destination;
    public float vitesse;
    public float duree;
    public bool TypeVitesse;
    private bool lerpActif=false;

    // pour la rotation
    public Transform Target;
    public float VitesseRotation;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !lerpActif)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                destination = hit.point;
                lerpActif = true;
                
                // DÉPLACEMENT
                if(TypeVitesse)
                    StartCoroutine(MoveOverSpeed(gameObject, destination, vitesse));
                else
                    StartCoroutine(MoveOverSeconds(gameObject, destination, duree));
            }
        }

        if (lerpActif)
        {
            // ROTATION
            //find the vector pointing from our position to the target
            _direction = (destination - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * VitesseRotation);
        }
    }

    // Déplace l'objet jusqu'à la destination (end) selon la vitesse (peu importe le temps)
    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // vitesse metres/sec
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        lerpActif = false;
    }
    // Déplace l'objet jusqu'à la destination (end) selon le temps maximum (ajustera la vitesse)
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        lerpActif = false;
    }
}
