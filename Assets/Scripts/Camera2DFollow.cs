using System;
using UnityEngine;

// this comes from the Unity Standard Assets
namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

		// private variables
        float m_OffsetZ;
        Vector3 m_LastTargetPosition;
        Vector3 m_CurrentVelocity;
        Vector3 m_LookAheadPos;
        public GameObject otherGameObject;

        // Use this for initialization
        private void Start()
        {
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            Camera camera = GetComponent<Camera>();
            boxCollider.size = new Vector2(camera.aspect * 2f * camera.orthographicSize, 2f * camera.orthographicSize);
            //boxCollider.size.x = camera.aspect * 2f * camera.orthographicSize;
            //boxCollider.size.y = 2f * camera.orthographicSize;

            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;

			// if target not set, then set it to the player
			if (target==null) {
				target = GameObject.FindGameObjectWithTag("Player").transform;
			}

			if (target==null)
				Debug.LogError("Target not set on Camera2DFollow.");

        }

        // Update is called once per frame
		private void Update()
        {
			if (target == null)
				return;

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
				m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}
