using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject deathPanel;
    void Start()
    {
        SetIfActive(false);
    }

      public void SetIfActive(bool active)
    {
        deathPanel.SetActive(active);
    }

    public void HandleButtonPress()
    {
        deathPanel.SetActive(false);
    }
}
