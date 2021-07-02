using System.Collections;
using qASIC.Demo.ColorZones;
using UnityEngine;

namespace qASIC.Demo
{
	public class PlayerGunController : MonoBehaviour
	{
		public Transform gunAxis;
        public SpriteRenderer gun;

        public LayerMask hitMask;
        public float range = 16f;

        public GameObject particle;

        Camera cam;

        public static bool IsActive { get; set; }

        private void Awake()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if (ColorZoneManager.singleton != null && gun != null)
                gun.color = ColorZoneManager.singleton.current.playerColor;

            gun.gameObject.SetActive(IsActive);
            if (!IsActive) return;

            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diffrence = mousePosition - transform.position;
            float angle = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
            gunAxis.eulerAngles = new Vector3(gunAxis.eulerAngles.x, gunAxis.eulerAngles.y, angle);

            if (Input.GetMouseButtonDown(0)) Shoot();
        }

        public void Shoot()
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, gun.transform.TransformDirection(Vector2.right), range, hitMask);
            
            if (hit.transform != null && hit.transform.CompareTag("Enemy")) Destroy(hit.transform.gameObject);
            if (particle != null) Instantiate(particle, hit.point, Quaternion.identity);
        }
    }
}