using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // all the monster assets or posible enemy respawn
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    // store the left and right position where enemy will spawn
    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonsters()); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    IEnumerator spawnMonsters()
    {
        // spawn it forever
        while (true)
        {
            //random time when enemy will respawn
            // yield is the stopper or waiter of while loop because a courotine needs to wait
            yield return new WaitForSeconds(Random.Range(1, 5));



            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            // Instantiate is creating a copy of passed parameter

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                // set the spawnedMoster position into the left
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
