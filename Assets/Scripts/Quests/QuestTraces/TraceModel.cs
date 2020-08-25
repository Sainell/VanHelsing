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

        public TraceModel(GameObject prefab, TraceData traceData, GameContext context)
        {
            TraceData = traceData;
            TraceStruct = traceData.TraceStruct;
            Context = context;
            TraceData.Model = this;
        }

        #endregion


        #region Metods

        public void Execute()
        {
        }

        #endregion
    }
}