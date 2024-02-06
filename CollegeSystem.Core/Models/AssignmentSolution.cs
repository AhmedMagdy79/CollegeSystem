using System.ComponentModel.DataAnnotations.Schema;


namespace CollegeSystem.Core.Models
{
    public class AssignmentSolution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DeliverDate { get; set; } = DateTime.UtcNow;

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
