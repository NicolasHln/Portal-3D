using System;
using UnityEngine;
using UnityEngine.UI;

public class txtInfos : MonoBehaviour
{
    public GameObject bouton;
    public GameObject cube;

    private Boolean carry = false;
    private Text Infos;

    // Start is called before the first frame update
    void Start()
    {
        Infos = GameObject.FindWithTag("txtInfos").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance between the player and the cube
        float dist = Vector3.Distance(transform.position, cube.transform.position);

        // distance between the switch and the player
        float dist2 = Vector3.Distance(transform.position, bouton.transform.position);

        // if the distance between the player and the cube is lower or equal to 2.5 & carry is false
        if (dist <= 2.5 && !carry)
        {
            Infos.text = "\n    E pour prendre";
        }

        // if the distance between the switch and the player is lower or equal to 1.5 & carry is false
        else if (dist2 <= 1.5 && !carry){
            Infos.text = "\n    E pour interagir";
        }

        // if carry is true
        else if (carry)
        {
            Infos.text = "\n    R pour lâcher";
        }
        else
        {
            Infos.text = "";
        }

        // if the distance between the player and the cube is lower or equal to 2.5 & the E button is press
        if (dist <= 2.5 && Input.GetKeyDown(KeyCode.E))
        {
            carry = true;
        }

        // if carry is true and the R button is press
        if (carry && Input.GetKeyDown(KeyCode.R))
        {
            carry = false;
        }
    }
}
