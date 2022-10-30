using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pathway", menuName = "Pathways/Door")]
public class Pathway : ScriptableObject
{    
        new public string name = "New Door";
        public int targetScene;
        public GameObject prefab;

}
