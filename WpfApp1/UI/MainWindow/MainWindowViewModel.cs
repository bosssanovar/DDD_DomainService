using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainService;
using System.Reactive.Disposables;


namespace UI.MainWindow
{
    public partial class MainWindowView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Model? _model;

        private readonly CompositeDisposable _compositeDisposable = [];

        public ReactivePropertySlim<int> AAAVal { get; private set; } = new(0);

        public ReactivePropertySlim<string> BBBVal { get; private set; } = new(string.Empty);

        private void MainWindowViewModel(Model model)
        {
            _model = model;

            AAAVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.AAA.Value,
                x =>
                {
                    var entity = _model.AaaEntity.Value;
                    entity.SetAAA(new(x), new AAAChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));

                    _model.ForceNotifyAaaEntity();
                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            BBBVal = _model.BbbEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.BBB.Value,
                x =>
                {
                    var text = x;

                    var lengthChecker = new BBBLehgthChecker(_model.AaaEntity.Value);
                    if (!lengthChecker.IsValid(text))
                    {
                        text = lengthChecker.Substring(text);
                    }

                    var entity = _model.BbbEntity.Value;
                    entity.SetBBB(new(text), lengthChecker);

                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);
        }
    }
}
