using UnityEngine;


namespace BeastHunter
{
    public sealed class StartDialogueModel
    {
        #region Fields

        public GameContext Context;
        public DialogueSystemModel DialogueSystemModel;
        public bool IsStartDialogueFlagOn;
        public bool IsDialogueAreaEnter = true;

        #endregion


        #region Properties

        public Transform StartDialogueTransform { get; } //For 3D mode
        public StartDialogueData StartDialogueData { get; }
        public StartDialogueStruct StartDialogueStruct { get; }

        #endregion


        #region ClassLifeCycle

        public StartDialogueModel(GameObject prefab, GameObject canvasNpc, StartDialogueData startDialogueData, GameContext context) //For 3D mode
       // public StartDialogueModel(GameObject prefab, StartDialogueData startDialogueData, GameContext context)

        {
            StartDialogueTransform = prefab.transform; //For 3D mode
            StartDialogueData = startDialogueData;
            StartDialogueStruct = startDialogueData.StartDialogueStruct;
            Context = context;
            startDialogueData.Model = this;
            startDialogueData.CanvasNpc = canvasNpc; //For 3D mode
            ToTolkNpc.ToTalkClickEvent += startDialogueData.OnDialogueStart;
            PlaceButtonClick.CanvasClickEvent += startDialogueData.OnDialogueStart;
            Services.SharedInstance.EventManager.StartListening(GameEventTypes.DialogueUpdateByQuest, startDialogueData.OnUpdateDialogueByQuest);
        }

        #endregion


        #region Metods

        public void Execute()
        {
            StartDialogueData.DialogUsing();            
        }

        #endregion
    }
}
