using UnityEngine;

public class Bouton : MonoBehaviour
{
    public GameObject porte;

    public GameObject openSound;
    public GameObject closeSound;

    public GameObject platform;
    public GameObject platform2;

    private bool flag = true;
    private GameObject button;

    void Start()
    {
        openSound.GetComponent<AudioSource>().Stop();
        closeSound.GetComponent<AudioSource>().Stop();
        button = GameObject.FindWithTag("bouton");
    }

    void OnTriggerEnter(Collider Col)
    {
        /*
         * if the object which enter the trigger has the tag "pickable" & the flag is true
         */
        if(Col.tag == "pickable" && flag)
        {
            // open the door
            porte.GetComponent<Animator>().ResetTrigger("fermerP2");
            porte.GetComponent<Animator>().SetTrigger("ouvrirP2");

            // animation of button
            button.GetComponent<Animator>().SetTrigger("descend");
            button.GetComponent<Animator>().ResetTrigger("leve");

            // move the platforms
            platform.GetComponent<Animator>().SetTrigger("lever");
            platform.GetComponent<Animator>().ResetTrigger("descend");
            platform2.GetComponent<Animator>().SetTrigger("lever");
            platform2.GetComponent<Animator>().ResetTrigger("descend");

            // start the sound of the door
            openSound.GetComponent<AudioSource>().Play();

            flag = false;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        /*
         * if the object which exit the trigger has the tag "pickable" & the flag is false
         */
        if (Col.tag == "pickable" && !flag)
        {
            // close the door
            porte.GetComponent<Animator>().ResetTrigger("ouvrirP2");
            porte.GetComponent<Animator>().SetTrigger("fermerP2");

            // animation of button
            button.GetComponent<Animator>().SetTrigger("leve");
            button.GetComponent<Animator>().ResetTrigger("descend");

            // move the platforms
            platform.GetComponent<Animator>().ResetTrigger("lever");
            platform.GetComponent<Animator>().SetTrigger("descend");
            platform2.GetComponent<Animator>().ResetTrigger("lever");
            platform2.GetComponent<Animator>().SetTrigger("descend");

            // start the sound of the door
            closeSound.GetComponent<AudioSource>().Play();

            flag = true; 
        }
    }
}
