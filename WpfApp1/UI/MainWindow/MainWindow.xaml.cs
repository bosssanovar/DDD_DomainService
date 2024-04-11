using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Windows;

namespace UI.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Model _model;

        public ReactivePropertySlim<int> AAAVal { get; }

        public ReactivePropertySlim<string> BBBVal { get; }


        public MainWindow(Model model)
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
                mode: ReactivePropertyMode.DistinctUntilChanged);

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
                mode: ReactivePropertyMode.DistinctUntilChanged);

            InitializeComponent();
        }
    }
}