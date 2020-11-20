using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]

public class SetResolution : MonoBehaviour
{
    /// <summary>
    /// User Story 4--> Script SetResolution --> Credit: Marc-André Larouche
    /// </summary>
    
    private Dropdown dropdown;
    private Resolution[] resolutions;
    
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        resolutions = Screen.resolutions;
        List<string> dropOptions =new List<string>();
        int position = 0;
        int i = 0;
        Resolution currentResolution = Screen.currentResolution;

        foreach (Resolution res in resolutions)
        {
            string s = res.ToString();
            dropOptions.Add(s);
            if (res.width == currentResolution.width && res.height == currentResolution.height &&
                res.refreshRate == currentResolution.refreshRate)
            {
                position = i;
            }

            i++;
        }
        dropdown.AddOptions(dropOptions);
        dropdown.value = position;
    }

    public void SetRes()
    {
        Resolution res = resolutions[dropdown.value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
    }
}
