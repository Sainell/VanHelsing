using UnityEngine;


namespace BeastHunter
{
    public class TraceModel : MonoBehaviour
    {
        #region Fields

        public GameContext Context;

        #endregion


        #region Properties

        public TraceData TraceData { get; }
        public TraceStruct TraceStruct { get; }

        #endregion


        #region ClassLifeCycle

        public TraceModel(GameObject prefab, TraceData traceData, Trace traceInfo, GameContext context)
        {
            var instance = prefab.GetComponent<QuestTraceInfo>();
            TraceData = traceData;
            TraceStruct = traceData.TraceStruct;
            Context = context;
            TraceData.Model = this;
            instance.TraceId = traceInfo.Id;
            instance.TracePosition = traceInfo.Position;
            
        }

        #endregion


        #region Metods

        public void Execute()
        {
        }

        #endregion
    }
}