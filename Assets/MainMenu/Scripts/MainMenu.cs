using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject bruitA;
    public GameObject bruitB;
    private GameObject canvas;

    void Start()
    {
        bruitB.GetComponent<AudioSource>().Stop();
        bruitA.GetComponent<AudioSource>().Stop();
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        canvas.SetActive(true);
    }

    private void Update()
    {
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void SonUp ()
    {
        bruitA.GetComponent<AudioSource>().Play();
    }

    public void SonDown ()
    {
        bruitB.GetComponent<AudioSource>().Play();
    }
}
