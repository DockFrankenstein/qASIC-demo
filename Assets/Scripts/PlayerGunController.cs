using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace qASIC.Demo
{
	public class PlayerGunController : MonoBehaviour
	{
		public Transform gunAxis;
        public Transform gun;

        Camera cam;

        private void Awake()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diffrence = mousePosition - transform.position;
            float angle = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
            gunAxis.eulerAngles = new Vector3(gunAxis.eulerAngles.x, gunAxis.eulerAngles.y, angle);

            if (Input.GetMouseButtonDown(0)) Shoot();
        }

        public void Shoot()
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.position, gun.TransformDirection(Vector2.right));
            Debug.DrawRay(gun.position, gun.TransformDirection(Vector2.right));
            if (hit) /*Destroy(hit.transform.gameObject);*/ Debug.Log(hit.transform.name);
        }
    }
}