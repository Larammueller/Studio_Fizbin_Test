using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //change in inspector for different players
    [SerializeField]
    private bool m_bIsPlayer1 = true;
    public bool bIsPlayer1
    {
        get { return m_bIsPlayer1; }
        set { m_bIsPlayer1 = value; }
    }
}
