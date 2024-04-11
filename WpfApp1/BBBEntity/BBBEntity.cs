namespace BBBEntity
{
    public class BBBEntity
    {
        public BBBVO BBB { get; private set; }

        public BBBEntity()
        {
            BBB = new("init value");
        }

        public void SetBBB(BBBVO bbb, IBBBLehgthChecker checker)
        {
            if (!checker.IsValid(bbb.Value)){
                throw new ArgumentOutOfRangeException(nameof(bbb), "範囲外");
            }

            BBB = bbb;
        }

        public BBBEntity Clone()
        {
            return (BBBEntity)MemberwiseClone();
        }
    }
}
