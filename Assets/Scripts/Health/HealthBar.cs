using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //[SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    //Get the Health of the character using delegate and event 
    public delegate float PlayerHealth();
    public static event PlayerHealth playerHealth;

    private void Start()
    {
        // display the empty health/ heart
        if (playerHealth != null)
        {
            totalhealthBar.fillAmount = playerHealth() / 10;
            print(totalhealthBar.fillAmount);

        }

    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth() / 10;
    }
}
