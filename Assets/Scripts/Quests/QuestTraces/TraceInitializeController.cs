using UnityEngine;

namespace BeastHunter
{
    public class TraceInitializeController : IAwake
    {
        #region Field

        GameContext _context;

        #endregion


        #region ClassLifeCycle

        public TraceInitializeController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var TraceData = Data.TraceData;
            foreach( var traceInfo in TraceData.TraceStruct.TraceList)
            {
                GameObject instance = GameObject.Instantiate(traceInfo.Prefab);
                instance.transform.position = traceInfo.Position;
                TraceModel Trace = new TraceModel(instance, TraceData, traceInfo, _context);
                _context.TraceModelList.Add(Trace);
            }
        }

        #endregion
    }
}