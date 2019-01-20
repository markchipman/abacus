namespace Abacus.Measures
{
    public class MeasureResult
    {
        public MeasureResult(Measure measure, object result)
        {
            Measure = measure;
            Result = result;
        }

        public Measure Measure { get; }

        public object Result { get; }

        public override string ToString()
        {
            return Measure + ": " + Result;
        }
    }
}
