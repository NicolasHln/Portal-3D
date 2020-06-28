using UnityEngine;

public class Teleport : MonoBehaviour
{
    // the portals
    public GameObject portailBleu;
    public GameObject portailOrange;
    
    // the camera of the portals
    private GameObject CamB;
    private GameObject CamO;

    // the camera of the player
    private GameObject CamJoueur;

    // the canvas
    private GameObject canvas;
    
    private bool flag = true;

    private void Start()
    {
        CamB = GameObject.Find("portailBleu/Camera");
        CamO = GameObject.Find("portailOrange/Camera");
        CamJoueur = GameObject.FindWithTag("MainCamera");
        canvas = GameObject.Find("Canvas");
    }

    void OnTriggerEnter(Collider col)
    {
        /*
         * if the two portals are active
         */
        if(portailBleu.activeSelf == true && portailOrange.activeSelf == true)
        {
            /*
             * if the object which enter the trigger has the tag "portailA" & flag is true
             */
            if (col.gameObject.tag == "portailBleu" && flag)
            {
                CamB.GetComponent<PortalcameraB>().enabled = false;
                CamO.GetComponent<PortalcameraB>().enabled = false;
                canvas.SetActive(false);
                gameObject.SetActive(false);

                /*
                 * if the portal look to the ground
                 */
                if(portailOrange.transform.rotation.x > 0.707 && portailOrange.transform.rotation.x < 0.708)
                {
                    // teleport the player
                    transform.position = portailOrange.transform.position + Vector3.down * 1;
                }
                else
                {
                    // teleport the plyer and keep the rotation on the x and z axis
                    Quaternion rot = CamJoueur.transform.rotation;

                    transform.position = portailOrange.transform.position;

                    transform.rotation = portailOrange.transform.rotation;
                    CamJoueur.transform.rotation.Set(rot.x, portailOrange.transform.rotation.y, rot.z, rot.w);
                } 
                 

                gameObject.SetActive(true);
                flag = false;
            }

            /*
             * if the object which enter the trigger has the tag "portailB" and flag is true
             */
            if (col.gameObject.tag == "portailOrange" && flag)
            {
                CamB.GetComponent<PortalcameraB>().enabled = false;
                CamO.GetComponent<PortalcameraB>().enabled = false;
                canvas.SetActive(false);
                gameObject.SetActive(false);

                /*
                 * if the portal look to the ground
                 */
                if (portailBleu.transform.rotation.x > 0.707 && portailBleu.transform.rotation.x < 0.708)
                {
                    // teleport the player
                    transform.position = portailBleu.transform.position + Vector3.down * 1;
                }
                else
                {
                    // teleport the plyer and keep the rotation on the x and z axis
                    Quaternion rot = CamJoueur.transform.rotation;

                    transform.position = portailBleu.transform.position;

                    transform.rotation = portailBleu.transform.rotation;
                    CamJoueur.transform.rotation.Set(rot.x, portailBleu.transform.rotation.y, rot.z, rot.w);
                }
                
                gameObject.SetActive(true);
                flag = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        flag = true;
        CamB.GetComponent<PortalcameraB>().enabled = true;
        CamO.GetComponent<PortalcameraB>().enabled = true;
        canvas.SetActive(true);
    }
}
