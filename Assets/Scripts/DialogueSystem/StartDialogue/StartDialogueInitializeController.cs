using UnityEngine;


namespace BeastHunter
{
    public sealed class StartDialogueInitializeController : IAwake
    {
        #region Field

        GameContext _context;

        #endregion


        #region ClassLifeCycle

        public StartDialogueInitializeController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var StartDialogueData = Data.StartDialogueData;
            GameObject instance = GameObject.Instantiate(StartDialogueData.StartDialogueStruct.Prefab,StartDialogueData.StartDialogueStruct.PlayerTransform);

            GameObject canvasNpc = GameObject.Instantiate(StartDialogueData.StartDialogueStruct.PrefabCanvasNpc); //For 3D mode
            GameObject canvasTrace = GameObject.Instantiate(StartDialogueData.StartDialogueStruct.PrefabCanvasTrace); //For 3D mode
            StartDialogueModel StartDialogue = new StartDialogueModel(instance, canvasNpc, canvasTrace, StartDialogueData, _context);
            _context.StartDialogueModel = StartDialogue;

            StartDialogueData.SetPerent(instance.transform, StartDialogueData.GetParent()); //For 3D mode
            StartDialogueData.GetDialogueSystemModel(_context.DialogueSystemModel);

        }

        #endregion
    }
}
