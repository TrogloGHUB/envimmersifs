using UnityEngine;
using System.Collections;

/*
    Permet de tirer des projectiles à partir de l'objet placé dans shotPos.
    Utiliser des valeurs entre 100 et 200 pour shotForce (tout dépendant de la taille des objets).

    Utiliser une masse entre 0.5 et 1.5 pour le projectile qui sera Instantié.
*/

public class Shooter : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce;
    public float moveSpeed = 10f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(new Vector3(h, v, 0f));

        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);

            Destroy(shot.gameObject, 3f);
        }
    }
}