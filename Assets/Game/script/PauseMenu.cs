using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // the pause menu
    public GameObject pauseMenuUI;
    public GameObject option;

    // the player
    public GameObject fps;

    //sounds for the pause menu
    public GameObject bruitA;
    public GameObject bruitB;
    
    private static bool GameIsPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        bruitB.GetComponent<AudioSource>().Stop();
        bruitA.GetComponent<AudioSource>().Stop();
        Pause();
        Resume();
    }

    void Update()
    {
           /*
            * if the escape button is press
            */
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            /*
             * if the game is paused
             */
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    // resume the game
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        option.SetActive(false);

        fps.GetComponent<LancerPortail>().enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    // stop the game & display the pause menu
    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        option.SetActive(false);

        fps.GetComponent<LancerPortail>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    // option menu
    public void Option()
    {
        pauseMenuUI.SetActive(false);
        option.SetActive(true);

        fps.GetComponent<LancerPortail>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    // get back to the game menu 
    public void LoadMenu ()
    {
        pauseMenuUI.SetActive(false);

        fps.GetComponent<LancerPortail>().enabled = true;

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);

        GameIsPaused = false;
    }

    // quit the application
    public void QuitGame ()
    {
        Application.Quit();
    }

    // turn up the sound
    public void SonUp()
    {
        bruitA.GetComponent<AudioSource>().Play();
    }

    // put the sound down
    public void SonDown()
    {
        bruitB.GetComponent<AudioSource>().Play();
    }

    // satrt the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
