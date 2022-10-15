using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public float damage;

    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    public int maxHealth = 1;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        Health.monsterDamage += monsterDamageSend;
    }
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // velocity forces the character to move left and right/ up and down
        // speed param is to be able to push player to move and myBody.velocity.y to move left and right because of Y-axis
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
    float monsterDamageSend()
    {
        return damage;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        print("Enemy Died");
        Destroy(gameObject);
    }
}
