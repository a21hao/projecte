using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PointsVendingMachine : MonoBehaviour
{
    private GameObject[] pointsVendingMachineTransform;// Array para almacenar los hijos
    [SerializeField]
    private float DistanceToObject;

    public class PointVending
    {
        public Transform transformPoint;
        public bool isBusy;
        
    }

    private PointVending[] pointsVendingMachine;

    private void Start()
    {
        // Obtén todos los hijos del objeto padre
        int cantidadHijos = gameObject.transform.childCount;
        pointsVendingMachineTransform = new GameObject[cantidadHijos];

        for (int i = 0; i < cantidadHijos; i++)
        {
            pointsVendingMachineTransform[i] = gameObject.transform.GetChild(i).gameObject;
        }
        pointsVendingMachine = new PointVending[cantidadHijos];
        for(int i = 0; i < cantidadHijos; i++)
        {
            PointVending pointVend = new PointVending();
            pointVend.transformPoint = pointsVendingMachineTransform[i].transform;
            pointVend.isBusy = false;
            pointsVendingMachine[i] = pointVend;
            //pointsVendingMachine[i].transformPoint = pointsVendingMachineTransform[i].transform;
            //pointsVendingMachine[i].isBusy = false;
        }
 



        // Ahora tienes todos los hijos en el array "hijosArray"
        // Puedes acceder a ellos según su índice (por ejemplo, hijosArray[0] para el primer hijo)
    }

    // Update is called once per frame
    void Update()
    {

    }

    public PointVending isNearSomePoint(Vector3 point)
    {
        PointVending PointVendingToReturn;
        float minDistance;
        int index = 0;
        if (pointsVendingMachine != null)
        {
            if (pointsVendingMachine.Length > 0)
            {
               
                 minDistance = Vector3.Distance(pointsVendingMachine[0].transformPoint.position, point);
                 PointVendingToReturn = pointsVendingMachine[0];
             
                
                for (int i = 0; i <pointsVendingMachine.Length; i++)
                {
                    if (Vector3.Distance(pointsVendingMachine[i].transformPoint.position, point) < minDistance)
                    {
                        minDistance = Vector3.Distance(pointsVendingMachine[i].transformPoint.position, point);
                        PointVendingToReturn = pointsVendingMachine[i];
                        index = i;
                    }
                }
                if (minDistance <= DistanceToObject)
                {
                    
                    if(!PointVendingToReturn.isBusy)
                    return PointVendingToReturn;                  
                }
                
             }
            
        }
        return null;
        
    }

    public void changePointVendingToBusy(PointVending pv, bool isBusy)
    {
        int index = Array.IndexOf(pointsVendingMachine, pv);
        if(index != -1)
        {
            pointsVendingMachine[index].isBusy = isBusy;
        }
        
        
    }

            /*if (pointsVendingMachine.Length > 0)
            {
                private float minDistance = Vector3.Distance(pointsVendingMachine[i].transform.position, point);
                
            }
    
        }
        else
        {

        }
        return null;
    }*/
        
    
}
