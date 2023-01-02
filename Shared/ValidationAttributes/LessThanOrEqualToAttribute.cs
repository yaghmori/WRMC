namespace WRMC.Core.Shared.ValidationAttributes
{
    public class LessThanOrEqualToAttribute : IsAttribute
    {
        public LessThanOrEqualToAttribute(string dependentProperty) : base(Operator.LessThanOrEqualTo, dependentProperty) { }
    }

}
