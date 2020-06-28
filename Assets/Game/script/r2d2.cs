using UnityEngine;
using UnityEngine.SceneManagement;

public class r2d2 : MonoBehaviour
{

    public AudioClip son1;
    public AudioClip son2;
    public AudioSource sound;
    public GameObject fps;
    public GameObject fin;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= 4)
        {
            //Fin();
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
        sound.PlayOneShot(son1, 1);            
        }
    }

   public void Fin()
    {
        fin.SetActive(true);
        player.GetComponent<LancerPortail>().enabled = false;
        player.GetComponent<Teleport>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        player.GetComponent<LancerPortail>().enabled = true;
        player.GetComponent<Teleport>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
