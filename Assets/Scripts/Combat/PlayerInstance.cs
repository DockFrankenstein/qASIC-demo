using UnityEngine;

namespace qASIC.Demo
{
    public class PlayerInstance : MonoBehaviour
    {
        public static PlayerInstance singleton { get; private set; }

        private void Awake()
        {
            if(singleton == null)
            {
                singleton = this;
                return;
            }
            Destroy(gameObject);
        }
    }
}