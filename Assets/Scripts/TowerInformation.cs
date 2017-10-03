using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Faction
{
    Player,
    AI,
    Neutral
}

public class TowerInformation : MonoBehaviour {

    public Sprite sprite;
    [Range(1,3)]
    public int level;
    public float productionRate;
    // How far is the current Production
    [HideInInspector]
    public float currentProductionTime;

    public int soldierLimit;
    [Range(0, 200)]
    public int currentSoldiers;

    public float sendTime;
    [HideInInspector]
    public float timeToNext;

    public Faction faction;
    


	// Use this for initialization
	void Start () {
		
	}
	
    public bool ProductionUpdate()
    {
        if(currentSoldiers < soldierLimit)
            currentProductionTime -= Time.deltaTime;
        if(timeToNext <= 0)
        {
            timeToNext = productionRate;
            currentSoldiers++;
            return true;
        }
        return false;
    }

    public bool MobilizationUpdate()
    {
        if(timeToNext >= 0)
            timeToNext -= Time.deltaTime;
        if(currentSoldiers > 1)
        {
            if(timeToNext < 0)
            {
                timeToNext = sendTime;
                return true;
            }
        }
        return false;
    }

	// Update is called once per frame
	void Update () {
		
	}


}
