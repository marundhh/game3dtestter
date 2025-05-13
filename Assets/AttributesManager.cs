using UnityEngine;
using UnityEngine.UI;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Slider healthSlider;
    public int attack;
    public float critDamage = 1.5f;
    public float critChance = 0.5f;
    public int armor;
    public GameObject coinPrefab;
    public AudioClip playerHitSound;
    public AudioClip enemyHitSound;
    public GameObject gameOverCanvas;
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = 1;
            healthSlider.value = (float)health / maxHealth;
        }

    }

    public void TakeDamage(int amount)
    {
        if (health <= 0) return; // Nếu đã chết, không trừ máu tiếp

        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        DamagePopUpGenerator.Current.CreatePopUp(
            transform.position,
            amount.ToString(),
            Color.yellow
        );

        if (gameObject.CompareTag("Player"))
        {
            if (healthSlider != null)
            {
                healthSlider.value = (float)health / maxHealth;
            }

            if (playerHitSound != null)
            {
                audioSource.PlayOneShot(playerHitSound);
            }

            if (health <= 0)
            {
                PlayerDie();
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            Slider slider = gameObject.transform
                .GetChild(1).transform
                .GetChild(0).transform
                .GetComponent<Slider>();
            slider.value = health;

            if (enemyHitSound != null)
            {
                audioSource.PlayOneShot(enemyHitSound);
            }

            if (health <= 0)
            {
                EnemyDie();
            }
        }
    }

    private void PlayerDie()
    {
        Debug.Log("Player died!");

      
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Game Over Canvas is not assigned!");
        }
    }

    public void EnemyDie()
    {
        Debug.Log("Enemy died");
        SpawnCoin();
        Destroy(gameObject);
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            float totalDamage = attack;
            if (Random.Range(0f, 1f) < critChance)
            {
                totalDamage *= critDamage;
            }
            atm.TakeDamage((int)totalDamage);
        }
    }

    private void SpawnCoin()
    {
        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Coin prefab is not assigned!");
        }
    }
}
