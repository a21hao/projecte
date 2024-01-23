using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
				[SerializeField]
				private Path _path;

				[SerializeField]
				private float _speed;

				private int _targetWaypointIndex;

				private Transform _previousWaypoint;
				private Transform _targetWaypoint;

				private float _timeToWaypoint;
				private float _elapsedTime;


				void Start()
				{
								TargetNextWaypoint();
				}

				void FixedUpdate()
				{
								_elapsedTime += Time.deltaTime;

								float elapsedPercentage = _elapsedTime / _timeToWaypoint;
								elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
								transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
								transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

								if (elapsedPercentage >= 1)
								{
												TargetNextWaypoint();
								}
				}

				private void TargetNextWaypoint()
				{
								_previousWaypoint = _path.GetWaypoint(_targetWaypointIndex);
								_targetWaypointIndex = _path.GetNextWaypointIndex(_targetWaypointIndex);
								_targetWaypoint = _path.GetWaypoint(_targetWaypointIndex);

								_elapsedTime = 0;

								float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
								_timeToWaypoint = distanceToWaypoint / _speed;
				}

				private void OnTriggerEnter(Collider other)
				{
								other.transform.SetParent(transform);
				}

				private void OnTriggerExit(Collider other)
				{
								other.transform.SetParent(null);
				}
}
