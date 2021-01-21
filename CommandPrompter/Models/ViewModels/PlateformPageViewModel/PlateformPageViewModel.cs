﻿using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Controls;
using CommandPrompter.Resources.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CommandPrompter.Models.ViewModels
{
    public class PlateformPageViewModel : PageViewModel<PlateformPage>
    {
        //Open the detail page.
        public ICommand DetailCommand { get; private set; }
        public ObservableCollection<PlateformResponseDto> Plateforms { get; private set; } = new ObservableCollection<PlateformResponseDto>();
        public PlateformPageViewModel(PlateformPage page) : base(page)
        {
            var query = PageSwitchHelper.GetContext("PlateformPageInitQuery") as List<QueryField>;
            if (query == null || query.Count == 0)
            {
                GetAllPlateforms();
            }
            else
            {
                _ = HttpRequestHelper.PostAsync<List<PlateformResponseDto>>(RouteHelper.GetPlateforms, JsonConvert.SerializeObject(query), res =>
                {
                    UpdateUI(() =>
                    {
                        Plateforms.Clear();
                        foreach (var item in res)
                        {
                            Plateforms.Add(item);
                        }
                    });
                });
            }
            (page.FindName("Popup") as Popup).IsPoppedUp = true;
        }
        public void GetAllPlateforms()
        {
            _ = HttpRequestHelper.GetAsync<List<PlateformResponseDto>>(RouteHelper.GetAllPlateforms, res =>
            {
                UpdateUI(() =>
                {
                    Plateforms.Clear();
                    foreach (var item in res)
                    {
                        Plateforms.Add(item);
                    }
                });
            });
        }

        //private 
    }
}
