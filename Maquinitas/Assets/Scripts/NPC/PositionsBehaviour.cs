using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> positions;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPositions(List<Vector3> positionss)
    {
        positions = positionss;
    }

    public List<Vector3> GetPositions()
    {
        return positions;
    }
}
