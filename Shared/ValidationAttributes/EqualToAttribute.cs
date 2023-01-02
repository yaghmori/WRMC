namespace WRMC.Core.Shared.ValidationAttributes
{
    public class EqualToAttribute : IsAttribute
    {
        public EqualToAttribute(string dependentProperty) : base(Operator.EqualTo, dependentProperty) { }
    }

}
