namespace QuestProgressTracker
{

    public class Objective
    {
        public string Name { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }

        public Objective(string name, int requiredAmount)
        {
            Name = name;
            RequiredAmount = requiredAmount;
        }

        public void IncrementCurrentAmount(int amount)
        {
            if (CurrentAmount + amount >= RequiredAmount)
                CurrentAmount = RequiredAmount;
            else
                CurrentAmount += amount;
        }
    }
}
