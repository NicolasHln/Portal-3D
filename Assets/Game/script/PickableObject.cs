using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;

    private Vector3 dernierePos;
    private bool hasPlayer = false, beingCarried = false;
    
    private void Update()
    {
        // the distance between the object and the player
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        /*
         * if the E button is press & hasPlayer is true
         */
        if(hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            // the object is carry by the player
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = playerCam.position;
            transform.parent = playerCam.transform;
            beingCarried = true;
        }

        dernierePos = playerCam.position;

        /*
         * if the R button is press & beingCarried is true
         */
        if (beingCarried && Input.GetKeyDown(KeyCode.R))
        {
            // the player drop the object
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            transform.position = dernierePos;
            beingCarried = false;
        }
    }
}
