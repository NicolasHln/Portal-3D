using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Mouvement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    [SerializeField] private float jumpPower = 3f;
    public float rayDistance;
    public LayerMask layers;
    
    // the doors
    public GameObject entree;
    public GameObject sortie;

    // the sounds of the doors
    public GameObject entreeSound;
    public GameObject sortieSound;

    Vector3 velocity;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        entreeSound.GetComponent<AudioSource>().Stop();
        sortieSound.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // create the movements of the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // create a Ray below the player
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * rayDistance, Color.red);

        /*
         * if there is an object below the player
         */
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayDistance, layers))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
         
        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        /*
         * if the Jump button id pressed & grounded is true
         */
        if (grounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void OnTriggerEnter(Collider Col)
    {
        /*
         * if the object which enter the trigger has the tag "porte"
         */
        if (Col.gameObject.tag == "entree")
        {
            entree.GetComponent<Animator>().SetTrigger("ouvrirP1");
            entreeSound.GetComponent<AudioSource>().Play();
        } 
    }

    void OnTriggerExit(Collider Col)
    {
        /*
        * if the object which enter the trigger has the tag "porte"
        */
        if (Col.gameObject.tag == "entree")
        {
            entree.GetComponent<Animator>().ResetTrigger("ouvrirP1");
            entree.GetComponent<Animator>().SetTrigger("fermerP1");
            sortieSound.GetComponent<AudioSource>().Play();
        }

        /*
        * if the object which enter the trigger has the tag "sortie"
        */
        if (Col.gameObject.tag == "sortie")
        {
            sortie.GetComponent<Animator>().ResetTrigger("ouvrirP2");
            sortie.GetComponent<Animator>().SetTrigger("fermerP2");
            sortieSound.GetComponent<AudioSource>().Play();
        }
    }
}
