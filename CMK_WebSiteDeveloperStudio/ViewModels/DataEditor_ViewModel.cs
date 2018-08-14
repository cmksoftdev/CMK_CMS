using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK.Services;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class DataEditor_ViewModel : Editor_ViewModel
    {

        float columnWidth;
        public float ColumWidth
        {
            get
            {
                return columnWidth;
            }
            set
            {
                columnWidth = value - 30f;
                ColumWidthThird = (columnWidth) / 3f;
            }
        }
        float columnWidthThird;

        public DataEditor_ViewModel(Core core) : base(core)
        {
            com = new CommandMethodReflectionProvider(this);
        }

        public float ColumWidthThird
        {
            get
            {
                return columnWidthThird;
            }
            set
            {
                columnWidthThird = value;
                OnPropertyChanged(nameof(ColumWidthThird));
                OnPropertyChanged(nameof(ColumWidthTwoThird));
                OnPropertyChanged(nameof(ColumWidthSixth));
            }
        }

        public float ColumWidthTwoThird
        {
            get
            {
                return ColumWidth / 2f;
            }
        }

        public float ColumWidthSixth
        {
            get
            {
                return ColumWidth / 4f;
            }
        }
    }
}
