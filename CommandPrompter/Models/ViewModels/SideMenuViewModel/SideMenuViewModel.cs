﻿using CommandPrompter.Helpers;
using CommandPrompter.Resources.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace CommandPrompter.Models.ViewModels
{
    public class SideMenuViewModel : BaseViewModel
    {
        private SideMenu sideMenu;
        public ObservableCollection<SideMenuItemViewModel> SideMenuItems { get; set; } = new ObservableCollection<SideMenuItemViewModel>();
        public SideMenuViewModel(SideMenu sideMenu)
        {
            this.sideMenu = sideMenu;

            var welcome = new SideMenuItemViewModel(PageEnum.Welcome);
            welcome.Icon = sideMenu.FindResource("Welcome") as string;
            welcome.ItemName = "Welcome";
            SideMenuItems.Add(welcome);

            var plateform = new SideMenuItemViewModel(PageEnum.Plateform);
            plateform.Icon = sideMenu.FindResource("Plateform") as string;
            plateform.ItemName = "Plateform";
            SideMenuItems.Add(plateform);

            var command = new SideMenuItemViewModel(PageEnum.Command);
            command.Icon = sideMenu.FindResource("Command") as string;
            command.ItemName = "Command";
            SideMenuItems.Add(command);

            var commandChain = new SideMenuItemViewModel(PageEnum.CommandChain);
            commandChain.Icon = sideMenu.FindResource("CommandChain") as string;
            commandChain.ItemName = "C-Chain";
            SideMenuItems.Add(commandChain);

        }
    }
}
