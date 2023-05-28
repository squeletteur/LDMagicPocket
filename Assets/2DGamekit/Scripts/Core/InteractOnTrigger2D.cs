using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractOnTrigger2D : MonoBehaviour
    {
        public LayerMask layers;
        public UnityEvent OnEnter, OnExit;
        public InventoryController.InventoryChecker[] inventoryChecks;

        public bool isDestroyedAtTrigger = false;
        public GameObject destroyedParticles = null;

        protected Collider2D m_Collider;

        void Reset()
        {
            layers = LayerMask.NameToLayer("Everything");
            m_Collider = GetComponent<Collider2D>();
            m_Collider.isTrigger = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(!enabled)
                return;
        
            if (layers.Contains(other.gameObject))
            {
                ExecuteOnEnter(other);

                if (isDestroyedAtTrigger)
                {
                    if (destroyedParticles != null)
                    {
                        Instantiate(destroyedParticles, transform.position, Quaternion.identity);
                    }

                    Destroy(gameObject);
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(!enabled)
                return;
        
            if (layers.Contains(other.gameObject))
            {
                ExecuteOnExit(other);
            }
        }

        protected virtual void ExecuteOnEnter(Collider2D other)
        {
            OnEnter.Invoke();
            for (int i = 0; i < inventoryChecks.Length; i++)
            {
                inventoryChecks[i].CheckInventory(other.GetComponentInChildren<InventoryController>());
            }
        }

        protected virtual void ExecuteOnExit(Collider2D other)
        {
            OnExit.Invoke();
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
        }
    }
}