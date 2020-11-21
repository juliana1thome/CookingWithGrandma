using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool victory = false;
    
    // User Story 2
    public int egg = 0;
    public bool eggTruth = false;
    public int flowers = 0;
    public bool flowersTruth = false;
    public int mushroom = 0;
    public bool mushroomTruth = false;
    [SerializeField] private GameObject inventory;
    private bool inventoryTruth = false;
    
    // User Story 2 txt
    [SerializeField] private Text eggCounterTxt;
    [SerializeField] private Text milkCounterTxt;
    [SerializeField] private Text flowersCounterTxt;
    [SerializeField] private Text mushroomCounterTxt;

    // User Story 5
    private bool pauseMenuTruth = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseMenuCanavas;
    [SerializeField] private GameObject settings;

    // User Story 5
    public Text timerText;
    private float seconds;
    private int minutes;
    
    // User Story 6
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject youLose;


    // User Story 7
    public int milk = 0;
    public bool milkTruth = false;
    
    
    // Referencing my singleton
    public static GameManager instance = null; 

    // Singleton
    private void Awake()
    {
        // Singleton implementation
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // User Story 6
    public void EndGame()
    {
        if (victory == true && minutes < 20)
        {
            youWin.SetActive(true);
            youLose.SetActive(false);
            
        }

        if (victory == false && minutes >= 20)
        {
            youWin.SetActive(false);
            youLose.SetActive(true);
        }
    }
    
    // User Story 6
    public void Timer()
    {
        //set timer UI
        seconds += Time.deltaTime;
        timerText.text = minutes +"m:"+(int)seconds + "s";
        if(seconds >= 60){
            
            minutes++;
            seconds = 0;
        }
    }    
    
    // User Story 5
    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    
    // User Story 5
    public void SettingButton()
    {
       pauseMenuCanavas.SetActive(false);
       settings.SetActive(true);
       Cursor.visible = true;
       Cursor.lockState = CursorLockMode.None;
    }
    
    // User Story 5
    public void ReturnButton()
    {
        pauseMenuCanavas.SetActive(true);
        settings.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        Timer();

        EndGame();
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryTruth == true)
            {
                inventory.SetActive(false);
                inventoryTruth = false;
            }
            else
            {
                eggCounterTxt.text = "Eggs " + egg;
                milkCounterTxt.text = "Milk " + milk;
                flowersCounterTxt.text = "Flowers " + flowers;
                mushroomCounterTxt.text = "Mushrooms " + mushroom;
                inventory.SetActive(true);
                inventoryTruth = true;
            }
            
            // Pausing the game
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuTruth == true)
            {
                pauseMenu.SetActive(false);
                pauseMenuTruth = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseMenuCanavas.SetActive(true);
                pauseMenu.SetActive(true);
                pauseMenuTruth = true;
            }
            
            // Pausing the game
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        
        if (egg == 3 && flowers == 4 && mushroom == 2 && milk == 2)
        {
            victory = true;
            
        }
    }
}
