using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Resourses
{
    internal class DGVTable
    {
        DataGridView grid;
        List<object> data;

        public void AddColumn(object name)
        {
            string strName = name.ToString();
            grid.Columns.Add(strName, strName);
        }
        public void AddColumn(object[] array)
        {

            grid.Columns.AddRange();

            DataGridViewColumn[] columns;
            foreach(object item in data)
            {
                
            }
        }
        
    }
}
