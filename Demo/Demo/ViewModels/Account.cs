using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Demo.ViewModels
{
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// PW
        /// </summary>
        public string PW { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 부서
        /// </summary>
        public string Department { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
