using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] float m_ItemSpawnTime = 7f;

    public List<GameObject> objs = new List<GameObject>();

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
                if(Random.value < 0.25)
                {
                    Spawn(randLane, gameLane, lane, 0);
                }
                else
                {
                    Spawn(randLane, gameLane, lane, 1);
                }
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

    public void Spawn(int randLane, Transform gameLane, Lane lane, int list_num)
    {
        int spawnPoint = Random.Range(1, 4);

        //Transform of rock platform
        var rockSpawnPoint = gameLane.GetChild(spawnPoint);

        GameObject go = Instantiate(objs[list_num], rockSpawnPoint.position, Quaternion.identity, rockSpawnPoint);

        Debris debris = go.GetComponent<Debris>();

        debris.SetLane(randLane);
        debris.debrisDestroyed.AddListener(OnDebrisDestroyed);

        lane.Occupy();
    }
}
