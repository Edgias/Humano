using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Grade : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public decimal MinimumSalary { get; private set; }

        public decimal MaximumSalary { get; private set; }

        private readonly List<GradeBenefit> _benefits = new();

        public IReadOnlyCollection<GradeBenefit> Benefits => _benefits.AsReadOnly();

        public Grade(string name, decimal minimumSalary, decimal maximumSalary)
        {
            Name = name;
            MinimumSalary = minimumSalary;
            MaximumSalary = maximumSalary;
        }

        public Grade(string name, decimal minimumSalary, decimal maximumSalary, 
            List<GradeBenefit> benefits)
        {
            Name = name;
            MinimumSalary = minimumSalary;
            MaximumSalary = maximumSalary;
            _benefits = benefits;
        }

        public void AddBenefit(GradeBenefit benefit) 
        { 
            _benefits.Add(benefit);
        }

    }
}
