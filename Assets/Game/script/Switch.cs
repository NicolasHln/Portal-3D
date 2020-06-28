using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform player;
    public GameObject sound;
    public GameObject dropper;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // the distance between the switch and the player
        float dist = Vector3.Distance(transform.position, player.position);

        /*
         * if the E button id press & dist is lower or equal to 1.5
         */
        if (dist <= 1.6 && Input.GetKeyDown(KeyCode.E))
        {
            // the cube fall to the ground
            sound.GetComponent<AudioSource>().Play();
            dropper.GetComponent<BoxCollider>().enabled = false;
            cube.transform.position = dropper.transform.position;
        }
    }
}
