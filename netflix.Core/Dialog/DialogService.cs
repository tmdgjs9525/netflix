using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using netflix.Core;
using netflix.Parameter;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace netflix.Dialog
{
    internal class DialogService : IDialogService, IDialogRegister
    {
        private readonly Dictionary<string, Tuple<Type, Type>> _viewViewModelDictionary = new();

        public DialogService()
        {
            // 생성자 간소화 - 의존성은 DI 확장 메서드에서 처리
        }

        public void ShowDialog(string viewName, Parameters? parameters = null, Action<IDialogResult>? callback = null)
        {
            // TODO : 로깅
            IsViewNameValid(viewName);

            DialogBase dialogBase = new();

            SetDialogViewAndViewModel(viewName, parameters, dialogBase, callback);

            dialogBase.ShowAndWait();
        }

        public void Show(string viewName, Parameters? parameters)
        {
            //TODO : 로깅
            IsViewNameValid(viewName);

            DialogBase dialogBase = new();

            SetDialogViewAndViewModel(viewName, parameters, dialogBase);

            dialogBase.Show();
        }

        private void SetDialogViewAndViewModel(string viewName, Parameters? parameters, DialogBase dialogBase, Action<IDialogResult>? callback = null)
        {
            var control = (Ioc.Default.GetRequiredService(_viewViewModelDictionary[viewName].Item1) as UserControl) ?? throw new ArgumentNullException($"Can't find '{viewName}' from Di Container");

            var vm = Ioc.Default.GetRequiredService(_viewViewModelDictionary[viewName].Item2) ?? throw new ArgumentNullException($"Can't find '{viewName}Model from Di Container");

            //Di Container에서 찾은 타입 가져와서 넣어주기
            control.DataContext = vm;

            ContentControl contentControl = FindChild<ContentControl>(dialogBase, "dialogContent") ?? throw new ArgumentNullException("dialogContent를 찾을 수 없음");

            contentControl.Content = control;

            DialogResult dialogResult = new();

            if (vm is IDialogAware dialogAware)
            {
                dialogAware.OnDialogOpened(parameters ?? new Parameters());

                //한번 호출되면 해제하기 위해 할당 후 등록
                Action<IDialogResult> requestCloseHandler = null!;
                requestCloseHandler = (result) =>
                {
                    if (dialogAware.CanCloseDialog())
                    {
                        dialogResult = (DialogResult)result;
                        dialogAware.OnDialogClosed();
                        dialogBase.Close();
                        callback?.Invoke(result);
                        dialogAware.RequestClose -= requestCloseHandler;
                    }
                };

                dialogAware.RequestClose += requestCloseHandler;
            }
        }

        public void AddTransientDialog<TView, TViewModel>() where TView : Control
                                                            where TViewModel : IViewModelBase, IDialogAware
        {
            _viewViewModelDictionary[typeof(TView).Name] =
                new Tuple<Type, Type>(typeof(TView), typeof(TViewModel));
        }

        public void AddSingletonDialog<TView, TViewModel>() where TView : Control
                                                            where TViewModel : IViewModelBase, IDialogAware
        {
            _viewViewModelDictionary[typeof(TView).Name] =
                new Tuple<Type, Type>(typeof(TView), typeof(TViewModel));
        }

        private void IsViewNameValid(string viewName)
        {
            if (_viewViewModelDictionary.ContainsKey(viewName) == false)
            {
                throw new ArgumentNullException($"Can't find '{viewName}' from _viewDictionary ");
            }
        }


        // 특정 이름의 자식 컨트롤을 찾는 제네릭 메서드
        private T? FindChild<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            // 부모가 ContentControl이라면 Content를 가져옴
            if (parent is ContentControl contentControl)
            {
                parent = contentControl.Content as DependencyObject ?? throw new ArgumentException("Dialog는 UserControl 이여야 합니다.");
            }

            // 자식 컨트롤을 순차적으로 검색
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                // 자식이 찾고자 하는 타입인지 확인
                if (child is T && ((T)child).GetValue(FrameworkElement.NameProperty).ToString() == name)
                {
                    return (T)child;
                }

                // 하위 요소가 또 다른 부모 컨트롤을 가지고 있을 수 있으므로 재귀적으로 검색
                T? foundChild = FindChild<T>(child, name);
                if (foundChild != null)
                {
                    return foundChild;
                }
            }

            return null;
        }
    }
}