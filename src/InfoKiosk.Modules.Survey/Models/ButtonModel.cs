using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Modules.Survey.Models
{
    using System.ComponentModel;

    public class ButtonModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string originalContent;
        private string content;

        public string OriginalContent
        {
            get { return originalContent; }
        }

        public string Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }

        public ButtonModel(string originalContent)
        {
            this.originalContent = originalContent;
            Content = originalContent;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
