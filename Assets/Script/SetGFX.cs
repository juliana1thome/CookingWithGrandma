using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class SetGFX : MonoBehaviour
{
    /// <summary>
    /// User Story 4--> Script SetGFX--> Credit: Marc-André Larouche
    /// </summary>

    private Dropdown dropdown;
    private string[] _GFXNames;
    
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        _GFXNames = QualitySettings.names;
        List<string> dropOptions = new List<string>();
        foreach (string str in _GFXNames)
        {
            dropOptions.Add(str);
        }
        dropdown.AddOptions (dropOptions);
        dropdown.value = QualitySettings.GetQualityLevel();
    }
    public void SetGfx()
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
    }
    
    
}
