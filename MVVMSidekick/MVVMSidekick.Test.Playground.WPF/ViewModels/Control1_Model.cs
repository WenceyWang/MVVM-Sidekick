﻿using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace MVVMSidekick.Test.Playground.WPF.ViewModels
{

    public class Control1_Model : ViewModelBase<Control1_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property propcmd for command
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性 propcmd 输入命令

        public Control1_Model()
        {
            if (IsInDesignMode)
            {

            }

        }


        //propvm tab tab string tab Title
        
        public CommandModel CommandNext => _CommandNextLocator(this).Value;
        #region Property CommandModel CommandNext Setup                
        protected Property<CommandModel> _CommandNext = new Property<CommandModel>(_CommandNextLocator);
        static Func<BindableBase, ValueContainer<CommandModel>> _CommandNextLocator = RegisterContainerLocator(nameof(CommandNext), m => m.Initialize(nameof(CommandNext), ref m._CommandNext, ref _CommandNextLocator,
              model =>
              {
                  object state = nameof(CommandNext);
                  var commandId = nameof(CommandNext);
                  var vm = CastToCurrentType(model);
                  var cmd = new ReactiveCommand(canExecute: true, commandId: commandId) { ViewModel = model };

                  cmd.DoExecuteUITask(
                          vm,
                          async e =>
                          {
                              var v = vm.StageManager.DefaultStage.Show<Control1_Model>();
                              await MVVMSidekick.Utilities.TaskExHelper.Yield();
                          })
                      .DoNotifyDefaultEventRouter(vm, commandId)
                      .Subscribe()
                      .DisposeWith(vm);

                  var cmdmdl = cmd.CreateCommandModel(state);

                  return cmdmdl;
              }));
        #endregion

    }

}

