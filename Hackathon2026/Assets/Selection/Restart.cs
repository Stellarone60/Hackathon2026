using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("r"))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}