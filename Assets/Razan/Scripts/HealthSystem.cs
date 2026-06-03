using UnityEngine;
using UnityEngine.UI;

// 1. ßæÏ ÅÚÏÇÏÇÊ ÔÑíØ ÇáÍíÇÉ
[System.Serializable]
public class HealthBarSettings
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

// 2. ßæÏ ÇáäÙÇã æÅÏÇÑÉ ÇáÕÍÉ (äİÓ ÇÓã ãáİßö ÊãÇãÇğ)
public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarSettings healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // ÇÖÛØí ÍÑİ G İí ÇááÚÈÉ áÊÌÑÈÉ äŞÕ ÇáÕÍÉ
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        healthBar.SetHealth(currentHealth);
    }
}