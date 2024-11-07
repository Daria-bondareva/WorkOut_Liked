namespace Application.DTO.Requests
{
    public class SavedWorkoutRequest
    {
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
        public DateTime SavedDate { get; set; }
        public string Notes { get; set; }
    }
}
