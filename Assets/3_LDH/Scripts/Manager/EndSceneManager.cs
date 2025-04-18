using System.Collections;
using System.Collections.Generic;
using _3_LDH.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private UI_Button UI_GoToTitleButton;

    
    // Start is called before the first frame update
    void Start()
    {
        UI_GoToTitleButton.SetOnClickListener(GoToTitle);
    }

    private void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
