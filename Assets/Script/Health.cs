using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Threading;

public class Health : MonoBehaviour
{
    //public QTE2Script qte2Script;
    public Volume postProcessingVolume;

   // private VolumeProfile volumeProfile;
    private ColorAdjustments colorAdjustments;
    private Vignette vignette;
    //public Text healthText;
    public Image healthBar;
    private GameObject _deathScreen;

    public float health, maxHealth = 100;
    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _deathScreen = GameObject.Find("DeathScreen");
        _deathScreen.SetActive(false);
        health = 40;
  
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth) health = maxHealth;

        lerpSpeed = 5f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        if (health <= 0)
        {
            Thread.Sleep(1000);
            _deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
       /* if (health >= 0)
        {
            vignette.intensity.value = 0.95f;
            colorAdjustments.saturation.value = -100f;
        }

           if (health >= 10)
        {
            vignette.intensity.value = 0.9f;
            colorAdjustments.saturation.value = -90f;
        }

           if (health >= 20)
        {
            vignette.intensity.value = 0.85f;
            colorAdjustments.saturation.value = -80f;
        }

           if (health >= 30)
        {
            vignette.intensity.value = 0.8f;
            colorAdjustments.saturation.value = -70f;
        }

           if (health >= 40)
        {
            vignette.intensity.value = 0.75f;
            colorAdjustments.saturation.value = -60f;
        }

           if (health >= 50)
        {
            vignette.intensity.value = 0.73f;
            colorAdjustments.saturation.value = -50f;
        }
        
        
           if (health >= 60)
        {
            vignette.intensity.value = 0.7f;
            colorAdjustments.saturation.value = -40f;
        }
        
           if (health >= 70)
        {
            vignette.intensity.value = 0.67f;
            colorAdjustments.saturation.value = -30f;
        }
        
           if (health >= 80)
        {
            vignette.intensity.value = 0.64f;
            colorAdjustments.saturation.value = -20f;
        }
        
           if (health >= 90)
        {
            vignette.intensity.value = 0.6f;
            colorAdjustments.saturation.value = -10f;
        }
        
           if (health >= 100)
        {
            vignette.intensity.value = 0.55f;
            colorAdjustments.saturation.value = 0f;
        }*/
     
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
