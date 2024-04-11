using Reactive.Bindings;
using Usecase;

namespace UI.MainWindow
{
    public class Model
    {
        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        public ReactivePropertySlim<AAAEntity.AAAEntity> AaaEntity { get; }
        public ReactivePropertySlim<BBBEntity.BBBEntity> BbbEntity { get; }

        public Model(DisplaySettingsUsecase displaySettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAAAEntity());
            BbbEntity = new(_displaySettingsUsecase.GetBBBEntity());
        }

        public void ForceNotifyAaaEntity()
        {
            AaaEntity.ForceNotify();
        }

        public void ForceNotifyBbbEntity()
        {
            BbbEntity.ForceNotify();
        }
    }
}
