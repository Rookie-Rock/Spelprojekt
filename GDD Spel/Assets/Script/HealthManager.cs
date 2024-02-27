using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar;
    public float healthAmount = 100f;
    public Slider slider;

    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
           TakeDamage(20);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           Heal(5);
        }

        
    }

    public void TakeDamage(float damage)
    {
        slider.value = healthAmount - damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); // Begräns healthAmount mellan 0 och 100

        Debug.Log("Health after taking damage: " + healthAmount); // Lägg till en logg för att kontrollera healthAmount

       

        UpdateHealthBar();
    }

    public void Heal(float healingAmount)
    {
       slider.value = healthAmount + healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); // Begräns healthAmount mellan 0 och 100

        Debug.Log("Health after healing: " + healthAmount); // Lägg till en logg för att kontrollera healthAmount

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        HealthBar.fillAmount = healthAmount / 100f; // Uppdatera HealthBar.fillAmount
    }
}
