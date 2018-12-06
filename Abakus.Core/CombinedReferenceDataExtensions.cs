namespace Abakus.Core
{
    public static class CombinedReferenceDataExtensions
    {
        public static IReferenceData CombineWith(this IReferenceData thisRefData, IReferenceData otherRefData)
        {
            if (thisRefData == null) return otherRefData;
            if (otherRefData == null) return thisRefData;
            return new CombinedReferenceData(thisRefData, otherRefData);
        }
    }
}