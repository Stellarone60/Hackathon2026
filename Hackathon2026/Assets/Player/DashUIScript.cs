using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    private Image cooldownImage;
    private PlayerScript player;
    public float maxCooldown = 2f; 

    void Awake()
    {
        cooldownImage = GetComponent<Image>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        float cooldownPercent = player.getCooldownPercent();

        cooldownImage.fillAmount = cooldownPercent;
    }
}