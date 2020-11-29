using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenuManager : MonoBehaviour
{
    /// <summary>
    ///  User Story 4 -->  Main Menu Script Part PanelToggle  --> Credit: Marc-André Larouche
    /// </summary>
    
    [SerializeField] private GameObject[] panels = null;
    [SerializeField] private Selectable[] defaultSelected = null;
    
    // User Story 8
    public bool generalActionsTruth = false;
    [SerializeField] private GameObject generalActions;
    [SerializeField] private GameObject MenuBar;
    
    private void Start()
    {
        PanelToggle(0);
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (generalActionsTruth == true)
            {
                generalActions.SetActive(false);
                generalActionsTruth = false;
            }
            else
            {
                generalActions.SetActive(true);
                generalActionsTruth = true;
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
    }

    public void PlayButton()
        {
            SceneManager.LoadSceneAsync("Loading");
        }
    
        public void QuitButton()
        {
            Application.Quit();
        }

        public void PanelToggle(int position)
        {
            Input.ResetInputAxes();
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].SetActive(position == i);
                if (position == i)
                {
                    defaultSelected[i].Select();
                }
            }
        }
}
