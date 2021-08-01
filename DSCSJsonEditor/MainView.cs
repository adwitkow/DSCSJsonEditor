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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DSCSJsonEditor.Models;
using DSCSJsonEditor.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DSCSJsonEditor
{
    public partial class MainView : Form
    {
        private EntityParser entityParser;

        private Dictionary<TreeNode, Area> areaLookup;
        private Dictionary<TreeNode, Step> stepLookup;
        private MainViewModel viewModel;

        public MainView()
        {
            this.entityParser = new EntityParser();

            // TODO: Figure out if we really want to store the TreeNodes as keys
            this.areaLookup = new Dictionary<TreeNode, Area>();
            this.stepLookup = new Dictionary<TreeNode, Step>();

            this.viewModel = new MainViewModel();
            this.viewModel.PropertyChanged += this.ViewModel_PropertyChanged;

            this.InitializeComponent();
            this.PopulateStepsTreeView();

            this.mainViewModelBindingSource.DataSource = this.viewModel;
            var source = new BindingSource(this.viewModel, nameof(MainViewModel.Entities));
            this.entitiesDataGridView.AutoGenerateColumns = true;
            this.entitiesDataGridView.DataSource = source;
        }

        private void AddElementButton_Click(object sender, System.EventArgs e)
        {
            var selectedNode = this.stepsTreeView.SelectedNode;

            if (selectedNode is null)
            {
                return;
            }

            IStepContainer container;
            if (this.areaLookup.ContainsKey(selectedNode))
            {
                container = this.areaLookup[selectedNode];
            }
            else
            {
                container = this.stepLookup[selectedNode];
            }

            var newStep = new Step();
            var newNode = new TreeNode();

            selectedNode.Nodes.Add(newNode);
            container.Steps.Add(newStep);
            this.stepLookup.Add(newNode, newStep);

            selectedNode.Expand();
            this.stepsTreeView.SelectedNode = newNode;
        }

        private void RemoveElementButton_Click(object sender, System.EventArgs e)
        {
            var selectedNode = this.stepsTreeView.SelectedNode;
            var parentNode = selectedNode.Parent;

            if (selectedNode is null || parentNode is null)
            {
                return;
            }

            if (this.areaLookup.ContainsKey(selectedNode))
            {
                // area node, can't delete
                return;
            }

            var selectedStep = this.stepLookup[selectedNode];

            IStepContainer container;
            if (this.areaLookup.ContainsKey(parentNode))
            {
                container = this.areaLookup[parentNode];
            }
            else
            {
                container = this.stepLookup[parentNode];
            }

            // TODO: The substeps should be removed as well (recursively).
            // Currently we are only removing the nodes;
            // the steps, however, remain in memory.
            // And for some reason it doesn't look like they get gc'd.
            container.Steps.Remove(selectedStep);
            this.stepLookup.Remove(selectedNode);
            parentNode.Nodes.Remove(selectedNode);
        }

        private void StepsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.stepLookup.ContainsKey(e.Node))
            {
                this.viewModel.SelectedStep = this.stepLookup[e.Node];
            }
            else
            {
                this.viewModel.SelectedStep = null;
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(MainViewModel.Description))
            {
                return;
            }

            var selectedNode = this.stepsTreeView.SelectedNode;
            if (this.areaLookup.ContainsKey(selectedNode))
            {
                return;
            }

            var description = this.viewModel.Description;
            selectedNode.Text = description;
            var entityNames = this.entityParser.Parse(description).ToList();
            var existingEntities = this.viewModel.Entities;

            // find entities that exist in the viewmodel but not in parsed results and delete them
            var matchingEntities = existingEntities.Where(entity => entityNames.Contains(entity.TagName));
            for (int i = existingEntities.Count - 1; i >= 0; i--)
            {
                var existingEntity = existingEntities.ElementAt(i);
                if (!matchingEntities.Contains(existingEntity))
                {
                    existingEntities.Remove(existingEntity);
                }
            }

            // find entities that were returned from parser but aren't available in viewmodel and add them
            var existingEntityNames = existingEntities.Select(entity => entity.TagName);
            var entityNamesToAdd = entityNames.Where(entityName => !existingEntityNames.Contains(entityName));
            var entitiesToAdd = entityNamesToAdd.Select(entityName => new Entity(entityName));

            foreach (var entity in entitiesToAdd)
            {
                existingEntities.Add(entity);
            }

            // TODO: Order the ViewModel Entities BindingList based on the entity names collection
            // var orderedEntities = existingEntities.OrderBy(entity => entityNames.IndexOf(entity.TagName)).ToList();
            // this.viewModel.Entities = new BindingList<Entity>(orderedEntities);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var areas = this.areaLookup.Select(pair => pair.Value);

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };

            Console.WriteLine(JsonConvert.SerializeObject(areas, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver,
            }));
        }

        private void PopulateStepsTreeView()
        {
            foreach (var area in this.viewModel.Areas)
            {
                var node = new TreeNode(area.Name);
                this.stepsTreeView.Nodes.Add(node);
                this.areaLookup.Add(node, area);
            }
        }
    }
}
