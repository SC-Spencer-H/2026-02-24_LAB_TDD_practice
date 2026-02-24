namespace QuestProgressTracker
{
    public class Quest
    {
        private string v;

        public Quest(string v)
        {
            this.v = v;
        }

        public bool IsCompleted { get; set; }

        public void AddObjective(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        public Objective GetObjective(string v)
        {
            throw new NotImplementedException();
        }

        public void ProgressObjective(string v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
