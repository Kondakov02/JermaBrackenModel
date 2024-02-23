using JermaBrackenModel.Core;
using UnityEngine;

namespace JermaBrackenModel.Scripts
{
    internal class JermaController : MonoBehaviour
    {
        private FlowermanAI FlowermanAI { get; set; }

        private GameObject JermaObject { get; set; }

        private bool IsDead { get; set; }

        private const string newModelName = "JermaModel";

        private const string newObjectName = "Jerma";

        private void Start()
        {
            FlowermanAI = ((Component)this).GetComponent<FlowermanAI>();
            HideFlowermanModel();
            CreateJermaModel();
        }

        private void Update()
        {
            // Rotate the model every frame
            Quaternion rotation = ((Component)StartOfRound.Instance.localPlayerController).transform.rotation;
            float num = rotation.eulerAngles.y - 180f;

            // Play the death sequence once
            if (FlowermanAI.isEnemyDead && !IsDead)
            {
                FallDead();
            }
        }

        private void HideFlowermanModel()
        {
            Renderer[] brackenParts = ((Component)((Component)FlowermanAI).transform.Find("FlowermanModel")).GetComponentsInChildren<Renderer>();
            foreach (Renderer partRenderer in brackenParts)
            {
                partRenderer.enabled = false;
            }
        }

        private void CreateJermaModel()
        {
            GameObject asset = Assets.GetAsset<GameObject>(newModelName);
            JermaObject = Object.Instantiate<GameObject>(asset, ((Component)this).gameObject.transform);
            ((Object)JermaObject).name = newObjectName;
        }

        private void FallDead()
        {
            Transform transform = JermaObject.transform;
            Quaternion rotation = JermaObject.transform.rotation;
            float y = rotation.eulerAngles.y;
            rotation = JermaObject.transform.rotation;
            transform.rotation = Quaternion.Euler(-90f, y, rotation.eulerAngles.z);
            IsDead = true;
        }
    }
}
