using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public enum LeaveStatus
    {
        UnAuthorised,
        Approved,
        Rejected
    }

    public enum LeaveType
    {
        [Display(Name = "Forced Leave")]
        ForcedLeave,
        [Display(Name = "Free Company Holiday")]
        FreeCompanyHoliday
    }

    public enum DayType
    {
        FullDay,
        HalfDay
    }

    public enum HourPeriod
    {
        [Display(Name = "N/A")]
        NA,
        AM,
        PM
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum EmployeeType
    {
        FullTime,
        PartTime,
        Contract,
        Internship
    }

    public enum QualificationLevel
    {
        Doctorate,
        [Display(Name = "Master's")]
        Master,
        [Display(Name = "Bachelor's")]
        Bachelor,
        Diploma,
        Certificate,
        Alevel,
        Olevel,

    }
}
