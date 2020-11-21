using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.FirstPerson;

public class Raycast : MonoBehaviour
{
    
    /// <summary>
    /// User Story 7--> Bow Firing Logic And Code --> Credit: Marc-André Larouche
    /// </summary>
    
    // User Story 2
    [SerializeField] private float pickingRange = 10f;
    private float secondsCount;
    private bool picking = false; // Did i press the button picking?
    public Camera cam;

    // User Story 2 txt
    [SerializeField] private GameObject youPickedFlowersTxt;
    [SerializeField] private GameObject youPickedMushroomsTxt;
    [SerializeField] private GameObject youPickedEggsTxt;
    [SerializeField] private GameObject pressETxt;

    // User Story 3
    [SerializeField] private GameObject tiredBoyTalkTxt;
    private bool Talking = false;
    [SerializeField] private GameObject iCantTalkImWorkingTxt;
    [SerializeField] private GameObject iCantTalkImTalkingTxt;
    [SerializeField] private GameObject iCantTalkImFishingTxt;

    // User Story 7
    [SerializeField] private GameObject bow;
    private bool bowTruth = false;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject crossair;
    public Transform arrowCreator;
    public float speed = 15f;
    private bool firing = false;
    [SerializeField] public GameObject enemy;
    [SerializeField] private GameObject youDefeatedTheEnemy;
    [SerializeField] private GameObject stollenEggSituation;

    // Adding my gameManager
    public GameManager gameManager;

    // It will close any open txt
    public void Timing()
    {
        youPickedFlowersTxt.SetActive(false);
        youPickedEggsTxt.SetActive(false);
        youPickedMushroomsTxt.SetActive(false);
        pressETxt.SetActive(false);
        arrow.SetActive(true);
        youDefeatedTheEnemy.SetActive(false);
    }

    // If it is looking to something that the player can pick
    public bool Looking(bool isLooking)
    {
        RaycastHit hit; //received the value from the raycast
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickingRange) &&
            (hit.collider.CompareTag("Egg") || hit.collider.CompareTag("Flowers") ||
             hit.collider.CompareTag("mushroom") || hit.collider.CompareTag("TiredBoy") ||  hit.collider.CompareTag("iCantTalkImFishing") ||  hit.collider.CompareTag("iCantTalkImTalking") ||  hit.collider.CompareTag("iCantTalkImWorking")))
        {
            pressETxt.SetActive(true);
            return true;
        }
        return false;
    }
    
    // User Story 2
    public void OnPick(InputAction.CallbackContext context)
    {
        picking = context.performed;
        Debug.Log(picking);
    }

    // User Story 7
    public void OnFire(InputAction.CallbackContext context)
    {
        firing = context.performed;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }



    // Update is called once per frame
    void Update()
    {
        if (Looking(true))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickingRange))
                {
                    // Need to change this code to a switch
                    //Debug.DrawRay(transform.position, transform.foward * hit.distance, Color.red);
                    Timing();
                    if (hit.collider.CompareTag("Flowers"))
                    {
                        hit.collider.gameObject.SetActive(false);
                        gameManager.flowers++;
                        gameManager.flowersTruth = true; // I have flowers in my inventory, enough for win the game
                        youPickedFlowersTxt.SetActive(true);
                        Debug.Log("You just picked one flower");
                        //You just picked one flower
                        Invoke("Timing", 4.0f);
                    }

                    if (hit.collider.CompareTag("Egg"))
                    {
                        hit.collider.gameObject.SetActive(false);
                        //You just picked one egg
                        stollenEggSituation.SetActive(true);
                        Time.timeScale = 0;
                        
                        // Fix closing key
                        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKey(vKey))
                            {

                                stollenEggSituation.SetActive(false);
                                bowTruth = true;
                                enemy.SetActive(true);
                                Time.timeScale = 1;
                            }

                        }
                    }

                    if (hit.collider.CompareTag("mushroom"))
                    {
                        hit.collider.gameObject.SetActive(false);
                        gameManager.mushroom++;
                        gameManager.mushroomTruth = true; // I have flowers in my inventory, enough for win the game
                        youPickedMushroomsTxt.SetActive(true);
                        Invoke("Timing", 4.0f);
                        //You just picked one mushroom
                    }
                    
                    // Npc talk
                    if (hit.collider.CompareTag("iCantTalkImWorking"))
                    {
                        // Pausing the game
                        if (Time.timeScale == 1)
                        {
                            Time.timeScale = 0;
                        }
                        else
                        {
                            Time.timeScale = 1;
                        }
                        
                        if (Talking == true)
                        {
                            iCantTalkImWorkingTxt.SetActive(false);
                            Talking = false;
                        }
                        else
                        {
                            iCantTalkImWorkingTxt.SetActive(true);
                            Talking = true;
                        }
                        
                    }
                    
                    // Npc talk
                    if (hit.collider.CompareTag("iCantTalkImTalking"))
                    {
                        // Pausing the game
                        if (Time.timeScale == 1)
                        {
                            Time.timeScale = 0;
                        }
                        else
                        {
                            Time.timeScale = 1;
                        }
                        
                        if (Talking == true)
                        {
                            iCantTalkImTalkingTxt.SetActive(false);
                            Talking = false;
                        }
                        else
                        {
                            iCantTalkImTalkingTxt.SetActive(true);
                            Talking = true;
                        }
                    }
                    
                    // Npc talk
                    if (hit.collider.CompareTag("iCantTalkImFishing"))
                    {
                        // Pausing the game
                        if (Time.timeScale == 1)
                        {
                            Time.timeScale = 0;
                        }
                        else
                        {
                            Time.timeScale = 1;
                        }
                        
                        if (Talking == true)
                        {
                            iCantTalkImFishingTxt.SetActive(false);
                            Talking = false;
                        }
                        else
                        {
                            iCantTalkImFishingTxt.SetActive(true);
                            Talking = true;
                        }
                    }
                    
                    if (hit.collider.CompareTag("TiredBoy"))
                    {
                        // Pausing the game
                        if (Time.timeScale == 1)
                        {
                            Time.timeScale = 0;
                        }
                        else
                        {
                            Time.timeScale = 1;
                        }
                        
                        if (Talking == true)
                        {
                            tiredBoyTalkTxt.SetActive(false);
                            Talking = false;
                        }
                        else
                        {
                            tiredBoyTalkTxt.SetActive(true);
                            Talking = true;
                        }
                    }
                }
            }
        }
        else
        {
            Timing();
        }

        // User Story 7, Bow Shoot
        if (bowTruth == false && bowTruth == false)
        {
            bow.SetActive(false);
            bowTruth = false;
            arrow.SetActive(false);
            crossair.SetActive(false);
        }
        else
        {
            bow.SetActive(true);
            bowTruth = true;
            arrow.SetActive(true);
            crossair.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                // Try to implement the arrow having a trajectory
                
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Matou");
                    hit.collider.gameObject.SetActive(false);
                    gameManager.egg++;
                    youPickedEggsTxt.SetActive(true);
                    youDefeatedTheEnemy.SetActive(true);
                    Invoke("Timing", 4.0f);
                    gameManager.eggTruth = true; // I have enough eggs to win
                    bow.SetActive(false);
                    bowTruth = false;
                    arrow.SetActive(false);
                    crossair.SetActive(false);
                }
                
            }

        }
    }
}

