namespace Shop
{
    partial class fShop
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.bAddObj = new System.Windows.Forms.Button();
            this.lAllGoodsOnShelf = new System.Windows.Forms.Label();
            this.lAllGoods = new System.Windows.Forms.Label();
            this.lGoodsCnt = new System.Windows.Forms.Label();
            this.cbClasses = new System.Windows.Forms.ComboBox();
            this.lbShelf = new Shop.Tools.OriginatorList();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemSer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSerText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSerEn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDesText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDesDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSort = new System.Windows.Forms.ToolStripMenuItem();
            this.bSaveState = new System.Windows.Forms.Button();
            this.bRestoreState = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAddObj
            // 
            this.bAddObj.Location = new System.Drawing.Point(7, 63);
            this.bAddObj.Name = "bAddObj";
            this.bAddObj.Size = new System.Drawing.Size(194, 29);
            this.bAddObj.TabIndex = 1;
            this.bAddObj.Text = "Create";
            this.bAddObj.UseVisualStyleBackColor = true;
            this.bAddObj.Click += new System.EventHandler(this.bAddObj_Click);
            // 
            // lAllGoodsOnShelf
            // 
            this.lAllGoodsOnShelf.AutoSize = true;
            this.lAllGoodsOnShelf.Location = new System.Drawing.Point(6, 429);
            this.lAllGoodsOnShelf.Name = "lAllGoodsOnShelf";
            this.lAllGoodsOnShelf.Size = new System.Drawing.Size(0, 13);
            this.lAllGoodsOnShelf.TabIndex = 11;
            // 
            // lAllGoods
            // 
            this.lAllGoods.AutoSize = true;
            this.lAllGoods.Location = new System.Drawing.Point(4, 274);
            this.lAllGoods.Name = "lAllGoods";
            this.lAllGoods.Size = new System.Drawing.Size(68, 13);
            this.lAllGoods.TabIndex = 12;
            this.lAllGoods.Text = "All products: ";
            // 
            // lGoodsCnt
            // 
            this.lGoodsCnt.AutoSize = true;
            this.lGoodsCnt.Location = new System.Drawing.Point(96, 274);
            this.lGoodsCnt.Name = "lGoodsCnt";
            this.lGoodsCnt.Size = new System.Drawing.Size(13, 13);
            this.lGoodsCnt.TabIndex = 13;
            this.lGoodsCnt.Text = "0";
            // 
            // cbClasses
            // 
            this.cbClasses.FormattingEnabled = true;
            this.cbClasses.Location = new System.Drawing.Point(7, 36);
            this.cbClasses.Name = "cbClasses";
            this.cbClasses.Size = new System.Drawing.Size(194, 21);
            this.cbClasses.TabIndex = 14;
            // 
            // lbShelf
            // 
            this.lbShelf.FormattingEnabled = true;
            this.lbShelf.Location = new System.Drawing.Point(207, 36);
            this.lbShelf.Name = "lbShelf";
            this.lbShelf.Size = new System.Drawing.Size(326, 251);
            this.lbShelf.TabIndex = 15;
            this.lbShelf.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbShelf_MouseDoubleClick);
            this.lbShelf.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbShelf_MouseUp);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSer,
            this.menuItemDes,
            this.menuItemSort});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(540, 24);
            this.menu.TabIndex = 21;
            this.menu.Text = "menu";
            // 
            // menuItemSer
            // 
            this.menuItemSer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSerText,
            this.menuItemSerEn});
            this.menuItemSer.Name = "menuItemSer";
            this.menuItemSer.Size = new System.Drawing.Size(82, 20);
            this.menuItemSer.Text = "Serialization";
            // 
            // menuItemSerText
            // 
            this.menuItemSerText.Name = "menuItemSerText";
            this.menuItemSerText.Size = new System.Drawing.Size(181, 22);
            this.menuItemSerText.Text = "Text";
            this.menuItemSerText.Click += new System.EventHandler(this.menuItemSerText_Click);
            // 
            // menuItemSerEn
            // 
            this.menuItemSerEn.Name = "menuItemSerEn";
            this.menuItemSerEn.Size = new System.Drawing.Size(181, 22);
            this.menuItemSerEn.Text = "Text with encryption";
            this.menuItemSerEn.Click += new System.EventHandler(this.menuItemSerEn_Click);
            // 
            // menuItemDes
            // 
            this.menuItemDes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDesText,
            this.menuItemDesDe});
            this.menuItemDes.Name = "menuItemDes";
            this.menuItemDes.Size = new System.Drawing.Size(95, 20);
            this.menuItemDes.Text = "Deserialization";
            // 
            // menuItemDesText
            // 
            this.menuItemDesText.Name = "menuItemDesText";
            this.menuItemDesText.Size = new System.Drawing.Size(181, 22);
            this.menuItemDesText.Text = "Text ";
            this.menuItemDesText.Click += new System.EventHandler(this.menuItemDesText_Click);
            // 
            // menuItemDesDe
            // 
            this.menuItemDesDe.Name = "menuItemDesDe";
            this.menuItemDesDe.Size = new System.Drawing.Size(181, 22);
            this.menuItemDesDe.Text = "Text with decryption";
            this.menuItemDesDe.Click += new System.EventHandler(this.menuItemDesDe_Click);
            // 
            // menuItemSort
            // 
            this.menuItemSort.Name = "menuItemSort";
            this.menuItemSort.Size = new System.Drawing.Size(40, 20);
            this.menuItemSort.Text = "Sort";
            this.menuItemSort.Click += new System.EventHandler(this.menuItemSort_Click);
            // 
            // bSaveState
            // 
            this.bSaveState.Location = new System.Drawing.Point(7, 207);
            this.bSaveState.Name = "bSaveState";
            this.bSaveState.Size = new System.Drawing.Size(194, 29);
            this.bSaveState.TabIndex = 22;
            this.bSaveState.Text = "Save state";
            this.bSaveState.UseVisualStyleBackColor = true;
            this.bSaveState.Click += new System.EventHandler(this.bSaveState_Click);
            // 
            // bRestoreState
            // 
            this.bRestoreState.Location = new System.Drawing.Point(7, 242);
            this.bRestoreState.Name = "bRestoreState";
            this.bRestoreState.Size = new System.Drawing.Size(194, 29);
            this.bRestoreState.TabIndex = 23;
            this.bRestoreState.Text = "Restore state";
            this.bRestoreState.UseVisualStyleBackColor = true;
            this.bRestoreState.Click += new System.EventHandler(this.bRestoreState_Click);
            // 
            // fShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(540, 293);
            this.Controls.Add(this.bRestoreState);
            this.Controls.Add(this.bSaveState);
            this.Controls.Add(this.lbShelf);
            this.Controls.Add(this.cbClasses);
            this.Controls.Add(this.lGoodsCnt);
            this.Controls.Add(this.lAllGoods);
            this.Controls.Add(this.lAllGoodsOnShelf);
            this.Controls.Add(this.bAddObj);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menu;
            this.Name = "fShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bAddObj;
        private System.Windows.Forms.Label lAllGoodsOnShelf;
        private System.Windows.Forms.Label lAllGoods;
        private System.Windows.Forms.Label lGoodsCnt;
        private System.Windows.Forms.ComboBox cbClasses;
        private Shop.Tools.OriginatorList lbShelf;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemSer;
        private System.Windows.Forms.ToolStripMenuItem menuItemDes;
        private System.Windows.Forms.ToolStripMenuItem menuItemSerText;
        private System.Windows.Forms.ToolStripMenuItem menuItemSerEn;
        private System.Windows.Forms.ToolStripMenuItem menuItemDesText;
        private System.Windows.Forms.ToolStripMenuItem menuItemDesDe;
        private System.Windows.Forms.ToolStripMenuItem menuItemSort;
        private System.Windows.Forms.Button bSaveState;
        private System.Windows.Forms.Button bRestoreState;
    }
}

