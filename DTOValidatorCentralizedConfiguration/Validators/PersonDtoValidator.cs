using DTOValidatorCentralizedConfiguration.Configurations;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class PersonDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public bool IsEmployed { get; set; }
    public List<string> Skills { get; set; }
    public string Address { get; set; }
    public string Street { get; set; }
}

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    private readonly PersonRulesHorizontal _rules = new PersonRulesHorizontal();
    private readonly string _locale = "es-ES"; // Change this to switch language

    public PersonDtoValidator()
    {
        ApplyRulesForProperty(x => x.Name, _rules.Name);
        ApplyRulesForProperty(x => x.Age, _rules.Age);
        ApplyRulesForProperty(x => x.Birthday, _rules.Birthday);
        ApplyRulesForProperty(x => x.Email, _rules.Email);
        ApplyRulesForProperty(x => x.IsEmployed, _rules.IsEmployed);
        ApplyRulesForProperty(x => x.Skills, _rules.Skills);
        ApplyRulesForProperty(x => x.Address, _rules.Address);
        ApplyRulesForProperty(x => x.Street, _rules.Street);
    }

    private void ApplyRulesForProperty<TProperty>(Expression<Func<PersonDto, TProperty>> propertyFunc, Dictionary<string, Tuple<string, Dictionary<string, string>>> rules)
    {
        var ruleBuilder = RuleFor(propertyFunc);

        foreach (var rule in rules)
        {

            switch (rule.Key)
            {
                case "IsRequired":
                    ruleBuilder.NotEmpty().WithMessage($"{rule.Value.Item1} is required");
                    break;

                //case "HasLength":
                //    var lengths = rule.Value.Item1.Split(',');
                //    ruleBuilder
                //        .Must(x => x.ToString().Length >= int.Parse(lengths[0]) && x.ToString().Length <= int.Parse(lengths[1]))
                //        .WithMessage($"{rule.Value.Item1} must be between {lengths[0]} and {lengths[1]} characters");
                //    break;
            }
        }
    }

}
