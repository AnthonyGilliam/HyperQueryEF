namespace HyperQueryEF.Core
{
    public enum LifestyleType
    {
        Undefined,
        Singleton,
        Thread,
        Transient,
        Pooled,
        PerWebRequest,
        Custom,
        Scoped,
        Bound,
    }
}