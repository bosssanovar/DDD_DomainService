using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Disposables;

using Usecase;

namespace UiParts.UiWindow.MainWindow
{
    public class Model : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = [];

        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        public ReactivePropertySlim<AAAEntity.AAAEntity> AaaEntity { get; }
        public ReactivePropertySlim<BBBEntity.BBBEntity> BbbEntity { get; }

        public Model(DisplaySettingsUsecase displaySettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAAAEntity());
            AaaEntity.AddTo(_compositeDisposable);
            BbbEntity = new(_displaySettingsUsecase.GetBBBEntity());
            BbbEntity.AddTo(_compositeDisposable);
        }

        public void ForceNotifyAaaEntity()
        {
            AaaEntity.ForceNotify();
        }

        public void ForceNotifyBbbEntity()
        {
            BbbEntity.ForceNotify();
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}
