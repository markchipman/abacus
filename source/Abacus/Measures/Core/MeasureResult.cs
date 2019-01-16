namespace Abacus.Measures
{
    public class MeasureResult
    {
        public MeasureResult(MeasureType measureType, object result)
        {
            MeasureType = measureType;
            Result = result;
        }

        public MeasureType MeasureType { get; }

        public object Result { get; }

        public override string ToString()
        {
            return MeasureType + ": " + Result;
        }
    }
}
