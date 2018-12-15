namespace Abacus.Core.ReferenceData
{
    public static class MergedReferenceDataExtensions
    {
        public static IReferenceData MergeWith(this IReferenceData first, IReferenceData second)
        {
            if (first == null) return second ?? EmptyReferenceData.Instance;
            if (second == null) return first ?? EmptyReferenceData.Instance;
            return new MergedReferenceData(first, second);
        }
    }
}