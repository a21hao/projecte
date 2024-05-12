using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Vector3> positions;
    [SerializeField]
    private float speed;
    private Vector3 target;
    private int wayPoint = 1;
    void Start()
    {
        target = positions[wayPoint];
        Vector3 dir = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target) <= 0.7f)
        {
            GetNextWaypoint();

        }
    }

    void GetNextWaypoint()
    {
        if (wayPoint >= positions.Count - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        wayPoint++;
        target = positions[wayPoint];
        Vector3 dir = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = rotation;
    }

    public void setPositions(List<Vector3> pos)
    {
        positions = pos;
    }
}
