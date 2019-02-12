using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //enemy = 1
    //player = 3

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        Debug.Log(transform.name + " died.");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
