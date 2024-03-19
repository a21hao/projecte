using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBehavior : MonoBehaviour
{

    public float speed = 3f;

    private Transform target;
    private int wayPoint = 1;
    private MovementBehavior _mvb;

    // Start is called before the first frame update
    void Start()
    {
        target = PathBehavior.Waypoints[1];
        _mvb = GetComponent<MovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wayPoint >= PathBehavior.Waypoints.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        wayPoint++;
        target = PathBehavior.Waypoints[wayPoint];
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<AAA>(out AAA Vending_)){
            Vending_.Buy();
        }
    }
}
