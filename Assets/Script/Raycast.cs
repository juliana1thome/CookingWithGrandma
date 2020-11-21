using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

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
    private bool steallingHappening = false;
    private bool enemyDead = false;
    [SerializeField] public GameObject enemy;
    [SerializeField] private GameObject youDefeatedTheEnemy;
    [SerializeField] private GameObject stollenEggSituation;
    
    // User Story 9
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject sellingStatus;
    [SerializeField] private GameObject youDontHaveMoneyForThisTxt;
    [SerializeField] private GameObject youDontHaveThisItemToSellTxt;
    [SerializeField] private GameObject youSoldAnItem;
    [SerializeField] private GameObject youBoughtAnItem;
    public int coins = 0;
    
    // User Story 9 txt
    [SerializeField] private Text eggCounterTxt;
    [SerializeField] private Text milkCounterTxt;
    [SerializeField] private Text flowersCounterTxt;
    [SerializeField] private Text mushroomCounterTxt;
    public Text CoinsText;
    private float closeall;

    // Adding my gameManager
    public GameManager gameManager;

    // It will close any open txt
    public void Timing()
    {
        youPickedFlowersTxt.SetActive(false);
        youPickedEggsTxt.SetActive(false);
        youPickedMushroomsTxt.SetActive(false);
        pressETxt.SetActive(false);
        youDefeatedTheEnemy.SetActive(false);
        youSoldAnItem.SetActive(false);
        youBoughtAnItem.SetActive(false);
        youDontHaveMoneyForThisTxt.SetActive(false);
        youDontHaveThisItemToSellTxt.SetActive(false);
        enemyDead = false;
    }

    // If it is looking to something that the player can pick
    public bool Looking(bool isLooking)
    {
        RaycastHit hit; //received the value from the raycast
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickingRange) &&
            (hit.collider.CompareTag("Egg") || hit.collider.CompareTag("Flowers") ||
             hit.collider.CompareTag("mushroom") || hit.collider.CompareTag("TiredBoy") ||  hit.collider.CompareTag("iCantTalkImFishing") ||  hit.collider.CompareTag("iCantTalkImTalking") ||  hit.collider.CompareTag("iCantTalkImWorking") || hit.collider.CompareTag("Store")))
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

    //Store
    // User Story 9
    public void EggSellButton()
    {
        if (gameManager.egg <= 0)
        {
            Timing();
            youDontHaveThisItemToSellTxt.SetActive(true);
            Invoke("Timing", 3.0f);
        }

        if (gameManager.egg > 0)
        {
            Timing();
            youSoldAnItem.SetActive(true);
            coins += 20;
            gameManager.egg--;
        }
    }
    
    // User Story 9
    public void MilkBuyButton()
    {
        if (coins <= 0)
        {
            Timing();
            youDontHaveMoneyForThisTxt.SetActive(true);
            Invoke("Timing", 3.0f);
        }
        if(coins >= 50)
        {
            Timing();
            youBoughtAnItem.SetActive(true);
            coins -= 50;
            gameManager.milk++;
        }
    }
    
    // User Story 9
    public void MushroomSellButton()
    {
        if (gameManager.mushroom <= 0)
        {
            Timing();
            youDontHaveThisItemToSellTxt.SetActive(true);
            Invoke("Timing", 3.0f);
        }
        else
        {
            Timing();
            youSoldAnItem.SetActive(true);
            coins += 2;
            gameManager.mushroom--;
        }
    }
    
    // User Story 9
    public void FlowersSellButton()
    {
        if (gameManager.flowers <= 0)
        {
            Timing();
            youDontHaveThisItemToSellTxt.SetActive(true);
            Invoke("Timing", 3.0f);
        }
        else
        {
            Timing();
            youSoldAnItem.SetActive(true);
            coins += 2;
            gameManager.flowers--;
        }
    }
    
    // User Story 9
    public void EggBuyButton()
    {
        if (coins <= 0)
        {
            Timing();
            youDontHaveMoneyForThisTxt.SetActive(true);
            Invoke("Timing", 3.0f);
        }
        if(coins >= 50)
        {
            Timing();
            youBoughtAnItem.SetActive(true);
            coins -= 50;
            gameManager.egg++;
        }
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
                        steallingHappening = true;
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
                    
                    // Npc talk User Story 3
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
                    
                    // Npc talk User Story 3
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
                    
                    // Npc talk User Story 9
                    if (hit.collider.CompareTag("Store"))
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
                            store.SetActive(false);
                            Talking = false;
                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                            sellingStatus.SetActive(false);
                            Timing();
                        }
                        else
                        {
                            store.SetActive(true);
                            Talking = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            sellingStatus.SetActive(true);
                        }
                    }
                    
                    // Npc talk User Story 3
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
                    
                    // Npc talk User Story 3
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
            pressETxt.SetActive(false);
        }
        
        // User Story 7
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
        
        // User Story 7
        if (Input.GetMouseButtonDown(0)) // add && bowTruth == true
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
                    gameManager.eggTruth = true; // I have enough eggs to win
                    bow.SetActive(false);
                    bowTruth = false;
                    arrow.SetActive(false);
                    crossair.SetActive(false);
                    enemyDead = true;
                }
            }
        }

        // User Story 7
        if (enemyDead == true)
        {
            youDefeatedTheEnemy.SetActive(true);
            Invoke("Timing", 4);
        }
        
        // User Story 7
        if (Input.GetKeyDown(KeyCode.C)  && steallingHappening == true)
        {
            stollenEggSituation.SetActive(false);
            bowTruth = true;
            enemy.SetActive(true);
            Time.timeScale = 1;
        }
        
        // User Story 9
        CoinsText.text = coins.ToString();
        eggCounterTxt.text = gameManager.egg.ToString();
        milkCounterTxt.text = gameManager.milk.ToString();
        flowersCounterTxt.text = gameManager.flowers.ToString();
        mushroomCounterTxt.text = gameManager.mushroom.ToString();
        
    }
}

