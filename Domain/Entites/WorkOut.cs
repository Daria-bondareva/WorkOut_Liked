using Domain.ValueObjects;

namespace Domain.Entites
{
    public class WorkOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public string TrainingDuration { get; set; }
        public Price Price { get; set; }
        public ICollection<SavedWorkout> SavedWorkouts { get; set; }

        private WorkOut() { }

        public WorkOut(string name, string description, int typeId, int categoryId, string trainingDuration, Price price)
        {
            Name = name;
            Description = description;
            TypeId = typeId;
            CategoryId = categoryId;
            TrainingDuration = trainingDuration;
            Price = price;
        }
    }
}
