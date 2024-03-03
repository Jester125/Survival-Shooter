using UnityEngine;

namespace CompleteProject
{
    public class SpawnManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject bunny;
        public GameObject bear;
        public GameObject helle; // The enemy prefab to be spawned.
        public float BunnySpawnTime;
        public float BearSpawnTime;
        public float HelleSpawnTime; // How long between each spawn.
        public Transform[] bunnySpawnPoints;         // An array of the spawn points this enemy can spawn from.
        public Transform[] bearSpawnPoints;
        public Transform[] helleSpawnPoints;

        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("SpawnBunny", BunnySpawnTime, BunnySpawnTime);
            InvokeRepeating("SpawnBear", BearSpawnTime, BearSpawnTime);
            InvokeRepeating("SpawnHelle", HelleSpawnTime, HelleSpawnTime);
        }


        void SpawnBunny ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, bunnySpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (bunny, bunnySpawnPoints[spawnPointIndex].position, bunnySpawnPoints[spawnPointIndex].rotation);
        }
        void SpawnBear()
        {
            // If the player has no health left...
            if (playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, bearSpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(bear, bearSpawnPoints[spawnPointIndex].position, bearSpawnPoints[spawnPointIndex].rotation);
        }
        void SpawnHelle()
        {
            // If the player has no health left...
            if (playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, helleSpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(helle, helleSpawnPoints[spawnPointIndex].position, helleSpawnPoints[spawnPointIndex].rotation);
        }
    }
}