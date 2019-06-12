using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CipherInterface;
using GoodsClasses;
using Sort;
using Shop.Tools;

namespace Shop
{
    public partial class fShop : Form
    {
        Assembly assembly = Assembly.Load("Shop");
        
        private void AddTypes() {
            foreach (Type type in assembly.GetTypes()) {
                if (!type.IsAbstract && type.Namespace == "GoodsClasses" && type.IsClass) {                 
                    cbClasses.Items.Add(type);
                }
            }
        }

        public fShop() {
            InitializeComponent();            
            AddTypes();
            if (cbClasses.Items.Count != 0) {
                cbClasses.SelectedIndex = 0;
            } 
        }      

        private bool CheckField() {
            if (cbClasses.SelectedItem == null) {
                MessageBox.Show("Select type.");
                return false;
            }
            return true;
        }

        Form fCreate;
        
        private void SetButtonOnClickEvent(Button button,TextBox[] tbParameters, ParameterInfo[] lParamName, Type type) {
            button.Click += new EventHandler(bCreateClick);

            void bCreateClick(object sender, EventArgs e) {
                bool check = true;
                object[] prms = new object[tbParameters.Length];

                try {
                    for (int i = 0; i < tbParameters.Length; i++) {                                              
                        prms[i] = Convert.ChangeType(tbParameters[i].Text, lParamName[i].ParameterType);                      
                    }
                }
                catch {
                    check = false;
                }

                if (check) {
                    object obj = Activator.CreateInstance(type, prms);                   
                    lbShelf.Items.Add(obj);
                    lGoodsCnt.Text = Goods.GetCntOfGoods().ToString();
                    
                    fCreate.Hide();                   
                    fCreate.Dispose();
                }
                else {
                    MessageBox.Show("Error");
                }
            }
        }
       
        private const int TB_LEFT = 100;
        private const int TB_TOP = 10;
        private const int TB_WIDTH = 130;
        private const int TB_HEIGHT = 30;

        private const int B_WIDTH = 100;
        private const int B_HEIGHT = 30;

        private const int L_LEFT = 5;

        private void CreateForm(ParameterInfo[] parametrs, Type type) {
            fCreate = new Form();
            fCreate.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            fCreate.StartPosition = FormStartPosition.CenterScreen;
            TextBox[] tbParameters = new TextBox[parametrs.Length];
            Label[] lParamName = new Label[parametrs.Length];
            for (int i = 0; i < tbParameters.Length; i++) {
                tbParameters[i] = new TextBox();
                lParamName[i] = new Label();

                tbParameters[i].Left = TB_LEFT;
                tbParameters[i].Top = i * TB_HEIGHT + TB_TOP;
                tbParameters[i].Width = TB_WIDTH;
                tbParameters[i].Height = TB_HEIGHT;

                lParamName[i].Top = i * TB_HEIGHT + 5 + TB_TOP;
                lParamName[i].Left = L_LEFT;
                lParamName[i].Text = parametrs[i].Name + ":";

                fCreate.Controls.Add(tbParameters[i]);
                fCreate.Controls.Add(lParamName[i]);
            }
            Button bCreateNewObj = new Button();
            bCreateNewObj.Text = "Create";
            bCreateNewObj.Width = B_WIDTH;
            bCreateNewObj.Height = B_HEIGHT;
            bCreateNewObj.Left = (fCreate.Width - bCreateNewObj.Width) / 2;
            bCreateNewObj.Top = fCreate.Height - bCreateNewObj.Height * 3;
            fCreate.Controls.Add(bCreateNewObj);
            SetButtonOnClickEvent(bCreateNewObj, tbParameters, parametrs, type);
            fCreate.Show(this);
        }                       

        private void CreateNewObject() {            
            Type type = cbClasses.SelectedItem as Type;
            ConstructorInfo[] constructors = type.GetConstructors();
            ParameterInfo[] parametrs = constructors[0].GetParameters();            
            CreateForm(parametrs, type);                 
        }

        private const int MAX_CNT_OF_OBJ = 64;

        private void bAddObj_Click(object sender, EventArgs e) {
            if (lbShelf.Items.Count < MAX_CNT_OF_OBJ) {
                if (CheckField()) {
                    CreateNewObject();
                }
            }
            else {
                MessageBox.Show("Error. Too many objects.");
            }
        }

        private void lbShelf_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                lbShelf.SelectedIndex = lbShelf.IndexFromPoint(e.X, e.Y);
                if (lbShelf.SelectedIndex != -1) {
                    Type type = lbShelf.SelectedItem.GetType();
                    MethodInfo method = type.GetMethod("GetInfo");
                    MessageBox.Show((string)method.Invoke(lbShelf.SelectedItem, null));
                }
            }
        }

        private void lbShelf_MouseDoubleClick(object sender, MouseEventArgs e) {
            lbShelf.SelectedIndex = lbShelf.IndexFromPoint(e.X, e.Y);            
            if (lbShelf.SelectedIndex != -1) {
                lbShelf.Items.RemoveAt(lbShelf.SelectedIndex);
                lGoodsCnt.Text = Goods.DecCntOfGoods().ToString();
            }            
        }

        private List<object> ListBoxItemsToList(ListBox.ObjectCollection listbox) {
            List<object> list = new List<object>();
            for (int i = 0; i < listbox.Count; i++) {
                list.Add(listbox[i]);
            }
            return list;
        }              

        private void menuItemSerEn_Click(object sender, EventArgs e) {
            Serialization serialization = new Serialization();
            serialization.SetComponent(new SerializationWithEncryption());
            serialization.SerializeObjects(ListBoxItemsToList(lbShelf.Items));            
        }

        private void menuItemSerText_Click(object sender, EventArgs e) {
            Serialization serialization = new Serialization();
            serialization.SetComponent(new SimpleTextSerialization());
            serialization.SerializeObjects(ListBoxItemsToList(lbShelf.Items));
        }

        private void menuItemDesDe_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "txt";
            openFile.Filter = "txt files (*.txt)|*.txt";
            try {
                if (openFile.ShowDialog() == DialogResult.OK) {
                    ObjEnumerator objs = Deserialization.DeserializeWithDe(openFile.FileName);
                    foreach (object obj in objs) {
                        lbShelf.Items.Add(obj);
                    }
                    lGoodsCnt.Text = Goods.GetCntOfGoods().ToString();
                }
            }
            catch (Exception error) {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void menuItemDesText_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "txt";
            openFile.Filter = "txt files (*.txt)|*.txt";
            try {
                if (openFile.ShowDialog() == DialogResult.OK) {

                    using (StreamReader sr = new StreamReader(openFile.FileName, System.Text.Encoding.Default)) {
                        var lines = new List<string>();
                        while (!sr.EndOfStream) {
                            lines.Add(sr.ReadLine());
                        }
           
                        ObjEnumerator tmplist = Deserialization.Deserialize(lines);
                        foreach (object obj in tmplist) {
                            lbShelf.Items.Add(obj);
                        }                                  
                        lGoodsCnt.Text = Goods.GetCntOfGoods().ToString();                       
                    }
                    MessageBox.Show("It's deserialized.");
                }
            }
            catch (Exception error) {
                MessageBox.Show(error.Message, "Error");
            }
        }

        

        const string PROPERTY_NAME_SORT = "Name";

        private void menuItemSort_Click(object sender, EventArgs e) {
            if (lbShelf.Items.Count > 0) {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.DefaultExt = "dll";
                openFile.Filter = "dll files (*.dll)|*.dll";
                if (openFile.ShowDialog() == DialogResult.OK) {
                    try {
                        Assembly asm = Assembly.LoadFrom(openFile.FileName);
                        Type type = Plugin.DownloadSortPlugin(asm);
                        var plugin = asm.CreateInstance(type.FullName) as ISort;
                        List<object> sortedList = ListBoxItemsToList(lbShelf.Items);
                        sortedList = plugin.Sort(sortedList, PROPERTY_NAME_SORT);
                        lbShelf.Items.Clear();
                        foreach (var item in sortedList) {
                            lbShelf.Items.Add(item);
                        }
                    }
                    catch {
                        MessageBox.Show("Failed to load plugin or error in plugin's work.");
                    }

                }
            }
            else {
                MessageBox.Show("There are no objects.");
            }

        }

        Caretaker state;

        private void bSaveState_Click(object sender, EventArgs e) {
            if (lbShelf.Items.Count != 0) {
                state = new Caretaker();
                state.Memento = lbShelf.CreateMemento();
                MessageBox.Show("It's saved.");
            }
            else {
                MessageBox.Show("There are no objects.");
            }
        }

        private void bRestoreState_Click(object sender, EventArgs e) {
            if (state != null) {                       
                lbShelf.SetMemento(state.Memento);
            }
            else {
                MessageBox.Show("There are no saved states.");
            }
        }
    }
}