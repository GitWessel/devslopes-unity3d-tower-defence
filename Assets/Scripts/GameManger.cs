using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public GameObject spawnPoint;
    public GameObject[] enemies;

    public int MaxEnemiesOnScreen { get; private set; }
    public int TotalEnemies { get; private set; }
    public int EnemiesPerSpawn { get; private set; }

    public int EnemiesOnScreen { get; private set; }

    private void StartingValues()
    {
        EnemiesOnScreen = 0;
        MaxEnemiesOnScreen = 1;
        TotalEnemies = 1;
        EnemiesPerSpawn = 1;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            StartingValues();
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (EnemiesPerSpawn <= 0 || EnemiesOnScreen >= TotalEnemies) return;
        for (var i = 0; i < EnemiesPerSpawn; i++)
        {
            if (EnemiesOnScreen >= MaxEnemiesOnScreen) continue;
            var newEnemy = Instantiate(enemies[0]);
            newEnemy.transform.position = spawnPoint.transform.position;
            EnemiesOnScreen += 1;
        }
    }

    public void RemoveEnemyFromScreen()
    {
        if (EnemiesOnScreen > 0)
        {
            EnemiesOnScreen -= 1;
        }
    }
}
