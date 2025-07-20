using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float rotationSpeed = 100f;

    public TMP_Text hpText; 
    private int maxHP = 10;
    private int currentHP;


    void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
    }

    void Update()
    {
       
        float rotation = 0f;
        if (Input.GetKey(KeyCode.A))
            rotation = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotation = 1f;

        transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            
            rigidbody.linearVelocity = shootPoint.forward * 10f;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;
        UpdateHPText();

        if (currentHP == 0)
        {
            Debug.Log("GAME OVER");
            
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {currentHP}";
        }
    }
}



