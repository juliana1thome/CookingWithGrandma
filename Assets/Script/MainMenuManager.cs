using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    /// <summary>
    ///  User Story 4 -->  Main Menu script part PanelToggle  --> Credit: Marc-André Larouche
    /// </summary>
    
    [SerializeField] private GameObject[] panels = null;
    [SerializeField] private Selectable[] defaultSelected = null;

    private void Start()
    {
        PanelToggle(0);
        
    }
    
    public void PlayButton()
        {
          SceneManager.LoadSceneAsync("Loading");//and when it go to the next scene it will call the function loadlevel and it will load the level
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
