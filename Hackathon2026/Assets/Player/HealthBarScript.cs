using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    private PlayerScript player;

    void Awake()
    {
        healthBar = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();       
    }

    // Update is called once per frame
    void Update()
    {
        float healthPercent = player.getPlayerStats("currentHealth") / player.getPlayerStats("maxHealth");
        healthBar.fillAmount = healthPercent;
    }
}
