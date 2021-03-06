namespace BonemotherGames2.Services
{
    public class SpecialAction
    {
        public int ActionId { get; set; }
        public int LevelAttained { get; set; }
        public int? UsesPerDay { get; set; }
        public string ActionName { get; set; }
        public string ActionTypeName { get; set; }
        public string ActionDescription { get; set; }

        public SpecialAction()
        {

        }
        public SpecialAction(int actionId,
            int levelAttained,
            int? usesPerDay,
            string actionName,
            string actionTypeName,
            string actionDescription)
        {
            ActionId = actionId;
            LevelAttained = levelAttained;
            UsesPerDay = usesPerDay;
            ActionName = actionName;
            ActionTypeName = actionTypeName;
            ActionDescription = actionDescription;
        }
    }
}
