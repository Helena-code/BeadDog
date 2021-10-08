using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    public int Keys
    {
        set { _keys = value; }
    }

    [SerializeField] private List<PortalScr> _doors = new List<PortalScr>();

    private int _keys;



}
