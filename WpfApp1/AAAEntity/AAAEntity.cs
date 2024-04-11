namespace AAAEntity
{
    public class AAAEntity
    {
        public AAAVO AAA { get; private set; }

        public AAAEntity()
        {
            AAA = new(10);
        }

        public void SetAAA(AAAVO aaa, IAAAChangedEvent changedEvent)
        {
            AAA = aaa;

            changedEvent.Execute();
        }

        public AAAEntity Clone()
        {
            return (AAAEntity)MemberwiseClone();
        }
    }
}
