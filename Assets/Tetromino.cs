using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions {DOWN, LEFT, RIGHT};

public class Tetromino : MonoBehaviour
{
    private float _blockWidth = 1f;
    private float _distancePerFrame = 0.1f;
    private Vector3 _fall = Vector3.down;
    private List<Transform> _blocks = new List<Transform>();
    private Color _color = Color.green;
    private bool _isMoving = false;
    private Dictionary<Directions, Vector3> dict = new Dictionary<Directions, Vector3>()
    {
        { Directions.DOWN, Vector3.down },
        { Directions.LEFT, Vector3.left },
        { Directions.RIGHT, Vector3.right }
    };

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            _blocks.Add(transform.GetChild(i));

        foreach (Transform block in _blocks)
            block.GetComponent<MeshRenderer>().material.color = _color;
    }

    public void Fall()
    {
        if (WillFit(_fall))
            StartCoroutine(AnimateMove(dict[Directions.DOWN]));
        else
            LockInPlace();
    }

    public void Move(Directions direction)
    {
        if (!_isMoving && WillFit(dict[direction]))
            StartCoroutine(AnimateMove(dict[direction]));
    }

    public void Rotate()
    {
        if (WillFit(_fall))
            transform.Rotate(Vector3.back, 90);
    }

    private bool WillFit(Vector3 to)
    {
        //var temp = transform;
        //transform.Translate(to, Space.World);
        return true;
    }

    private void LockInPlace()
    {

    }

    private IEnumerator AnimateMove(Vector3 direction)
    {
        if (_isMoving) Debug.Log("Oops!");
        _isMoving = true;
        var start = transform.position;
        var end = transform.position + direction;

        for (float i = 0; i <= 1; i += _distancePerFrame)
        { 
            transform.position = Vector3.Lerp(start, end, i);
            yield return new WaitForFixedUpdate();
        }
        _isMoving = false;
    }
}
