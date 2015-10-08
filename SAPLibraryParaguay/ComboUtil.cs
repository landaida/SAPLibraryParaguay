using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace SAPLibraryParaguay
{
    public static class ComboUtil
    {
        public static void populateComboBox<T>(System.Windows.Forms.ComboBox cmb, String valueMember, String displayMember, String tableName, Type type)
        {
            List<T> result = Util.getGenericList<T>(valueMember, displayMember, tableName).ToList<T>();             
            cmb.DataSource = result;            
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        public static void populateLookUpEdit<T>(LookUpEdit lkup, String valueMember, String displayMember, String tableName, Type type)
        {
            List<T> result = Util.getGenericList<T>(valueMember, displayMember, tableName).ToList<T>();
            lkup.Properties.DataSource = result;
            
            //The field whose values are displayed in the edit box
            lkup.Properties.DisplayMember = displayMember;
            //The field whose values match the edit value
            lkup.Properties.ValueMember = valueMember;


            //Unbound column
            lkup.Properties.Columns.Add(new LookUpColumnInfo(valueMember, "Id", 20));
            //Column bound to the existing 'Country' field from the data source
            lkup.Properties.Columns.Add(new LookUpColumnInfo(displayMember, "Nombre", 100));

        }

        public static void populateSearchLookUpEdit<T>(SearchLookUpEdit lkup, String valueMember, String displayMember, String tableName, String where = "")
        {

            List<T> lista = Util.getGenericList<T>(valueMember, displayMember, tableName, where).ToList<T>();
            //Specify an array of countries as a data source
            lkup.Properties.DataSource = lista;

            //The field whose values are displayed in the edit box
            lkup.Properties.DisplayMember = displayMember;
            //The field whose values match the edit value
            lkup.Properties.ValueMember = valueMember;

            lkup.Properties.PopupFilterMode = PopupFilterMode.Default;


            //Unbound column            
            //lkup.Properties.View.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn { FieldName = valueMember, Caption = "Id" });
            lkup.Properties.View.Columns.AddVisible(valueMember, "Id");
            //Column bound to the existing 'Country' field from the data source            
            //lkup.Properties.View.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn { FieldName = displayMember, Caption = "Nombre" });
            lkup.Properties.View.Columns.AddVisible(displayMember, "Nombre");

        }

        public static void confgComboBox<T>(System.Windows.Forms.ComboBox cmb, String valueMember, String displayMember, List<T> lista)
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        public static void confgComboBox<T>(DataGridViewComboBoxColumn cmb, String valueMember, String displayMember, List<T> lista)
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        public static void populateLookUpEditWhitEnums(LookUpEdit lkup, Type type)
        {
            if (typeof(DocumentStatus) == type)
            {
                List<DocumentStatus> lista = new List<DocumentStatus>();
                foreach (DocumentStatus item in Enum.GetValues(typeof(DocumentStatus)))
                {
                    lista.Add(item);
                }
                //Specify an array of countries as a data source
                lkup.Properties.DataSource = lista;

            }

            //The field whose values are displayed in the edit box
            //lkup.Properties.DisplayMember = displayMember;
            //The field whose values match the edit value
            //lkup.Properties.ValueMember = valueMember;


            //Unbound column
            //lkup.Properties.Columns.Add(new LookUpColumnInfo(valueMember, "Id", 20));
            //Column bound to the existing 'Country' field from the data source
            //lkup.Properties.Columns.Add(new LookUpColumnInfo(displayMember, "Nombre", 100));

        }

        public static void populateSearchLookUpEdit<T>(RepositoryItemSearchLookUpEdit lkup, String valueMember, String displayMember, List<T> lista)
        {
            //Specify an array of countries as a data source
            lkup.DataSource = lista;

            //The field whose values are displayed in the edit box
            //lkup.DisplayMember = displayMember;
            //The field whose values match the edit value
            //lkup.ValueMember = valueMember;

            lkup.PopupFilterMode = PopupFilterMode.Default;

            //Unbound column            
            //lkup.View.Columns.AddVisible(valueMember, "Id");
            //Column bound to the existing 'Country' field from the data source            
            //lkup.View.Columns.AddVisible(displayMember, "Nombre");

        }

    }
}
