// This file is part of DSCSJsonEditor project <https://github.com/adwitkow/DSCSJsonEditor>
// Copyright (C) 2021  Adam Witkowski <https://github.com/adwitkow/>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using DSCSJsonEditor.Core;
using DSCSJsonEditor.Core.Models;
using DSCSJsonEditor.WPF.Events;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class EditStepViewModel : BindableBase
    {
        private Step selectedStep;
        private Entity selectedEntity;
        private Filter selectedFilter;

        public Entity SelectedEntity
        {
            get => this.selectedEntity;
            set
            {
                if (this.SetProperty(ref this.selectedEntity, value))
                {
                    this.NotifyPropertyChanged(nameof(this.CanEditEntity));
                    this.NotifyPropertyChanged(nameof(this.SelectedEntityNewGamePlusName));
                    this.NotifyPropertyChanged(nameof(this.SelectedEntityNewGamePlusWikiUrl));
                }
            }
        }

        public Step SelectedStep
        {
            get => this.selectedStep;
            set
            {
                if (this.SetProperty(ref this.selectedStep, value))
                {
                    this.NotifyPropertyChanged(nameof(this.CanEditStep));
                    this.NotifyPropertyChanged(nameof(this.Description));
                }
            }
        }

        public Filter SelectedFilter
        {
            get => this.selectedFilter;
            set
            {
                if (this.SetProperty(ref this.selectedFilter, value))
                {
                    this.NotifyPropertyChanged(nameof(this.CanRemoveFilter));
                }
            }
        }

        public string Description
        {
            get => this.SelectedStep?.Description;
            set
            {
                if (this.SelectedStep is null)
                {
                    return;
                }

                this.SelectedStep.Description = value;
                this.UpdateEntities(value);
                this.NotifyPropertyChanged();
            }
        }

        public string SelectedEntityNewGamePlusName
        {
            get => this.selectedEntity?.Details.NewGamePlusEntity?.Name;
            set
            {
                // TODO: This is ugly, fix this or at least move it somewhere else
                if (string.IsNullOrEmpty(value) && this.selectedEntity.Details.NewGamePlusEntity?.WikiUrl is null)
                {
                    this.selectedEntity.Details.NewGamePlusEntity = null;
                }
                else
                {
                    if (this.selectedEntity.Details.NewGamePlusEntity is null)
                    {
                        this.selectedEntity.Details.NewGamePlusEntity = new EntityDetails();
                    }

                    this.selectedEntity.Details.NewGamePlusEntity.Name = value;
                }
            }
        }

        public string SelectedEntityNewGamePlusWikiUrl
        {
            get => this.selectedEntity?.Details.NewGamePlusEntity?.WikiUrl;
            set
            {
                // TODO: This is ugly, fix this or at least move it somewhere else
                if (string.IsNullOrEmpty(value) && this.selectedEntity.Details.NewGamePlusEntity?.Name is null)
                {
                    this.selectedEntity.Details.NewGamePlusEntity = null;
                }
                else
                {
                    if (this.selectedEntity.Details.NewGamePlusEntity is null)
                    {
                        this.selectedEntity.Details.NewGamePlusEntity = new EntityDetails();
                    }

                    this.selectedEntity.Details.NewGamePlusEntity.WikiUrl = value;
                }
            }
        }

        public DelegateCommand AddFilterCommand => new DelegateCommand(this.AddFilter);

        public DelegateCommand RemoveFilterCommand => new DelegateCommand(this.RemoveFilter);

        public bool CanEditStep => this.selectedStep is not null;

        public bool CanEditEntity => this.selectedEntity != null;

        public bool CanRemoveFilter => this.selectedFilter is not null;

        public ObservableCollection<Entity> Entities { get => this.SelectedStep.Entities; }

        private void RemoveFilter(object obj)
        {
            this.SelectedStep.Filters.Remove(this.selectedFilter);
        }

        private void AddFilter(object obj)
        {
            this.SelectedStep.Filters.Add(new Filter("New Filter"));
        }

        private void UpdateEntities(string description)
        {
            var entityNames = EntityParser.Parse(description).ToList();

            // find entities that exist in the viewmodel but not in parsed results and delete them
            var matchingEntities = this.Entities.Where(entity => entityNames.Contains(entity.TagName));
            for (int i = this.Entities.Count - 1; i >= 0; i--)
            {
                var existingEntity = this.Entities.ElementAt(i);
                if (!matchingEntities.Contains(existingEntity))
                {
                    this.Entities.Remove(existingEntity);
                }
            }

            // find entities that were returned from parser but aren't available in viewmodel and add them
            var existingEntityNames = this.Entities.Select(entity => entity.TagName);
            var entityNamesToAdd = entityNames.Where(entityName => !existingEntityNames.Contains(entityName));
            var entitiesToAdd = entityNamesToAdd.Select(entityName => new Entity(entityName));

            foreach (var entity in entitiesToAdd)
            {
                this.Entities.Add(entity);
            }
        }
    }
}