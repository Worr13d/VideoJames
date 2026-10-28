using UnityEngine;

public class EnemiesManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private DayNightSingleton instance;
    [SerializeField] private GameObject enemy;




    void Start()
    {
        instance = DayNightSingleton.instance;

        instance.newNight.AddListener(SpawnEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        int enemies = Random.Range(5 + instance.cycles, 11 + instance.cycles);
        for (int i = 0; i < enemies; i++)
        {
            GameObject newInstance = Instantiate(enemy, transform.position, Quaternion.identity);
            instance.enemiesRemaining++;
        }
    }
}
