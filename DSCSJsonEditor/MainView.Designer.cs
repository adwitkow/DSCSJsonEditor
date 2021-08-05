
namespace DSCSJsonEditor
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.stepsTreeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.addElementButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.mainViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.entitiesGroupBox = new System.Windows.Forms.GroupBox();
            this.entitiesDataGridView = new System.Windows.Forms.DataGridView();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            this.filtersDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.entitiesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).BeginInit();
            this.filtersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filtersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.stepsTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(832, 441);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 0;
            // 
            // stepsTreeView
            // 
            this.stepsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsTreeView.HideSelection = false;
            this.stepsTreeView.Location = new System.Drawing.Point(0, 46);
            this.stepsTreeView.Name = "stepsTreeView";
            this.stepsTreeView.Size = new System.Drawing.Size(206, 395);
            this.stepsTreeView.TabIndex = 0;
            this.stepsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.StepsTreeView_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.importButton);
            this.panel1.Controls.Add(this.exportButton);
            this.panel1.Controls.Add(this.removeElementButton);
            this.panel1.Controls.Add(this.addElementButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 46);
            this.panel1.TabIndex = 1;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(95, 8);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(51, 28);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(152, 8);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(51, 28);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(42, 8);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(28, 28);
            this.removeElementButton.TabIndex = 1;
            this.removeElementButton.Text = "-";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
            // 
            // addElementButton
            // 
            this.addElementButton.Location = new System.Drawing.Point(8, 8);
            this.addElementButton.Name = "addElementButton";
            this.addElementButton.Size = new System.Drawing.Size(28, 28);
            this.addElementButton.TabIndex = 0;
            this.addElementButton.Text = "+";
            this.addElementButton.UseVisualStyleBackColor = true;
            this.addElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.descriptionTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(622, 441);
            this.splitContainer2.SplitterDistance = 93;
            this.splitContainer2.TabIndex = 1;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainViewModelBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(622, 93);
            this.descriptionTextBox.TabIndex = 0;
            // 
            // mainViewModelBindingSource
            // 
            this.mainViewModelBindingSource.DataSource = typeof(DSCSJsonEditor.ViewModels.MainViewModel);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.entitiesGroupBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.filtersGroupBox);
            this.splitContainer3.Size = new System.Drawing.Size(622, 344);
            this.splitContainer3.SplitterDistance = 470;
            this.splitContainer3.TabIndex = 0;
            // 
            // entitiesGroupBox
            // 
            this.entitiesGroupBox.Controls.Add(this.entitiesDataGridView);
            this.entitiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entitiesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.entitiesGroupBox.Name = "entitiesGroupBox";
            this.entitiesGroupBox.Size = new System.Drawing.Size(470, 344);
            this.entitiesGroupBox.TabIndex = 1;
            this.entitiesGroupBox.TabStop = false;
            this.entitiesGroupBox.Text = "Entities";
            // 
            // entitiesDataGridView
            // 
            this.entitiesDataGridView.AllowUserToAddRows = false;
            this.entitiesDataGridView.AllowUserToDeleteRows = false;
            this.entitiesDataGridView.AllowUserToResizeRows = false;
            this.entitiesDataGridView.AutoGenerateColumns = false;
            this.entitiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entitiesDataGridView.DataSource = this.mainViewModelBindingSource;
            this.entitiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entitiesDataGridView.Location = new System.Drawing.Point(3, 16);
            this.entitiesDataGridView.Name = "entitiesDataGridView";
            this.entitiesDataGridView.ReadOnly = true;
            this.entitiesDataGridView.RowHeadersVisible = false;
            this.entitiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.entitiesDataGridView.Size = new System.Drawing.Size(464, 325);
            this.entitiesDataGridView.TabIndex = 0;
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.Controls.Add(this.filtersDataGridView);
            this.filtersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersGroupBox.Location = new System.Drawing.Point(0, 0);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(148, 344);
            this.filtersGroupBox.TabIndex = 2;
            this.filtersGroupBox.TabStop = false;
            this.filtersGroupBox.Text = "Filters";
            // 
            // filtersDataGridView
            // 
            this.filtersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filtersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersDataGridView.Location = new System.Drawing.Point(3, 16);
            this.filtersDataGridView.Name = "filtersDataGridView";
            this.filtersDataGridView.Size = new System.Drawing.Size(142, 325);
            this.filtersDataGridView.TabIndex = 1;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 441);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainView";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainViewModelBindingSource)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.entitiesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).EndInit();
            this.filtersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filtersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView stepsTreeView;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button removeElementButton;
        private System.Windows.Forms.Button addElementButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView entitiesDataGridView;
        private System.Windows.Forms.DataGridView filtersDataGridView;
        private System.Windows.Forms.GroupBox entitiesGroupBox;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.BindingSource mainViewModelBindingSource;
    }
}

