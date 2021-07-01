using UnityEngine;

namespace qASIC.Demo
{
	public class EnemyController : MonoBehaviour
	{
        public enum EnemyState { idle, chasing }
        public EnemyState state = EnemyState.idle;

        public float ActivateRange = 10f;
        public float speed = 4f;

        Rigidbody2D rb;

        float time;

        public float idleSpinSpeed;
        public float chasingSpinSpeed;

        public static bool IsActive { get; set; } = true;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null) qDebug.LogError("There is no Rigidbody2D on enemy!");
        }

        private void Update()
        {
            time += Time.deltaTime * (state == EnemyState.idle ? idleSpinSpeed : chasingSpinSpeed);

            Vector3 rotation = transform.eulerAngles;
            rotation.z = time * 360f;
            transform.eulerAngles = rotation;
            time %= 1f;
        }

        private void FixedUpdate()
        {
            switch (state)
            {
                default:
                    if (Vector2.Distance(PlayerInstance.singleton.transform.position, transform.position) > ActivateRange) return;
                    Trigger();
                    break;
                case EnemyState.chasing:
                    if (IsActive)
                    {
                        Vector2 newPos = Vector2.MoveTowards(transform.position, PlayerInstance.singleton.transform.position, 1f) - (Vector2)transform.position;
                        rb.velocity = newPos * speed;
                        return;
                    }
                    rb.velocity = Vector2.zero;
                    break;
            }
        }

        public void Trigger()
        {
            state = EnemyState.chasing;
        }
    }
}