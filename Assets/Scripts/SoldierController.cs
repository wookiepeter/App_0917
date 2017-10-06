using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour {

    public Faction owner;

    public TowerController Target;

    public float speed;

    float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // DEBUG 
        if (Target == null)
            Target = FindObjectOfType<TowerManager>().enemyTowers[0].GetComponent<TowerController>();

        float distanceToTarget = Vector3.Distance(Target.gameObject.transform.position, this.gameObject.transform.position);
        if(distanceToTarget < 0.1)
        {
            // End 
            Debug.Log("Im There");
            return;
        }

        Vector3 vectorToTarget = Target.gameObject.transform.position - this.gameObject.transform.position;
        gameObject.transform.position += vectorToTarget.normalized * speed;



        Debug.Log("Angle: " + Vector3.Angle(Vector3.up, Target.gameObject.transform.position - this.gameObject.transform.position));
       // gameObject.transform.rotation =  Vector3.Angle(Vector3.up, Target.gameObject.transform.position - this.gameObject.transform.position));
        gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, Target.gameObject.transform.position - this.gameObject.transform.position);
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1),
            Mathf.Sin(Vector3.Distance(Target.gameObject.transform.position, this.gameObject.transform.position)) * 10);


	}
}
