using UnityEngine;

public class ScrollerObject : MonoBehaviour {

    private Rigidbody2D RIGIDBODY;
    [SerializeField] private float m_Speed;
    [SerializeField] private bool m_stopScrolling;

    void Start() {
        m_Speed = -m_Speed;
        RIGIDBODY = GetComponent<Rigidbody2D>();
        RIGIDBODY.velocity = new Vector2(m_Speed, 0);
    }

}
