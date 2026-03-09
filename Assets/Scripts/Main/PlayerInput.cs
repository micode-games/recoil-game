using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsShotPressed()
    {
        return Input.GetMouseButtonDown(0);
    }
}
