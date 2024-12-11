namespace CarPartWarehouseManagerApp
{
    partial class CarPartWarehouseManagerApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gb_Navigation = new GroupBox();
            btn_ProductOverview = new Button();
            btn_SubcategoryOverview = new Button();
            btn_CategoryOverview = new Button();
            gb_Navigation.SuspendLayout();
            SuspendLayout();
            // 
            // gb_Navigation
            // 
            gb_Navigation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_Navigation.Controls.Add(btn_ProductOverview);
            gb_Navigation.Controls.Add(btn_SubcategoryOverview);
            gb_Navigation.Controls.Add(btn_CategoryOverview);
            gb_Navigation.Location = new Point(12, 12);
            gb_Navigation.Name = "gb_Navigation";
            gb_Navigation.Size = new Size(982, 90);
            gb_Navigation.TabIndex = 0;
            gb_Navigation.TabStop = false;
            gb_Navigation.Text = "Navigation";
            // 
            // btn_ProductOverview
            // 
            btn_ProductOverview.Location = new Point(355, 26);
            btn_ProductOverview.Name = "btn_ProductOverview";
            btn_ProductOverview.Size = new Size(129, 54);
            btn_ProductOverview.TabIndex = 2;
            btn_ProductOverview.Text = "Producten";
            btn_ProductOverview.UseVisualStyleBackColor = true;
            // 
            // btn_SubcategoryOverview
            // 
            btn_SubcategoryOverview.Location = new Point(170, 26);
            btn_SubcategoryOverview.Name = "btn_SubcategoryOverview";
            btn_SubcategoryOverview.Size = new Size(129, 54);
            btn_SubcategoryOverview.TabIndex = 1;
            btn_SubcategoryOverview.Text = "Subcategorieën";
            btn_SubcategoryOverview.UseVisualStyleBackColor = true;
            // 
            // btn_CategoryOverview
            // 
            btn_CategoryOverview.Location = new Point(6, 26);
            btn_CategoryOverview.Name = "btn_CategoryOverview";
            btn_CategoryOverview.Size = new Size(129, 54);
            btn_CategoryOverview.TabIndex = 0;
            btn_CategoryOverview.Text = "Categorieën";
            btn_CategoryOverview.UseVisualStyleBackColor = true;
            btn_CategoryOverview.Click += btn_CategoryOverview_Click;
            // 
            // CarPartWarehouseManagerApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 529);
            Controls.Add(gb_Navigation);
            Name = "CarPartWarehouseManagerApp";
            Text = "CarPartWarehouseManagerApp";
            gb_Navigation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_Navigation;
        private Button btn_CategoryOverview;
        private Button btn_ProductOverview;
        private Button btn_SubcategoryOverview;
    }
}
