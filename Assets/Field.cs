using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private Color _color;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<MeshRenderer>().material.color = _color;
    }
}
