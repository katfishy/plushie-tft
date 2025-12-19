using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float damagePerSecond = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        // Debugging Log
        Debug.Log(gameObject.name + " spawned with HP: " + currentHP);
        StartCoroutine(ApplyDamageOverTime());
        
    }

    // Update is called once per frame
    // IEnumerator is time based, so use this instead of update
    IEnumerator ApplyDamageOverTime()
    {
        while (currentHP > 0)
        {
            currentHP -= damagePerSecond;
            Debug.Log(gameObject.name + "'s HP: " + currentHP);

            if (currentHP <= 0)
            {
                currentHP = 0;
                Debug.Log(gameObject.name + " died!");
                Destroy(gameObject);
                yield break; // stop the coroutine
            }

            yield return new WaitForSeconds(1f); // wait 1 second
        }
    }
}
