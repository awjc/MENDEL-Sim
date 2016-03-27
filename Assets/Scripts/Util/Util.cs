using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class Util
    {
        public static void Parent(Transform child, Transform parent)
        {
            if (child != null)
            {
                child.parent = parent;
            }
        }

        public static void Parent(GameObject child, GameObject parent)
        {
            Parent(child.transform, parent.transform);
        }

        public static void ParentWithEmptyBetween(GameObject child, GameObject parent)
        {
            // Use a dummy game object to prevent scale inheritance
            var emptyObject = new GameObject("Empty");
            emptyObject.AddComponent<KeepScaleInvertedFromParent>();

            Parent(emptyObject, parent);
            emptyObject.transform.localPosition = Vector3.zero;
            Parent(child, emptyObject);
        }
    }
}
