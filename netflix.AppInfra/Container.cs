using Microsoft.Extensions.DependencyInjection;
using netflix.AppInfra;
using netflix.Dialog;
using netflix.ViewManager.Navigate;
using System.Windows.Controls;


namespace netflix.ViewManager
{
    public class Container
    {
        private readonly IServiceCollection _service;
        private readonly NavigationService _navigationService;
        private readonly DialogService _dialogService;

        public Container(IServiceCollection services)
        {
            _service = services;

            //Navigation 서비스 등록
            _navigationService = new NavigationService();
            _service.AddSingleton<INavigationService>(_navigationService);

            //Dialog 서비스 등록
            _dialogService = new DialogService();
            _service.AddSingleton<IDialogService>(_dialogService);
        }

        #region NavigationService
        public void AddTransientNavigation<TView, TVIewModel>() where TView : Control
                                                                where TVIewModel : IViewModelBase
        {
            _navigationService.AddTransientNavigation<TView, TVIewModel>();
        }

        public void AddSingletonNavigation<TView, TVIewModel>() where TView : Control
                                                                where TVIewModel : IViewModelBase
        {
            _navigationService.AddSingletonNavigation<TView, TVIewModel>();
        }

        public void AddSingletonNavigation<TInterface, TImplementation, TViewModel>() where TInterface : class
                                                                                      where TImplementation : Control, TInterface
                                                                                      where TViewModel : IViewModelBase
        {
            _navigationService.AddSingletonNavigation<TInterface, TImplementation, TViewModel>();
        }

        public void AddTransientNavigation<TInterface, TImplementation, TViewModel>() where TInterface : class
                                                                                        where TImplementation : Control, TInterface
                                                                                        where TViewModel : IViewModelBase
        {
            _navigationService.AddTransientNavigation<TInterface, TImplementation, TViewModel>();
        }

        #endregion

        #region DialogService
        public void AddTransientDialog<TView, TViewModel>() where TView : Control
                                                            where TViewModel : IViewModelBase, IDialogAware
        {
            _dialogService.AddTransientDialog<TView, TViewModel>();
        }

        public void AddSingletonDialog<TView, TViewModel>() where TView : Control
                                                            where TViewModel : IViewModelBase, IDialogAware
        {
            _dialogService.AddSingletonDialog<TView, TViewModel>();
        }
        #endregion
    }
}
