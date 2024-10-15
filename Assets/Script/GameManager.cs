using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int n;
    public GameObject Nodes;
    public int root;
    // Start is called before the first frame update
    void Awake()
    {
        n = Nodes.transform.childCount;
    }
}
