using UnityEngine;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour
{
    Stack<Vector3> checkpoints =
        new Stack<Vector3>();

    public Transform player;

    CharacterController cc;

    void Start()
    {
        cc = player.GetComponent<CharacterController>();

        Guardar(player.position);
    }

    public void Guardar(Vector3 pos)
    {
        checkpoints.Push(pos);
    }

    public void Regresar()
    {
        if (checkpoints.Count > 0)
        {
            cc.enabled = false;

            player.position = checkpoints.Peek() + Vector3.up;

            cc.enabled = true;
        }
    }
}