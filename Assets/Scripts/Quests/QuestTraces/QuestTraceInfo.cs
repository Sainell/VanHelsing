using UnityEngine;


namespace BeastHunter
{
    public sealed class QuestTraceInfo : MonoBehaviour, IGetNpcInfo
    {
        #region Fields
        public Vector3 TracePosition;
        public int TraceId;

        #endregion


        #region UnityMethods

        private void Start()
        {
            TracePosition = transform.position;
        }

        #endregion


        #region Methods

        public (int, Vector3) GetInfo()
        {
            return (TraceId, TracePosition);
        }

        #endregion
    }
}