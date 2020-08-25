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
                GameObject instance = GameObject.Instantiate(TraceData.TraceStruct.Prefab, TraceData.TraceStruct.PlayerTransform);

                TraceModel Trace = new TraceModel(instance, TraceData, _context);
                _context.TraceModelList.Add(Trace);

          //  TraceData.SetPerent(instance.transform, TraceData.GetParent());


        }

        #endregion
    }
}