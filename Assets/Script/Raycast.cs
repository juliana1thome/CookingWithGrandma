using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    /// <summary>
    /// Picking first logic --> Credit: Marc-André Larouche// ask if i need to add this since i modified the script
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

    // Adding my gameManager
    public GameManager gameManager;

    public void OnPick(InputAction.CallbackContext context)// Problem this is not transforming the picking into true
    {
        picking = context.performed; // Am i picking?
        Debug.Log(picking);
    }

    public void Timing()
    {
        youPickedFlowersTxt.SetActive(false);
        youPickedEggsTxt.SetActive(false);
        youPickedMushroomsTxt.SetActive(false);
        pressETxt.SetActive(false);
    }

    public bool Looking()
    {
        RaycastHit hit; //received the value from the raycast
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickingRange) && (hit.collider.CompareTag("Egg") || hit.collider.CompareTag("Flowers")||hit.collider.CompareTag("mushroom")))
        {
            pressETxt.SetActive(true);
            Invoke("Timing", 1.5f);
        }
        return false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager= GameManager.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Looking())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Timing();
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickingRange))
                {
                    //Debug.DrawRay(transform.position, transform.foward * hit.distance, Color.red);

                    if (hit.collider.CompareTag("Flowers"))
                    {
                        hit.collider.gameObject.SetActive(false);
                        gameManager.flowers++;
                        gameManager.flowersTruth = true; // I have flowers in my inventory, enough for win the game
                        youPickedFlowersTxt.SetActive(true);
                        Debug.Log("You just picked one flower");
                        //You just picked one flower
                        Invoke("Timing", 3.0f);
                    }

                    if (hit.collider.CompareTag("Egg"))
                    {
                        hit.collider.gameObject.SetActive(false);
                        gameManager.egg++;
                        gameManager.eggTruth = true; // I have flowers in my inventory, enough for win the game
                        youPickedEggsTxt.SetActive(true);
                        //You just picked one egg
                        Invoke("Timing", 3.0f);
                    }

                    if (hit.collider.CompareTag("mushroom"))
                    {
                        hit.collider.gameObject.SetActive(false);
                        gameManager.mushroom++;
                        gameManager.mushroomTruth = true; // I have flowers in my inventory, enough for win the game
                        youPickedMushroomsTxt.SetActive(true);
                        //You just picked one mushroom
                        Invoke("Timing", 3.0f);
                    }
                }
            }
        }
    }
}

