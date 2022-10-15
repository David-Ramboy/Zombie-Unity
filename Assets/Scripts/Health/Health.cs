using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject gameobjectRef;
   [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;

    private string ENEMY_TAG = "Enemy";

    // get the damage of the gameobject monster using delegates
    public delegate float MonsterDamage();
    public static event MonsterDamage monsterDamage;
    bool isDied = true;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        HealthBar.playerHealth += playerHealthSend;
        Player.died += isDiedya;

    }

    bool isDiedya()
    {
        return isDied;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth == 0)
        {
            anim.SetTrigger("Die");

            isDied = false;
            print(gameobjectRef.layer);
            gameobjectRef.layer = LayerMask.NameToLayer("Enemy");
            print(gameobjectRef.layer);
        }
      
    }

   

    float playerHealthSend()
    {
        return currentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            if (isDied)
            {
                TakeDamage(monsterDamage());

            }
        }
    }
}
