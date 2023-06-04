using FluentValidation;
using System.Text.RegularExpressions;

namespace HairManager.Application.Utils.FluentValidatorExtensions;
public static class FluentExtensions
{
    public static IRuleBuilderOptions<T, TElement> Phone<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder) 
        => ruleBuilder.Must((_, value, _) => value?.ToString().Length > 10 && Regex.IsMatch(value.ToString(), "^[0-9]*$"));
}
