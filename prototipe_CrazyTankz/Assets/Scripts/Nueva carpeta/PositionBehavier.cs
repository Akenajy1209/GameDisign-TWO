using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBehavier : MonoBehaviour
{
    [SerializeField]
    public int Level= 1;
    public bool pos1 = false;
    public bool pos2 = false;
    public bool pos3 = false;
    public bool pos4 = false;
    public bool pos5 = false;
    public bool pos6 = false;
    public bool pos7 = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Level == 1)
        {
           pos1 = pos2 = pos3 = pos4 = pos5 = true;
        }
        if (Level == 2)
        {
            pos1 = pos2 = pos3 = pos4 = pos5 = pos6 = pos7 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
