using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coastr.Data.Common.Impl
{
    public class ApplicationMessageList : List<ApplicationMessage>, INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool hasErrors()
        {
            return this.Any(it => it.Type == ApplicationMessageType.CRITICAL || it.Type == ApplicationMessageType.CRITICAL);
        }

        public new void Add(ApplicationMessage message)
        {
            base.Add(message);
            OnPropertyChanged();
        }

        public void RemoveRange(IEnumerable<ApplicationMessage> source)
        {
            // a little bit strange but Except returns a new list and I don't want to loose the CHange Event subscriptions
            var temp = this.Except(source);
            Clear();
            AddRange(temp);
        }
    }
}
