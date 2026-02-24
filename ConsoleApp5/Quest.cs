using System.Xml.Linq;

namespace QuestProgressTracker
{
    public class Quest
    {
        private string Name { get; set; }
        public List<Objective> Objectives { get; set; } = new List<Objective>();
        private bool TurnedIn { get; set; }

        public bool IsCompleted 
        { 
            get
            {
                if (Objectives.Any(o => o.CurrentAmount != o.RequiredAmount))
                    return false;
                else if (TurnedIn == false)
                    return false;
                else
                    return true;
            } 
        }

        public Quest(string name)
        {
            Name = name;
        }

        public void AddObjective(string name, int requiredAmount)
        {
            try
            {
                GetObjective(name);
                    throw new DuplicateObjectiveException();
            }
            catch (ObjectiveNotFoundException)
            {
                Objectives.Add(new Objective(name, requiredAmount));
            }
        }

        public Objective GetObjective(string name)
        {
            Objective objective = Objectives.Find(o => o.Name == name);

            if (objective == default(Objective))
                throw new ObjectiveNotFoundException();
            else
                return objective;
        }

        public void ProgressObjective(string name, int amount)
        {
            GetObjective(name).IncrementCurrentAmount(amount);
        }

        public bool TurnIn(out string message)
        {
            if (Objectives.Any(o => o.CurrentAmount != o.RequiredAmount))
            {
                message = "Objectives not completed";
                return false;
            }
            else if (TurnedIn == true)
            {
                message = "Quest already turned in";
                return false;
            }
            else
            {
                TurnedIn = true;
                message = "Quest turned in!";
                return true;
            }
        }

        public class ObjectiveNotFoundException : Exception { }
        public class DuplicateObjectiveException : Exception { }
    }
}
