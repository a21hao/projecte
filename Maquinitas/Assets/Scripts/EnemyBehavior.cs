using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EventReference buySound;

				[SerializeField]
				private ParticleSystem SiItem;

				[SerializeField]
				private ParticleSystem NoItem;

				public float speed = 3f;

    private Transform target;
    private int wayPoint = 1;
    private MovementBehavior _mvb;

    // Start is called before the first frame update
    void Start()
    {
        target = PathBehavior.Waypoints[2];
        _mvb = GetComponent<MovementBehavior>();
        Vector3 dir = target.position - transform.position;
        //Debug.Log(dir);
        Quaternion rotation = Quaternion.LookRotation(dir);
        
        //Debug.Log(rotation);

        // Aplica la rotación al objeto
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
    }
    void OnTriggerEnter(Collider other)
    {
        /*if(other.TryGetComponent<AAA>(out AAA Vending_)){
            Vending_.Buy();
            AudioManager.instance.PlayOneShot(buySound, this.transform.position);
        }*/
        if (other.TryGetComponent<MachineInventory>(out MachineInventory Vending_))
        {
            Vending_.VenderItem(1, 1);
            AudioManager.instance.PlayOneShot(buySound, this.transform.position);
												Instantiate(SiItem, this.transform.position, this.transform.rotation);
        }
								else
								{
												Instantiate(NoItem, this.transform.position, this.transform.rotation);
								}
    }
}
