using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using netflix.AppAbstractions;
using netflix.Parameter;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace netflix.Navigate
{

    internal class NavigationService : INavigationService, INavigationRegister, IRegionRegister
    {
        //Type1 View / Type2 ViewModel
        private readonly Dictionary<string, Tuple<Type, Type>> _viewDictionary = new();

        //어태치 프로퍼티로 ContentControl 사용하는 곳에서 등록된다.
        private readonly Dictionary<string, ContentControl> _regionDictionary = new();

        //di 등록용
        //private readonly IServiceCollection _serviceCollection;

        internal NavigationService()
        {

        }

        public void RegisterRegion(string regionName, ContentControl control)
        {
            _regionDictionary[regionName] = control;
        }

        //CommandParameter는 문자열로 들어오니 viewName을 string으로
        public void NavigateTo(string regionName, string viewName, Parameters? parameters = null)
        {
            // Region 등록되어 있는지 확인
            if (_regionDictionary.ContainsKey(regionName) == false)
            {
                throw new ArgumentNullException($"Can't find '{regionName}' region");
            }

            // View 등록되어 있는지 확인
            if (_viewDictionary.ContainsKey(viewName) == false)
            {
                throw new ArgumentNullException($"Can't find '{viewName}' from _viewDictionary ");
            }

            var control = Ioc.Default.GetRequiredService(_viewDictionary[viewName].Item1) as UserControl;

            // Control 등록 여부 확인
            if (control == null)
            {
                throw new ArgumentNullException($"Can't find '{viewName}' from Di Container");
            }

            //Di Container에서 찾은 타입 가져와서 넣어주기
            control.DataContext = Ioc.Default.GetRequiredService(_viewDictionary[viewName].Item2);

            //ViewModel에 Navigate 됐다고 호출
            if (control.DataContext is INavigateAware navigateAware)
            {
                navigateAware.NavigateTo(parameters ?? new Parameters());
            }

            //Region Navigate
            _regionDictionary[regionName].Content = control;

            // TODO : 로깅
        }


        public void AddTransientNavigation<TView, TViewModel>() where TView : Control
                                                                where TViewModel : IViewModelBase
        {
            //_serviceCollection.AddTransient<TView>();
            //_serviceCollection.AddTransient<TViewModel>();

            _viewDictionary[typeof(TView).Name] =
                new Tuple<Type, Type>(typeof(TView), typeof(TViewModel));
        }

        public void AddSingletonNavigation<TView, TViewModel>() where TView : Control
                                                                where TViewModel : IViewModelBase
        {
            //_serviceCollection.AddSingleton<TView>();
            //_serviceCollection.AddTransient<TViewModel>();

            _viewDictionary[typeof(TView).Name] =
                new Tuple<Type, Type>(typeof(TView), typeof(TViewModel));
        }

        public void AddSingletonNavigation<TInterface, TImplementationView, TViewModel>() where TInterface : class               // TInterface는 참조 형식이어야 함
                                                                                         where TImplementationView : Control, TInterface // TImplementation은 Control을 상속하고 TInterface를 구현해야 함
                                                                                         where TViewModel : IViewModelBase
        {
            // TInterface를 TImplementation으로 싱글턴으로 등록
            //_serviceCollection.AddSingleton<TInterface, TImplementationView>();
            //_serviceCollection.AddSingleton(typeof(TViewModel));

            // TImplementation의 타입을 _viewDictionary에 추가

            string viewName = typeof(TInterface).Name.Substring(1);

            _viewDictionary[viewName] =
                new Tuple<Type, Type>(typeof(TImplementationView), typeof(TViewModel));
        }

        public void AddTransientNavigation<TInterface, TImplementationView, TViewModel>() where TInterface : class               // TInterface는 참조 형식이어야 함
                                                                                          where TImplementationView : Control, TInterface // TImplementation은 Control을 상속하고 TInterface를 구현해야 함
                                                                                          where TViewModel : IViewModelBase
        {
            // TInterface를 TImplementation으로 싱글턴으로 등록
            //_serviceCollection.AddTransient<TInterface, TImplementationView>();
            //_serviceCollection.AddTransient(typeof(TViewModel));

            // TImplementation의 타입을 _viewDictionary에 추가
            string viewName = typeof(TInterface).Name.Substring(1);

            _viewDictionary[viewName] =
                new Tuple<Type, Type>(typeof(TImplementationView), typeof(TViewModel));
        }


    }
}
