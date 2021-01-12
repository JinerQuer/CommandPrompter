﻿using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CommandPrompter.Models.ViewModels
{
    public class SearchBarViewModel : SimpleViewModel
    {
        public bool CommandRunning { get; private set; }


        private SearchBar searchBar;
        public ObservableCollection<RelatedNameResponseDto> RelatedNames { get; set; } = new ObservableCollection<RelatedNameResponseDto>();
        public SearchBarViewModel(SearchBar searchBar)
        {
            this.searchBar = searchBar;
        }
        public void GetRelatedNames(string name = "", int count = 100)
        {
            searchBar.IsLoading = true;
            searchBar.IsExpanded = false;
            if (!string.IsNullOrEmpty(name))
            {
                _ = HttpRequestHelper.GetAsync<List<RelatedNameResponseDto>>(RouteHelper.ReplaceParam(RouteHelper.GetRelatedNames, name, count.ToString()), res =>
                   {
                       RelatedNames.Clear();
                       searchBar.Dispatcher.Invoke(() =>
                       {
                           RelatedNames.Clear();
                           if (res != null && res.Count != 0)
                           {
                               RelatedNames.Clear();
                               foreach (var item in res)
                               {
                                   RelatedNames.Add(item);
                               }
                               searchBar.IsExpanded = true;
                           }
                           else
                           {
                               if(searchBar.IsExpanded == true)
                               {
                                   searchBar.IsExpanded = false;
                               }
                           }
                           searchBar.IsLoading = false;
                       });
                   });
            }
            else
            {
                if (searchBar.IsExpanded == true)
                {
                    searchBar.IsExpanded = false;
                }
            }
        }
        public void ClearRelatedNames()
        {
            RelatedNames.Clear();
        }

        public void JumpToDetail(string id)
        {
            _ = RunCommandAsync(() => CommandRunning, async () =>
               {
                   var item = searchBar.SelectedItem;
                   switch (item.Type)
                   {
                       case "Plateform":
                           SwitchPage = PageEnum.Plateform;
                           _ = ShowPageAsync();
                           break;
                       case "Command":
                           SwitchPage = PageEnum.Command;
                           _ = ShowPageAsync();
                           break;
                       case "CommandParameter":
                           SwitchPage = PageEnum.CommandParameter;
                           _ = ShowPageAsync();
                           break;
                       case "CommandChain":
                           SwitchPage = PageEnum.CommandChain;
                           _ = ShowPageAsync();
                           break;
                       case "User":
                           SwitchPage = PageEnum.User;
                           _ = ShowPageAsync();
                           break;
                       default:
                           SwitchPage = PageEnum.Error;
                           _ = ShowPageAsync();
                           break;
                   }
               });
            
        }
    }
}
