using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restart_game : MonoBehaviour
{
    public Button self;

    // Update is called once per frame
    void Awake()
    {
        self.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
