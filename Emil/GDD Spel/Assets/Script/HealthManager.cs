using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar;
    public float healthAmount = 100f;
    public Slider slider;
    public float takeDamage = 20f;
    public float heal = 5f;

    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(takeDamage);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(heal);
        }
    }

    public void TakeDamage(float damage)
    {
        float newHealth = healthAmount - damage; // Skapa en tempor�r variabel f�r att hantera skadan
        healthAmount = Mathf.Clamp(newHealth, 0, 100); // Begr�ns healthAmount mellan 0 och 100

        Debug.Log("Health after taking damage: " + healthAmount); // L�gg till en logg f�r att kontrollera healthAmount

        slider.value = healthAmount; // Uppdatera slider-v�rdet
        UpdateHealthBar();
    }

    public void Heal(float healingAmount)
    {
        float newHealth = healthAmount + healingAmount; // Skapa en tempor�r variabel f�r att hantera healande
        healthAmount = Mathf.Clamp(newHealth, 0, 100); // Begr�ns healthAmount mellan 0 och 100

        Debug.Log("Health after healing: " + healthAmount); // L�gg till en logg f�r att kontrollera healthAmount

        slider.value = healthAmount; // Uppdatera slider-v�rdet
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        HealthBar.fillAmount = healthAmount / 100f; // Uppdatera HealthBar.fillAmount
    }
}
