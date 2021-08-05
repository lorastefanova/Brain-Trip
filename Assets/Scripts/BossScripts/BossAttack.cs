using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private int projectileNum; // Number of projectiles

    [SerializeField]
    private float radius; // Radius variable

    [SerializeField]
    private float speed; // Speed variable

    [SerializeField]
    private Transform mouth; // Mouth transform

    [SerializeField]
    private GameObject projectilePrefab; // Projectile prefab

    [SerializeField]
    private GameObject enemyPrefab; // Enemy prefab

    [SerializeField]
    private GameObject basicEnemyPrefab; // Basic enemy prefab

    public PlayerHpBar playerHp; // Player current health

    void Start()
    {
        BossPower(); // Determine the boss power
    }

    // Function to instantiate projectiles in a circle
    public void CircleShoot()
    {
        float angleStep = 360f / projectileNum; // Angle step variable
        float angle = 0f; // Angle variable

        for (int i = 0; i <= projectileNum; i++) // For loop of projectiles
        {
            float projectileDirectionX = mouth.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius; // Projectile direction x variable
            float projectileDirectionY = mouth.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius; // Projectile direction y variable

            Vector3 projectileVector = new Vector3(projectileDirectionX, projectileDirectionY); // Projectile vector variable
            Vector3 projectileMoveDirection = (projectileVector - mouth.position).normalized * speed; // Projectile movement direction variable

            GameObject go = Instantiate(projectilePrefab, mouth.position, Quaternion.identity); // Instantiate the prefab at mouth's position
            go.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y); // Set velocity

            angle += angleStep; // Angle += angle step

            Destroy(go, 5.0f); // Destroy projectile after 5 seconds
        }

    }

    // Function to shoot in a straight line
    public void BasicShoot()
    {
        GameObject go = Instantiate(projectilePrefab, mouth.position, Quaternion.identity); // Instantiate the prefab at mouth's position

        Vector3 direction = new Vector3(transform.localScale.x, 0); // Direction variable

        go.GetComponent<Projectile>().SetUp(direction); // Set up the direction
        Destroy(go, 3.0f); // Destroy projectile after 3 seconds
    }

    // Function to spawn enemies
    public void SpawnEnemies()
    {
        GameObject go = Instantiate(enemyPrefab, mouth.position, Quaternion.identity); // Instantiate the prefab at mouth's position

        Vector3 direction = new Vector3(transform.localScale.x, 0); // Direction variable

        go.GetComponent<Projectile>().SetUp(direction); // Set up the direction
        Destroy(go, 15.0f); // Destroy projectile after 15 seconds
    }

    // Function to spawn basic enemies
    public void SpawnEnemiesBasic()
    {
        GameObject go = Instantiate(basicEnemyPrefab, mouth.position, Quaternion.identity); // Instantiate the prefab at mouth's position

        Vector3 direction = new Vector3(transform.localScale.x, 0); // Direction variable

        go.GetComponent<Projectile>().SetUp(direction); // Set up the direction
        Destroy(go, 20.0f); // Destroy projectile after 20 seconds
    }

    // Function to determine boss power
    private void BossPower()
    {
        switch (ScoreScript.instance.score) // Depending on the score
        {
            case 1:
                projectileNum = 35; 
                speed = 7;
                playerHp.dmgTaken = 90;
                break;
            case 2:
                projectileNum = 30;
                speed = 6;
                playerHp.dmgTaken = 60;
                break;
            case 3:
                projectileNum = 25;
                speed = 5;
                playerHp.dmgTaken = 40;
                break;
            case 4:
                projectileNum = 15;
                speed = 4;
                playerHp.dmgTaken = 20;
                break;
            case 5:
                projectileNum = 10;
                speed = 3;
                playerHp.dmgTaken = 15;
                break;
            default:
                projectileNum = 40;
                speed = 8;
                playerHp.dmgTaken = 90;
                break;
        }
    }
}
