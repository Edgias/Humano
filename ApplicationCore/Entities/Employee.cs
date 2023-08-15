using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Employee : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set;} = default!;

        public string NationalId { get; private set; } = default!;

        public Gender Gender { get; private set; }

        public EmployeeType EmployeeType { get; private set; }

        public string? Email { get; private set; } 

        public string Mobile { get; private set; } = default!;

        public Guid SalutationId { get; private set; }

        public Salutation Salutation { get; private set; } = default!;

        public DateTime DateOfBirth { get; private set; }

        public DateTime DateJoined { get; private set; }

        public Guid DepartmentId { get; private set; }

        public Department Department { get; private set; } = default!;

        public Guid? ManagerId { get; private set; }

        public Employee Manager { get; private set; } = default!;

        public Address ResidentialAddress { get; private set; } = default!;

        private readonly List<CheckIn> _checkIns = new();
        public IReadOnlyCollection<CheckIn> CheckIns => _checkIns.AsReadOnly();

        private readonly List<EmployeeQualification> _employeeQualifications = new();
        public IReadOnlyCollection<EmployeeQualification> EmployeeQualifications => _employeeQualifications.AsReadOnly();

        private readonly List<Leave> _leaves = new();
        public IReadOnlyCollection<Leave> Leaves => _leaves.AsReadOnly();

        private readonly List<Timesheet> _timesheets = new();
        public IReadOnlyCollection<Timesheet> Timesheets => _timesheets.AsReadOnly();

        private readonly List<WorkExperience> _workExperiences = new();
        public IReadOnlyCollection<WorkExperience> WorkExperiences => _workExperiences.AsReadOnly();

        private Employee()
        {
            
        }

        public Employee(Guid salutationId, string firstName, string lastName, Gender gender, 
            EmployeeType employeeType, string nationalId, string mobile, string? email, 
            DateTime dateOfBirth, DateTime dateJoined, Guid departmentId, 
            Guid? managerId, Address residentialAddress)
        {
            SalutationId = salutationId;
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
            Gender = gender;
            NationalId = nationalId;
            Mobile = mobile;
            Email = email;
            DateOfBirth = dateOfBirth;
            DateJoined = dateJoined;
            DepartmentId = departmentId;
            ManagerId = managerId;
            ResidentialAddress = residentialAddress;
        }

        public void AddQualification(EmployeeQualification qualification)
        {
           _employeeQualifications.Add(qualification);
        }

        public void AddQualifications(IEnumerable<EmployeeQualification> qualifications)
        {
           _employeeQualifications.AddRange(qualifications);
        }

        public void AddWorkExperience(WorkExperience workExperience)
        {
            _workExperiences.Add(workExperience);
        }

        public void AddWorkExperiences(IEnumerable<WorkExperience> workExperiences)
        {
            _workExperiences.AddRange(workExperiences);
        }

        public void ChangeDepartment(Guid departmentId)
        {
            DepartmentId = departmentId;
        }

        public void ChangeManager(Guid managerId) 
        { 
            ManagerId = managerId;
        }

        public int Age()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public string CurrentPosition()
        {
            string position = default!;

            WorkExperience? workExperience = _workExperiences.FirstOrDefault(we => we.EndDate == null);

            if (workExperience is not null)
            {
                if(workExperience.JobTitle is  not null) 
                {
                    position = workExperience.JobTitle.Name;
                }
            }

            return position;
        }

        public decimal CurrentSalary()
        {
            decimal salary = decimal.Zero;

            WorkExperience? workExperience = _workExperiences.FirstOrDefault(we => we.EndDate == null);

            if (workExperience is not null)
            {
                salary = workExperience.GetSalary();
            }

            return salary;
        }
    }
}
