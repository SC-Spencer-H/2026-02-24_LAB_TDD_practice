using QuestProgressTracker;

namespace TestProject
{
    public class QuestTests
    {
        [Fact]
        public void Quest_Is_Not_Completed_When_Objectives_Not_Finished()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 3);

            Assert.False(quest.IsCompleted);
        }

        [Fact]
        public void Quest_Is_Completed_When_All_Objectives_Are_Finished()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 5);

            Assert.True(quest.IsCompleted);
        }

        [Fact]
        public void Progress_Cannot_Exceed_Required_Amount()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 10);

            Assert.Equal(5, quest.GetObjective("Kill Goblins").CurrentAmount);
        }
    }
}
