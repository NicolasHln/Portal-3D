using UnityEngine;

public class LancerPortail : MonoBehaviour
{
    // the portals
    public GameObject portailBleu;
    public GameObject portailOrange;

    // sounds for the blue portal
    public GameObject bruitB;
    public GameObject bruitB2;

    // sounds for the orange portal
    public GameObject bruitO;
    public GameObject bruitO2;

    // sound when we can't shoot a portal
    public GameObject bruitRater;

    // materials of the portals
    public Material matB;
    public Material matO;

    // part a the portal gun
    public GameObject tube;

    // materials for the 'tube'
    public Material bleu;
    public Material orange;

    // empty object which is at the place of the hand
    public GameObject main;

    // portals are active or not
    private bool portailB = false;
    private bool portailO = false;
    
    // camera of the player
    private GameObject mainCamera;

    private GameObject portalGun;

    

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        portalGun = GameObject.FindWithTag("portalGun");

        portailBleu.SetActive(false);
        portailOrange.SetActive(false);

        bruitO.GetComponent<AudioSource>().Stop();
        bruitO2.GetComponent<AudioSource>().Stop();

        bruitB.GetComponent<AudioSource>().Stop();
        bruitB2.GetComponent<AudioSource>().Stop();

        bruitRater.GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(main.transform.position, main.transform.TransformDirection(Vector3.forward)*100, Color.yellow); 
        
        /*
         * if the left mouse button is press
         */
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(main.transform.position, main.transform.TransformDirection(Vector3.forward), out hit);

            /*
             * if we aim an object which has the tag "murPortail" 
             */
            if (hit.transform.gameObject.tag == "murPortail") 
            {
                // activate the blue portal
                portailB = true;
                portailBleu.SetActive(true);

                // start the portalGun and portailBleu animations
                portalGun.GetComponent<Animator>().SetTrigger("tire");
                portailBleu.GetComponent<Animator>().SetTrigger("shoot");

                // change the material of the 'tube'
                tube.GetComponent<Renderer>().sharedMaterial = bleu;
                ParticleSystem.MainModule settings = tube.GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0f, 131f, 255f, 255f));

                /*
                 * if the other portal is active
                 */
                if (portailO) 
                {
                    // change the material of the portals
                    portailBleu.GetComponent<MeshRenderer>().material = matO;
                    portailOrange.GetComponent<MeshRenderer>().material = matB;
                
                }

                
                // play the sounds of the blue portal
                bruitB.GetComponent<AudioSource>().Play();
                bruitB2.GetComponent<AudioSource>().Play();

                Portail(portailBleu);
            }

            else
            {
                // play the sound "bruitRater"
                bruitRater.GetComponent<AudioSource>().Play();
            }
        }

        /*
         * if the right mouse button is press
         */
        if (Input.GetMouseButtonDown(1))
        {
            Physics.Raycast(main.transform.position, main.transform.TransformDirection(Vector3.forward), out hit);

            /*
             * if we aim an object which has the tag "murPortail" 
             */
            if (hit.transform.gameObject.tag == "murPortail")
            {
                // activate the orange portal
                portailO = true;
                portailOrange.SetActive(true);

                // start the portalGun and portailOrange animations
                portalGun.GetComponent<Animator>().SetTrigger("tire");
                portailOrange.GetComponent<Animator>().SetTrigger("shootB");

                // change the material of the 'tube'
                tube.GetComponent<Renderer>().sharedMaterial = orange;
                ParticleSystem.MainModule settings = tube.GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(255f,123f,0f,255f));

                /*
                 * if the other portal is active
                 */
                if (portailB)
                {
                    portailOrange.GetComponent<MeshRenderer>().material = matB;
                    portailBleu.GetComponent<MeshRenderer>().material = matO;
                }

                // play the sounds of the orange portal
                bruitO.GetComponent<AudioSource>().Play();
                bruitO2.GetComponent<AudioSource>().Play();

                Portail(portailOrange);
            } 
            
            else
            {
                // play the sound "bruitRater"
                bruitRater.GetComponent<AudioSource>().Play();
            }
        }
    }

    void Portail(GameObject portail)
    {
        // create a Ray in the middle of the screen
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hite;

        /*
         * if the Ray hit an object
         */
        if(Physics.Raycast(ray, out hite))
        {
            Quaternion hitObjectRotation = Quaternion.LookRotation(hite.normal);
            portail.transform.rotation = hitObjectRotation;
            portail.transform.position = hite.point;
        }
    }
}
