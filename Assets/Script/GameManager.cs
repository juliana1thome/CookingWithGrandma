using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
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
        }

        if (egg == 3 && flowers == 4 && mushroom == 2 && milk == 2)
        {
            victory = true;
        }
    }
}
