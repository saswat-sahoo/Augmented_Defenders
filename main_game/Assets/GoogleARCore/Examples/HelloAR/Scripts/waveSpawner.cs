using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
	/*public static int EnemiesAlive = 0;

    
	private bool isspawning=true;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	public GameObject enemyprfab;

	public Text waveCountdownText;



	private int wavenumber = 1;*/


	//public static int EnemiesAlive = 0;
	private GameObject[] enemy;
	public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private Vector3 scale;
	public GameObject enemyprfab;
    //public Text waveCountdownText;
    private int wavenumber = 0;


    

    void Update()
	{
		enemy = GameObject.FindGameObjectsWithTag("zombie");
		if(enemy.Length>=wavenumber && enemy.Length!=0)
        {
			return;
        }

		scale = GameObject.FindGameObjectWithTag("prefab").transform.localScale;

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		//waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave()
	{
		wavenumber++;

		for (int i = 0; i < wavenumber; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}


	}

	void SpawnEnemy()
	{
		Vector3 position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z +Random.Range(-2f,4f)*(scale.magnitude));
		

		GameObject zombie= (GameObject) Instantiate(enemyprfab, position, spawnPoint.rotation);
		zombie.transform.parent = spawnPoint;
		float sc =  1.25f;
		zombie.transform.localScale =new Vector3(sc, sc, sc);
	}









}
