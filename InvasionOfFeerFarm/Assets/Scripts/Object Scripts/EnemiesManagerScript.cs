using UnityEngine;

public class EnemiesManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private DayNightSingleton instance;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnAreaAverage;




    void Start()
    {
        instance = DayNightSingleton.instance;

        instance.newNight.AddListener(SpawnEnemies);
        instance.newDay.AddListener(GoAway); // probably temporary
        transform.position = new Vector2(1000, 1000);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        transform.position = new Vector2(spawnAreaAverage.x + Random.Range(-10,10), spawnAreaAverage.y + Random.Range(-10, 10));

        int enemies = Random.Range(5 + instance.cycles, 11 + instance.cycles);
        for (int i = 0; i < enemies; i++)
        {
            GameObject newInstance = Instantiate(enemy, transform.position, Quaternion.identity);
            instance.enemiesRemaining++;
        }
    }

    private void GoAway()
    {
        transform.position = new Vector2(1000, 1000);
    }
}
