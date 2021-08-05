
namespace DSCSJsonEditor
{
    partial class EditEntityForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.wikiUrlLabel = new System.Windows.Forms.Label();
            this.newGamePlusLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.wikiUrlTextBox = new System.Windows.Forms.TextBox();
            this.newGamePlusTextBox = new System.Windows.Forms.TextBox();
            this.editNewGamePlusButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.wikiUrlLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.newGamePlusLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.wikiUrlTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.newGamePlusTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.editNewGamePlusButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(80, 31);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // wikiUrlLabel
            // 
            this.wikiUrlLabel.AutoSize = true;
            this.wikiUrlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wikiUrlLabel.Location = new System.Drawing.Point(3, 31);
            this.wikiUrlLabel.Name = "wikiUrlLabel";
            this.wikiUrlLabel.Size = new System.Drawing.Size(80, 31);
            this.wikiUrlLabel.TabIndex = 1;
            this.wikiUrlLabel.Text = "Wiki URL";
            this.wikiUrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // newGamePlusLabel
            // 
            this.newGamePlusLabel.AutoSize = true;
            this.newGamePlusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newGamePlusLabel.Location = new System.Drawing.Point(3, 62);
            this.newGamePlusLabel.Name = "newGamePlusLabel";
            this.newGamePlusLabel.Size = new System.Drawing.Size(80, 31);
            this.newGamePlusLabel.TabIndex = 2;
            this.newGamePlusLabel.Text = "New Game+";
            this.newGamePlusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nameTextBox, 2);
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Location = new System.Drawing.Point(89, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(203, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // wikiUrlTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.wikiUrlTextBox, 2);
            this.wikiUrlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wikiUrlTextBox.Location = new System.Drawing.Point(89, 34);
            this.wikiUrlTextBox.Name = "wikiUrlTextBox";
            this.wikiUrlTextBox.Size = new System.Drawing.Size(203, 20);
            this.wikiUrlTextBox.TabIndex = 4;
            // 
            // newGamePlusTextBox
            // 
            this.newGamePlusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newGamePlusTextBox.Location = new System.Drawing.Point(89, 65);
            this.newGamePlusTextBox.Name = "newGamePlusTextBox";
            this.newGamePlusTextBox.ReadOnly = true;
            this.newGamePlusTextBox.Size = new System.Drawing.Size(137, 20);
            this.newGamePlusTextBox.TabIndex = 5;
            // 
            // editNewGamePlusButton
            // 
            this.editNewGamePlusButton.Location = new System.Drawing.Point(232, 65);
            this.editNewGamePlusButton.Name = "editNewGamePlusButton";
            this.editNewGamePlusButton.Size = new System.Drawing.Size(59, 23);
            this.editNewGamePlusButton.TabIndex = 6;
            this.editNewGamePlusButton.Text = "Edit";
            this.editNewGamePlusButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(89, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 25);
            this.panel1.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(49, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(128, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // EditEntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 124);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditEntityForm";
            this.Text = "EditEntityForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label wikiUrlLabel;
        private System.Windows.Forms.Label newGamePlusLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox wikiUrlTextBox;
        private System.Windows.Forms.TextBox newGamePlusTextBox;
        private System.Windows.Forms.Button editNewGamePlusButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}