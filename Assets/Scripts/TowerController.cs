using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public GameObject infoObject;

    public TowerInformation info;
    public Animator animator;

    bool isAttcking;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("TowerOwner", (int)info.faction);
        if(info.ProductionUpdate())
        {
            
        }
        if(isAttcking)
        {
            if(info.MobilizationUpdate())
            {

            }
        }

	}

    public void InitializeTowerInformation(GameObject _infoObject)
    {
        infoObject = _infoObject;
        info = infoObject.GetComponent<TowerInformation>();

        gameObject.GetComponentInParent<SpriteRenderer>().sprite = info.sprite;
    }

    public void SetTowerInformation(GameObject _infoObject)
    {
        TowerInformation _info = _infoObject.GetComponent<TowerInformation>();

        _info.currentSoldiers = info.currentSoldiers;
        _info.currentProductionTime = info.currentProductionTime;
        _info.timeToNext = info.timeToNext;

        info = _info;
    }
}
