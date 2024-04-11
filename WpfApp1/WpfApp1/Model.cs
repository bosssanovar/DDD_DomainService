using Reactive.Bindings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Usecase;

namespace WpfApp1
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
