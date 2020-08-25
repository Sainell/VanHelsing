using UnityEngine;


namespace BeastHunter
{
    [CreateAssetMenu(fileName = "NewTraceModel", menuName = "CreateModel/Trace", order = 0)]
    public class TraceData : ScriptableObject
    {
        #region Fields
        public const float CANVAS_OFFSET = 1f;

        public TraceStruct TraceStruct;
        public TraceModel Model;
        public Vector3 NpcPos;
        public int TraceID;
        public Transform CharacterCamera;
        public string TargetTag;
        public GameObject Canvas;

        #endregion


        #region Methods


        #endregion
    }
}