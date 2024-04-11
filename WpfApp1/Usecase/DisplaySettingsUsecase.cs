using Repository;

namespace Usecase
{
    public class DisplaySettingsUsecase(AAARepository _aaaRepository, BBBRepository _bbbRepository)
    {
        public AAAEntity.AAAEntity GetAAAEntity()
        {
            return _aaaRepository.Load();
        }

        public BBBEntity.BBBEntity GetBBBEntity()
        {
            return _bbbRepository.Load();
        }
    }
}
