namespace EmployeeManagmentSystem.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int DepartmentId { get; set; }
        //Navigation Property
        public Department? Department { get; set; }
    }
}
