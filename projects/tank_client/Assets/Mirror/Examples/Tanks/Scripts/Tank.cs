using UnityEngine;
using UnityEngine.AI;

namespace Mirror.Examples.Tanks
{
    public class Tank : NetworkBehaviour
    {
        [Header("Components")]
        public NavMeshAgent agent;
        public Animator animator;

        [Header("Movement")]
        public bool move = true;
        public float Displacement = 300.0f;
        private float distance = 0.0f;

        [Header("Rotation")]
        public bool rotating = true;
        public float rotationSpeed = 30;
        public float angleExpected = 90.0f;
        public float direction = 1.0f;

        [Header("Firing")]
        public KeyCode shootKey = KeyCode.Space;
        public GameObject projectilePrefab;
        public Transform projectileMount;
        public bool shoot = false;
        public float waitTime = 2.0f;
        private float timer = 0.0f;


        void Update()
        {
            // movement for local player
            if (!isLocalPlayer) return;

            // rotate
            /*
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
            */
            if (rotating)
            {
                transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);
                if (transform.eulerAngles.y >= angleExpected)
                {
                    rotating = false;
                    transform.eulerAngles = new Vector3(0, angleExpected, 0);
                }
            }


            // move
            /*
            float vertical = Input.GetAxis("Vertical");
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            agent.velocity = forward * Mathf.Max(vertical, 0) * agent.speed;
            animator.SetBool("Moving", agent.velocity != Vector3.zero);
            */

            
            if (move)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                agent.velocity = forward * agent.speed;
                distance += agent.speed;
                if (Displacement <= distance)
                {
                    move = false;
                    print(distance);
                }
                
            }


            // shoot
            /*
            if (Input.GetKeyDown(shootKey))
            {
                CmdFire();
            }
            */
            if (shoot)
            {
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    CmdFire();
                    timer = timer - waitTime;
                }
            }
        }

        // this is called on the server
        [Command]
        void CmdFire()
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
            NetworkServer.Spawn(projectile);
            RpcOnFire();
        }

        // this is called on the tank that fired for all observers
        [ClientRpc]
        void RpcOnFire()
        {
            animator.SetTrigger("Shoot");
        }
    }
}
