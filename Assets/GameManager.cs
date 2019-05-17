using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _frame = 0;
    private int _loopSpeed = 100;
    public Tetromino t;

    private void Update()
    {
        if (Input.GetKeyDown("up")) t.Rotate();
        if (Input.GetKey("left")) t.Move(Directions.LEFT);
        if (Input.GetKey("right")) t.Move(Directions.RIGHT);
    }

    private void FixedUpdate ()
    {
        _frame++;
        if (_frame >= _loopSpeed)
        {
            _frame = 0;
            t.Move(Directions.DOWN);
        }
	}
}
