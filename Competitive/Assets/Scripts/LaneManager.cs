using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] float m_ItemSpawnTime = 7f;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawningCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        if(Random.value < 0.40)
        {
            int randLane = Random.Range(0, 3);

            //Transform of Top, Mid, Bot
            var gameLane = this.transform.GetChild(randLane);

            //Lane Script
            var lane = gameLane.GetComponent<Lane>();

            if (!lane.IsOccupied())
            {
                int spawnPoint = Random.Range(1, 4);

                //Transform of rock platform
                var rockSpawnPoint = gameLane.GetChild(spawnPoint);

                GameObject go = Instantiate(obj, rockSpawnPoint.position, Quaternion.identity, rockSpawnPoint);

                Debris debris = go.GetComponent<Debris>();

                debris.SetLane(randLane);
                debris.debrisDestroyed.AddListener(OnDebrisDestroyed);

                lane.Occupy();
            }
        }
    }

    public void OnDebrisDestroyed(int lane)
    {
        Debug.Log(lane);
        this.transform.GetChild(lane).GetComponent<Lane>().Vacate();
    }

    private IEnumerator StartSpawningCoroutine()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(m_ItemSpawnTime);
            SpawnObject();
        }
    }
}
