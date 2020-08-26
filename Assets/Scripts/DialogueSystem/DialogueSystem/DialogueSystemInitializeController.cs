using UnityEngine;


namespace BeastHunter
{
    public sealed class DialogueSystemInitializeController : IAwake
    {
        #region Field

        GameContext _context;
        GameObject instance;
        #endregion


        #region ClassLifeCycle

        public DialogueSystemInitializeController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var dialogueSystemData = Data.DialogueSystemData;
             instance = GameObject.Find("MapDialogueSystem"); // for UI mode
            if (instance == null)               
            {
                instance = GameObject.Instantiate(dialogueSystemData.DialogueSystemStruct.Prefab);
            }
                DialogueSystemModel dialogueSystem = new DialogueSystemModel(instance, dialogueSystemData);
                _context.DialogueSystemModel = dialogueSystem;
            
        }

        #endregion
    }
}