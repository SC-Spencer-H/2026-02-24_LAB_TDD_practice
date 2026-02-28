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
        public void Quest_Cannot_Be_Turned_In_Until_Objectives_Are_Completed()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 3);

            Assert.False(quest.TurnIn(out string message));
        }

        [Fact]
        public void Quest_Cannot_Be_Turned_In_Repeatedly()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 5);
            quest.TurnIn(out string message);

            Assert.False(quest.TurnIn(out message));
        }

        [Fact]
        public void Exception_When_Incrementing_Nonexistent_Objective()
        {
            var quest = new Quest("Goblin Slayer");

            try
            {
                quest.ProgressObjective("Kill Goblins", 5);
                    Assert.True(false); 
            }
            catch (Quest.ObjectiveNotFoundException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Exception_When_Adding_Duplicate_Objective()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            try
            {
                quest.AddObjective("Kill Goblins", 5);
                    Assert.True(false);
            }
            catch (Quest.DuplicateObjectiveException)
            {
                Assert.True(true);
            }
        }


        [Fact]
        public void Quest_Is_Not_Completed_Until_Turned_In()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 5);

            Assert.False(quest.IsCompleted);
        }

        [Fact]
        public void Progress_Throws_Exception_If_Too_Much()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            Assert.Throws<InvalidOperationException>(() =>
            quest.ProgressObjective("Kill Goblins", 6));
        }

    }
}
