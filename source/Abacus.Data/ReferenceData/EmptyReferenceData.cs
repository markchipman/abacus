namespace Abacus.Data.ReferenceData
{
    public class EmptyReferenceData : IReferenceData
    {
        static EmptyReferenceData()
        {
            // http://csharpindepth.com/articles/general/singleton.aspx
        }

        private EmptyReferenceData()
        {
        }

        public static readonly EmptyReferenceData Instance = new EmptyReferenceData();


        public bool Contains<T>(IReferenceDataId<T> id) where T : class
        {
            return false;
        }

        public T GetValue<T>(IReferenceDataId<T> id) where T : class
        {
            throw new ReferenceDataNotFoundException<T>(id);
        }

        public T GetValueOrDefault<T>(IReferenceDataId<T> id, T @default = default) where T : class
        {
            return @default;
        }
    }
}