namespace Playground.Models
{
    class ParentClass
    {
        public double ParentValue { get; set; }
        public ChildClass ChildClass { get; set; }
    }

    class ChildClass
    {
        public double ChildValue { get; set; }
        public InnerChildClass InnerChildClass { get; set; }
    }

    class InnerChildClass
    {
        public double? NullableValue1 { get; set; }
        public double? NullableValue2 { get; set; }
        public double NotNullableValue { get; set; }
        public double[][] JaggedArray { get; set; }
    }
}
