using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;
using Recog.BlankRecognition;
using Recog.PTests.PNN;
using Recog.PTests.Kettell;
using Recog.PTests.FPI;
using Recog.PTests.D;
namespace Recog.PTests
{
    public partial class PEditorForm : Form
    {
        private pBaseEntities _ge;
        public PEditorForm(pBaseEntities GlobalEntities)
        {
            InitializeComponent();
            _ge = GlobalEntities;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_settings.htm#edit_cort");
        }

       
        private void PEForm_Load(object sender, EventArgs e)
        {

            this.LoadTests(lst_all, false);
            this.LoadPacks();
            this.lst_all.Columns[1].Width = this.lst_all.Width;
            this.lst_pooll.Columns[1].Width = this.lst_pooll.Width;
            this.lst_packs.Columns[1].Width = this.lst_pooll.Width;
          
        }
       

        private void btn_right_Click(object sender, EventArgs e)
        {
            if (lst_all.SelectedItems.Count == 1)
            {
                int i = lst_all.SelectedItems[0].Index;
                lst_pooll.Items.Add((ListViewItem)lst_all.SelectedItems[0].Clone());
               // lst_all.SelectedItems[0].Remove();
                if (lst_all.Items.Count != 0 & i != 0)
                {
                    lst_all.Items[i - 1].Selected = true;
                }
            }
            
        }

        private void btn_left_Click(object sender, EventArgs e)
        {

            if (lst_pooll.SelectedItems.Count == 1)
            {
                int i = lst_pooll.SelectedItems[0].Index;
              //  lst_all.Items.Add((ListViewItem)lst_pooll.SelectedItems[0].Clone());
                lst_pooll.Items.Remove(lst_pooll.SelectedItems[0]);
                               
                if (lst_pooll.Items.Count != 0 & i!=0)
                {
                    lst_pooll.Items[i - 1].Selected = true;
                }
            }
           
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (lst_pooll.SelectedItems.Count == 1)
            {
                int i = lst_pooll.SelectedItems[0].Index;
                if (lst_pooll.Items.Count != 0 & i != 0)
                {
                    ListViewItem item = (ListViewItem)lst_pooll.SelectedItems[0].Clone();
                    lst_pooll.SelectedItems[0].Remove();
                    lst_pooll.Items.Insert(i - 1, item);
                    lst_pooll.Items[i - 1].Selected = true;
                }
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (lst_pooll.SelectedItems.Count == 1)
            {
                int i = lst_pooll.SelectedItems[0].Index;
               if(i+1!=lst_pooll.Items.Count)
               {
                    ListViewItem item = (ListViewItem)lst_pooll.SelectedItems[0].Clone();
                    lst_pooll.SelectedItems[0].Remove();
                    lst_pooll.Items.Insert(i + 1, item);
                    lst_pooll.Items[i + 1].Selected = true;
               }
            }
        }

        private void LoadTests(ListView control, bool withblankonly)
        {
            foreach (group testgroup in _ge.groups)
            {
                ListViewGroup lgroup = new ListViewGroup(testgroup.description);
                control.Groups.Add(lgroup);

                testgroup.testsparams.Load();
                IEnumerable<testsparam> tp = testgroup.testsparams;

                if (withblankonly == true)
                {
                    tp = testgroup.testsparams.Where(t => t.blankexists == 1);
                }
                IOrderedEnumerable<testsparam> otp = tp.OrderBy(tst => tst.description);

                foreach (testsparam t in otp)
                {
                    ListViewItem item = new ListViewItem(t.idt.ToString());
                    item.SubItems.Add(t.description);
                    control.Items.Add(item);
                    lgroup.Items.Add(item);
                }

            }
        }
    
       


        #region dragdrop

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // В этом обработчике определяем что делать, когда пользователь начал тащить элемент или элементы.
            var listView = sender as ListView;

            // Вызываем метод DoDragDrop чтобы начать перетаскивание.
            // Первый аргумент - это то, что мы хотим перетащить. В данном случае это все выделенные элементы.
            // Можно воспользоваться свойством e.Item, но тогда мы сможем перетаскивать только один элемент за раз.
            // Второй агумент - это действие, которое мы позволяем делать с элементом. В данном случае - перенести на другой лист
            listView.DoDragDrop(listView.SelectedItems, DragDropEffects.Move);
        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            // В этом обработчике определяем что делать при перетаскивании элемента на контрол
            // В аргументе e есть много полезных свойств: можно узнать что разрешил делать с элементом "родительский" контрол, например.
            var listView = sender as ListView;

            // Суть этого метода - поставить необходимое значение e.Effect. То есть какое действие должно выполниться после отпускания кнопки мыши:
            //  копирование, перенесение и т.д.
            // Значение этого параметра должно попадать в список разрешенных эффектов, установленных в методе DoDragDrop

            // В данном случае мы проверяем чтобы элементы, которые перетаскиваются, принадлежали определенному типу (иначе можно перетаскивать все подряд: файлы, ссылки, другие элементы).
            // То есть проверяем чтобы перетаскиваемые элементы были именно коллекцией выделенных элементов из контрола.
            // Если проверка проходит и разрешенный эффект совпадает с тем, что мы хотим сделать, ставим значение e.Effect на нужное действие - то, которое выполнится при отпускании мыши.
            if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection") && e.AllowedEffect == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            // Здесь выполняется непосредственное добавление/удаление элементов.
            // Если обработчик события DragEnter не разрешил действие, то после отпускания мыши это событие не будет вызвано.
            var listView = sender as ListView;

            // Достаем перетаскиваемые данные и приводим их к нужному нам типу - коллекции выделенных элементов.
            var items = e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection") as ListView.SelectedListViewItemCollection;

            // Начинаем обработку каждого элемента в коллекции
            foreach (ListViewItem item in items)
            {

                item.ListView.Items.Remove(item);	// Так как мы перетаскиваем из одного листа в другой, то элемент сначала надо удалить из "родительского" листа
                listView.Items.Add(item);           // Добавляем элемент в лист, на который его сбросили
            }
        }

        #endregion

        private void btn_add_Click(object sender, EventArgs e)
        {
            DialogBox db = new DialogBox();
            db.ShowDialog();
            if (db.DialogResult == DialogResult.OK)
            {
                if (db.Description.Length > 0)
                {
                    this.SavePack(db.Description);
                }
            }
        }

        private void SavePack(string description)
        {
            pack p = pack.Createpack(0, description);
            
             if (lst_pooll.Items.Count != 0)
            {
                foreach(ListViewItem item in lst_pooll.Items )
                {
               packtest pt = packtest.Createpacktest(0,p.idp, int.Parse(item.SubItems[0].Text));
               p.packtests.Add(pt);
                }
                _ge.packs.AddObject(p);
                _ge.SaveChanges();
                this.LoadPacks();
             }
             else
             {MessageBox.Show("Нет ни одного теста в списке");}
        }

        private void LoadPacks()
        {
            this.lst_pooll.Items.Clear();
            this.lst_packs.Items.Clear();
            var pks = _ge.packs;
            foreach (pack p in pks)
            {
                ListViewItem item = new ListViewItem(p.idp.ToString());
                item.SubItems.Add(p.description);
                this.lst_packs.Items.Add(item);
            }
        }

        private void PackSelect(int idp)
        {
            this.lst_pooll.Items.Clear();
            pack pk = _ge.packs.First(p => p.idp == idp);
            pk.packtests.Load();
            foreach (packtest pt in pk.packtests)
            {
                ListViewItem item = new ListViewItem(pt.idp.ToString());
                item.SubItems.Add(_ge.testsparams.First(tp => tp.idt == pt.idtest).description);
                this.lst_pooll.Items.Add(item);
            }
        }

        private void DeletePack(int idp)
        {
            pack pk = _ge.packs.First(p => p.idp == idp);
            _ge.packs.DeleteObject(pk);
            _ge.SaveChanges();
            this.LoadPacks();
        }
        private void lst_packs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
         this.PackSelect( int.Parse(e.Item.SubItems[0].Text));
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lst_packs.SelectedItems.Count == 1)
            {
                int i = lst_packs.SelectedItems[0].Index;
                this.DeletePack(int.Parse( lst_packs.Items[i].SubItems[0].Text));
                this.LoadPacks();
            }
            
        }
    }
}
