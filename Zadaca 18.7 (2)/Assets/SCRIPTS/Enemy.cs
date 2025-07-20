using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;

    private int maxHP = 3;
    private int currentHP;
    public float speed = 2f;

    private Transform player;
    private GameManager gameManager;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPText();

        Player playerObj = FindAnyObjectByType<Player>();
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (player == null) return;
        transform.LookAt(player);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;
        UpdateHPText();

        if (currentHP == 0)
        {
            Die();
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {currentHP}";
        }
    }

    void Die()
    {
        if (gameManager != null)
        {
            gameManager.score++;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

