using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    //public QTE2Script qte2Script;
    public Volume postProcessingVolume;
    private Bloom _bloom;
    public Text healthText;
    public Image healthBar;

    public float health, maxHealth = 100;
    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = 40;
        if (postProcessingVolume.profile.TryGet(out _bloom))
    {
        // Successfully retrieved the Bloom component
        // Now you can use _bloom to modify the bloom intensity
    }
    else
    {
        Debug.LogWarning("Bloom component not found in the post-processing volume.");
    }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + "%";
        if(health > maxHealth) health = maxHealth;

        lerpSpeed = 5f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        if (health >= 0)
        {
            _bloom.intensity.value = 1f;
        }

           if (health >= 10)
        {
            _bloom.intensity.value = 2f;
        }

           if (health >= 20)
        {
            _bloom.intensity.value = 3f;
        }

           if (health >= 30)
        {
            _bloom.intensity.value = 4f;
        }

           if (health >= 40)
        {
            _bloom.intensity.value = 5f;
        }

           if (health >= 50)
        {
            _bloom.intensity.value = 6f;
        }
     
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }

    public void Damage(float damagePoints)
    {
        if(health > 0)
        {
            health -= damagePoints;
        }
    }

    public void Heal(float healingPoints)
    {
        if(health < maxHealth)
        {
            health += healingPoints;
        }
    }
}
