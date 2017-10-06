using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public GameObject[] prefabs;

    public List<TowerController> playerTowers;
    public List<TowerController> enemyTowers;

    public GameObject TowerPrefab;

    public Rect rectangle = new Rect(-7, 4, 14, 8);

	// Use this for initialization
	void Start () {
        SpawnTowers(2, 10, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnTowers(int player, int neutral, int enemy)
    {
        playerTowers = new List<TowerController>();
        enemyTowers = new List<TowerController>();

        SpawnTowersForFaction(Faction.Player, player);
        SpawnTowersForFaction(Faction.Neutral, neutral);
        SpawnTowersForFaction(Faction.AI, enemy);
    }

    void SpawnTowersForFaction(Faction faction, int value)
    {
        while (value > 0)
        {
            int curValue = (int)(Random.Range(1, (4 > value) ? value+1 : 4));

            value -= curValue;

            Debug.Log(curValue);

            GameObject newTower = Instantiate(TowerPrefab);
            newTower.transform.position = GetRandomPositionInRect();

            GameObject newInfo = Instantiate(prefabs[curValue - 1]);
            newTower.GetComponent<TowerController>().InitializeTowerInformation(newInfo);
            newInfo.GetComponent<TowerInformation>().faction = faction;

            newTower.transform.parent = this.gameObject.transform;
            newInfo.transform.parent = newTower.transform;

            if (faction == Faction.Player)
                playerTowers.Add(newTower.GetComponent<TowerController>());
            else if (faction == Faction.AI)
                enemyTowers.Add(newTower.GetComponent<TowerController>());
        }
    }

    public Vector3 GetRandomPositionInRect()
    {
        return new Vector3(Random.Range(rectangle.xMin, rectangle.xMax), Random.Range(rectangle.yMin, rectangle.yMax), 0);
    }
}
