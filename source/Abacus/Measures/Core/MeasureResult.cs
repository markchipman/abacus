namespace Abacus.Measures
{
    public class MeasureResult
    {
        public MeasureResult(MeasureType measureType, object result)
        {
            MeasureType = measureType;
            Result = result;
        }

        MeasureType MeasureType { get; }

        public object Result { get; }
    }
}
